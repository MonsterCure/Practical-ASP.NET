using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERestaurant.Data.Model
{
    class OrderItem
    {
        public int OrderId { get; set; }

        public Order Order { get; set; }

        public int ItemId { get; set; }

        public Item Item { get; set; }

        public int ItemQuantity { get; set; }

        //public ItemStatus ItemStatus { get; set; } // here or in Order
    }
}
