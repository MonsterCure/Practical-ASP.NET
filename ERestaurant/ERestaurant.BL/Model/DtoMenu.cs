using ERestaurant.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        }

        public int MenuId { get; set; }

        public MenuType TypeEnum { get; set; }

        public string RestaurantName { get; set; }
    }
}
