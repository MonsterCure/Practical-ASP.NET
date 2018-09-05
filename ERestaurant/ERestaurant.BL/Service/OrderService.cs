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
        public ServiceResult<DtoOrder> Add(DtoOrder item)
        {
            try
            {
                var result = Repository.Create(new Order()
                {
                    //OrderId = 0,
                    WhenCreated = DateTime.UtcNow,
                    Table = item.Table,
                    Comments = item.Comments,
                    StatusId = (byte)OrderStatus.Created,
                    ListOrderItems = item.ListOrderItems
                });

                return new ServiceResult<DtoOrder>()
                {
                    Item = new DtoOrder(result),
                    Success = true
                };

                //using (var transaction = Repository.DbContext.Database.BeginTransaction())
                //{
                //    Repository.DbContext.Orders.Add(new Order
                //    {
                //        OrderId = 0,
                //        StatusId = (byte)OrderStatus.Created,
                //        Table = item.Table,
                //        WhenCreated = DateTime.UtcNow
                //    });
                //}
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

        public ServiceResult<DtoOrder> Edit(DtoOrder item)
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
                    ListOrderItems = item.ListOrderItems
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
                    ListOrderItems = item.ListOrderItems,
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
