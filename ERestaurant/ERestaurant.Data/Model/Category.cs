using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ERestaurant.Data.Model
{
    public class Category
    {
        [Key]
        public int CategoryId { get; set; }

        [Required]
        [MaxLength(200)]
        public string CategoryName { get; set; }

        public int MenuId { get; set; }

        public Menu Menu { get; set; }

        public List<Item> ListItems { get; set; }
    }
}
