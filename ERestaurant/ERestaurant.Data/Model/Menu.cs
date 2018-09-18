using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ERestaurant.Data.Model
{
    public class Menu
    {
        [Key]
        public int MenuId { get; set; }

        [Required]
        public byte TypeId { get; set; }
        //public MenuType MenuType { get; set; }

        public int RestaurantId { get; set; }

        public Restaurant Restaurant { get; set; }

        public List<Category> MenuCategories { get; set; }
    }
}
