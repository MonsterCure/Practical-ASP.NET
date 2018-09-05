using ERestaurant.Data.Model;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace ERestaurant.Data.Repository
{
    public class MenuRepository : BaseRepository, IRepository<Menu>
    {
        public IList<Menu> GetAll()
        {
            return DbContext.Menus.ToList();
        }

        public Menu GetById(int id)
        {
            Menu menu = DbContext.Menus.SingleOrDefault(menuItem => menuItem.MenuId == id);
            return menu;
        }

        public Menu Create(Menu menu)
        {
            DbContext.Menus.Add(menu);
            DbContext.SaveChanges();

            return menu;
        }

        public void Update(Menu menu)
        {
            var dbItem = DbContext.Menus.Single(menuItem => menuItem.MenuId == menu.MenuId);
            dbItem.TypeId = menu.TypeId;
            dbItem.RestaurantName = menu.RestaurantName;
            DbContext.Entry(dbItem).State = EntityState.Modified;
            DbContext.SaveChanges();
        }

        public void Delete(Menu menu)
        {
            var dbItem = DbContext.Menus.Single(menuItem => menuItem.MenuId == menu.MenuId);
            DbContext.Menus.Remove(dbItem);
            DbContext.SaveChanges();
        }
    }
}
