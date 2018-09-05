using ERestaurant.Data.Model;

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
            RestaurantName = menu.RestaurantName;
        }

        public int MenuId { get; set; }

        public MenuType TypeEnum { get; set; }

        public string RestaurantName { get; set; }
    }
}
