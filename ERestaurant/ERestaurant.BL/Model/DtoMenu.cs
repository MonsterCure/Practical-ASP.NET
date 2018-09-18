using ERestaurant.Data.Model;
using System.Collections.Generic;

namespace ERestaurant.BL.Model
{
    public class DtoMenu
    {
        public DtoMenu()
        {
            
        }

        public DtoMenu(Menu menu)
        {
            MenuId = menu.MenuId;
            TypeEnum = (MenuType)menu.TypeId;
            RestaurantId = menu.RestaurantId;
        }

        public int MenuId { get; set; }

        public MenuType TypeEnum { get; set; }

        public int RestaurantId { get; set; }

        public List<DtoCategory> MenuCategories { get; set; }
    }
}
