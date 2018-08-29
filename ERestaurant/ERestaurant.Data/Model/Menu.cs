using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERestaurant.Data.Model
{
    class Menu
    {
        public int MenuId { get; set; }

        public MenuType MenuType { get; set; }

        public string RestaurantName { get; set; }

        public List<Category> MenuCategories { get; set; }
    }
}
