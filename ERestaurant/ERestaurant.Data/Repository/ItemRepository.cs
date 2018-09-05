using ERestaurant.Data.Model;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace ERestaurant.Data.Repository
{
    public class ItemRepository : BaseRepository, IRepository<Item>
    {
        public Item Create(Item item)
        {
            //DbContext.Items.Add(item);
            //DbContext.SaveChanges();

            //return item;

            item.ItemId = default(int);
            item.ItemName = item.ItemName.Trim();
            DbContext.Set<Item>().Add(item);
            int rowsAffected = DbContext.SaveChanges();
            return item;
        }

        public void Delete(Item item)
        {
            var dbItem = DbContext.Items.Single(itemItem => itemItem.ItemId == item.ItemId);
            DbContext.Items.Remove(dbItem);
            DbContext.SaveChanges();
        }

        public IList<Item> GetAll()
        {
            return DbContext.Items.ToList();
        }

        public Item GetById(int id)
        {
            Item item = DbContext.Items.SingleOrDefault(itemItem => itemItem.ItemId == id);
            return item;
        }

        public void Update(Item item)
        {
            var dbItem = DbContext.Items.Single(itemItem => itemItem.ItemId == item.ItemId);
            dbItem.ItemName = item.ItemName;
            dbItem.ItemPrice = item.ItemPrice;
            dbItem.ItemDescription = item.ItemDescription;
            dbItem.ItemContents = item.ItemContents;
            dbItem.ItemAvailability = item.ItemAvailability;
            dbItem.CategoryId = item.CategoryId;
            DbContext.Entry(dbItem).State = EntityState.Modified;
            DbContext.SaveChanges();
        }
    }
}
