using ERestaurant.Data.Model;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace ERestaurant.Data.Repository
{
    public class OrderRepository : BaseRepository, IRepository<Order>
    {
        public Order Create(Order item)
        {
            DbContext.Orders.Add(item);
            DbContext.SaveChanges();

            return item;
        }

        public void Delete(Order item)
        {
            var dbItem = DbContext.Orders.Single(orderItem => orderItem.OrderId == item.OrderId);
            DbContext.Orders.Remove(dbItem);
            DbContext.SaveChanges();
        }

        public IList<Order> GetAll()
        {
            return DbContext.Orders.ToList();
        }

        public Order GetById(int id)
        {
            Order order = DbContext.Orders.SingleOrDefault(orderItem => orderItem.OrderId == id);
            return order;
        }

        public void Update(Order item)
        {
            var dbItem = DbContext.Orders.Single(orderItem => orderItem.OrderId == item.OrderId);
            dbItem.WhenCreated = item.WhenCreated;
            dbItem.Table = item.Table;
            dbItem.Comments = item.Comments;
            dbItem.StatusId = item.StatusId;
            DbContext.Entry(dbItem).State = EntityState.Modified;
            DbContext.SaveChanges();
        }
    }
}
