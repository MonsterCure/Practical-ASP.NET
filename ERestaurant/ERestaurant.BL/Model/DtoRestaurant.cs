using ERestaurant.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERestaurant.BL.Model
{
    public class DtoRestaurant
    {
        public DtoRestaurant()
        {

        }

        public DtoRestaurant(Restaurant restaurant)
        {
            RestaurantId = restaurant.RestaurantId;
            RestaurantName = restaurant.RestaurantName;
            RestaurantMenus = restaurant.RestaurantMenus.Select(rm => new DtoMenu(rm)).ToList();
        }
        public int RestaurantId { get; set; }

        public string RestaurantName { get; set; }

        public List<DtoMenu> RestaurantMenus { get; set; }
    }
}
