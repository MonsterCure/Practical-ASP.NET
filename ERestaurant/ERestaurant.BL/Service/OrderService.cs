using ERestaurant.BL.Model;
using ERestaurant.Data.Model;
using ERestaurant.Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ERestaurant.BL.Service
{
    public class OrderService : BaseService<OrderRepository>, IService<DtoOrder>
    {
        public ServiceResult<DtoOrder> Add(DtoOrder order)
        {
            using (var transaction = Context.Database.BeginTransaction())
            {
                try
                {
                    //TODO: Implement validation
                    var newOrder = new Order
                    {
                        OrderId = 0,
                        StatusId = (byte)OrderStatus.Created,
                        Table = order.Table,
                        WhenCreated = DateTime.UtcNow
                    };

                    Context.Orders.Add(newOrder);
                    Context.SaveChanges();

                    Context.OrderItems.AddRange(order.ListOrderItems.Select(o => new OrderItem
                    {
                        OrderItemId = 0,
                        ItemId = o.ItemId,
                        OrderId = newOrder.OrderId,
                        ItemQuantity = o.ItemQuantity
                    }));

                    transaction.Commit(); // SaveChanges() not necessary after the last change to the database and/or before transaction.Commit()

                    return new ServiceResult<DtoOrder>
                    {
                        Success = true,
                        Item = new DtoOrder(newOrder)
                    };
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    return new ServiceResult<DtoOrder>
                    {
                        Success = false,
                        Exception = ex,
                        ErrorMessage = "An exception occurred."
                    };
                }
            }
        }

        public ServiceResult<DtoOrder> Edit(DtoOrder item) //only for StatusId, Comments and Table
        {
            using (var transaction = Context.Database.BeginTransaction())
            {
                try
                {
                    if (item == null) //maybe also if(!modelState.IsValid)
                    {
                        return new ServiceResult<DtoOrder>
                        {
                            Success = false,
                            Exception = new ArgumentNullException("Order not valid.")
                        };
                    }

                    var dbOrder = Repository.DbContext.Orders.FirstOrDefault(o => o.OrderId == item.OrderId);

                    if (dbOrder == null)
                    {
                        return new ServiceResult<DtoOrder>
                        {
                            Success = false,
                            ErrorMessage = "Order not found."
                        };
                    }

                    //dbOrder.StatusId = (byte)item.StatusId; //to be changed in separte method, becuase of privilege to change it
                    dbOrder.Table = item.Table;
                    dbOrder.Comments = item.Comments;

                    Repository.Update(dbOrder); //?
                    Context.SaveChanges(); //?

                    transaction.Commit();

                    return new ServiceResult<DtoOrder>()
                    {
                        Success = true
                    };
                }
                catch (Exception ex)
                {
                    //Log exception
                    transaction.Rollback();
                    return new ServiceResult<DtoOrder>()
                    {
                        Success = false,
                        Exception = ex,
                        ErrorMessage = ex.Message
                    };
                }
            }
        }

        public ServiceResult<DtoOrder> Load(DtoOrder item)
        {
            try
            {
                var result = Repository.GetById(item.OrderId);

                return new ServiceResult<DtoOrder>()
                {
                    Item = new DtoOrder(result),
                    Success = true
                };
            }
            catch (Exception ex)
            {
                //Log exception
                return new ServiceResult<DtoOrder>()
                {
                    Success = false,
                    Exception = ex,
                    ErrorMessage = ex.Message
                };
            }
        }

        public ServiceResult<DtoOrder> LoadAll()
        {
            try
            {
                var orders = Repository.GetAll().ToList();
                var resultList = new List<DtoOrder>();
                orders.ForEach(o => resultList.Add(new DtoOrder(o))); //mapping the object from Data into the object from Service

                return new ServiceResult<DtoOrder>()
                {
                    ListItems = resultList,
                    Success = true
                };
            }
            catch (Exception ex)
            {
                //Log exception
                return new ServiceResult<DtoOrder>()
                {
                    Success = false,
                    Exception = ex,
                    ErrorMessage = ex.Message
                };
            }
        }

        public ServiceResult<DtoOrder> Remove(DtoOrder item)
        {
            try
            {
                Repository.Delete(new Order()
                {
                    OrderId = item.OrderId,
                    WhenCreated = item.WhenCreated,
                    Table = item.Table,
                    Comments = item.Comments,
                    StatusId = (byte)item.StatusId,
                    //ListOrderItems = item.ListOrderItems
                });

                return new ServiceResult<DtoOrder>()
                {
                    Success = true
                };
            }
            catch (Exception ex)
            {
                //Log exception
                return new ServiceResult<DtoOrder>()
                {
                    Success = false,
                    Exception = ex,
                    ErrorMessage = ex.Message
                };
            }
        }

        public ServiceResult<DtoOrderItem> SetOrderItem(DtoOrderItem orderItem)
        {
            using (var transaction = Context.Database.BeginTransaction())
            {
                try
                {
                    if (orderItem == null) //maybe also if(!modelState.IsValid)
                    {
                        return new ServiceResult<DtoOrderItem>
                        {
                            Success = false,
                            Exception = new ArgumentNullException("Order item not valid.")
                        };
                    }

                    var dbOrderItem = Context.OrderItems.FirstOrDefault(oi => oi.OrderItemId == orderItem.OrderItemId);

                    if (dbOrderItem != null)
                    {
                        if(orderItem.ItemQuantity > 0)
                        {
                            if(dbOrderItem.ItemQuantity == orderItem.ItemQuantity)
                            {
                                return new ServiceResult<DtoOrderItem>
                                {
                                    Success = true,
                                    Item = new DtoOrderItem(dbOrderItem)
                                };
                            }

                            //exists - update it
                            dbOrderItem.ItemQuantity = orderItem.ItemQuantity;
                            Context.SaveChanges();

                            return new ServiceResult<DtoOrderItem>
                            {
                                Success = true,
                                Item = new DtoOrderItem(dbOrderItem)
                            };
                        }
                        else if(orderItem.ItemQuantity == 0)
                        {
                            //exists - delete it
                            Context.OrderItems.Remove(dbOrderItem);
                            Context.SaveChanges();

                            return new ServiceResult<DtoOrderItem>
                            {
                                Success = true
                            };
                        }
                        else
                        {
                            //exists - throw error because quantity cannot be negative
                            return new ServiceResult<DtoOrderItem>
                            {
                                Success = false,
                                ErrorMessage = "Item quantity cannot be negative."
                            };
                        }
                    }
                    else
                    {
                        if (orderItem.ItemQuantity < 1)
                        {
                            return new ServiceResult<DtoOrderItem>
                            {
                                Success = false,
                                ErrorMessage = "Item quantity cannot be negative."
                            };
                        }

                        var orderExists = Context.Orders.Any(o => o.OrderId == orderItem.OrderId);
                        var itemExists = Context.Items.Any(i => i.ItemId == orderItem.ItemId);

                        if (!orderExists)
                            return new ServiceResult<DtoOrderItem>
                            {
                                Success = false,
                                ErrorMessage = "Order not found."
                            };

                        if(!itemExists)
                            return new ServiceResult<DtoOrderItem>
                            {
                                Success = false,
                                ErrorMessage = "Item not found."
                            };

                        //create the order item
                        var newOrderItem = new OrderItem
                        {
                            //OrderItemId = orderItem.OrderItemId,
                            ItemId = orderItem.ItemId,
                            OrderId = orderItem.OrderId,
                            ItemQuantity = orderItem.ItemQuantity
                        };

                        Context.OrderItems.Add(newOrderItem);
                        Context.SaveChanges();

                        transaction.Commit();

                        return new ServiceResult<DtoOrderItem>()
                        {
                            Success = true,
                            Item = new DtoOrderItem(newOrderItem)
                        };
                    }
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    return new ServiceResult<DtoOrderItem>()
                    {
                        Success = false,
                        Exception = ex,
                        ErrorMessage = "Order item not set."
                    };
                }
            }
        }
    }
}
