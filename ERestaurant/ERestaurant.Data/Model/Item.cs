using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERestaurant.Data.Model
{
    public class Item
    {
        [Key]
        public int ItemId { get; set; }

        [Required]
        [MaxLength(200)]
        public string ItemName { get; set; }

        [Required]
        public double ItemPrice { get; set; }

        [MaxLength(1000)]
        public string ItemDescription { get; set; }

        [MaxLength(2500)]
        public string ItemContents { get; set; }

        [Required]
        public bool ItemAvailability { get; set; }

        [Required]
        public int CategoryId { get; set; }

        public Category Category { get; set; }

        //public virtual List<int> Orders { get; set; } //doesn't seem necessary enough
    }
}
