using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERestaurant.Data.Model
{
    public class Menu
    {
        [Key]
        public int MenuId { get; set; }

        [Required]
        public byte TypeId { get; set; }
        //public MenuType MenuType { get; set; }

        [Required]
        [MaxLength(200)]
        public string RestaurantName { get; set; }

        public List<Category> MenuCategories { get; set; }
    }
}
