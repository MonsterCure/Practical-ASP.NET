using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERestaurant.Data.Model
{
    public class OrderItem
    {
        [Key]
        public int OrderItemId { get; set; }

        public int OrderId { get; set; }

        public Order Order { get; set; }

        public int ItemId { get; set; }

        public Item Item { get; set; }

        [Required]
        public short ItemQuantity { get; set; }

        //public ItemStatus ItemStatus { get; set; } // here if ItemStatus or OrderStatus, or in Order if OrderStatus
    }
}
