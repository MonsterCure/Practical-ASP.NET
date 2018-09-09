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

                    transaction.Commit();

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

        public ServiceResult<DtoOrder> Edit(DtoOrder item)
        {
            using (var transaction = Context.Database.BeginTransaction())
            {
                try
                {
                    Repository.Update(new Order()
                    {
                        OrderId = item.OrderId,
                        WhenCreated = item.WhenCreated,
                        Table = item.Table,
                        Comments = item.Comments,
                        StatusId = (byte)item.StatusId,
                        //ListOrderItems = item.ListOrderItems
                    });

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
    }
}
