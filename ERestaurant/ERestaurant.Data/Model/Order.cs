using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERestaurant.Data.Model
{
    class Order
    {
        public int OrderId { get; set; }

        public DateTime OrderCreated { get; set; }

        public int TotalItemQuantity
        {
            get
            {
                return _totalItemQuantity;
            }
            set
            {
                _totalItemQuantity = OrderItems.Count();
            }
        }
        private int _totalItemQuantity;

        public double TotalPrice
        {
            get
            {
                return _totalPrice;
            }
            set
            {
                _totalPrice = OrderItems.Select(item => item.ItemPrice).Sum();
            }
        }
        private double _totalPrice;

        public int Table { get; set; }

        public string Comment { get; set; }

        public ItemStatus ItemStatus { get; set; }

        public virtual List<Item> OrderItems { get; set; }
    }
}
