using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERestaurant.Data.Model
{
    class OrderItem
    {
        [ForeignKey("Order")]
        public int OrderId { get; set; }

        public virtual Order Order { get; set; }

        [ForeignKey("Item")]
        public int ItemId { get; set; }

        public virtual Item Item { get; set; }

        public int ItemQuantity { get; set; }

        //public ItemStatus ItemStatus { get; set; } // here if ItemStatus or OrderStatus, or in Order if OrderStatus
    }
}
