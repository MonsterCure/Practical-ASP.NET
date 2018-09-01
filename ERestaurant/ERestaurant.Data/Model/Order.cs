using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERestaurant.Data.Model
{
    public class Order
    {
        [Key]
        public int OrderId { get; set; }

        [Required]
        public DateTime WhenCreated { get; set; }

        [Required]
        [MaxLength(3)]
        public string Table { get; set; }

        public string Comments { get; set; }

        [Required]
        public byte StatusId { get; set; }
        //public OrderStatus OrderStatus { get; set; }

        public List<OrderItem> ListOrderItems { get; set; }

        public int? TotalQuantity => ListOrderItems?.Sum(loi => loi.ItemQuantity); // read-only helper properties, have no setters, but are initialized at the declaration, so no need to calculate the values every time they're needed

        public double? TotalCost => ListOrderItems?.Sum(loi => loi.ItemQuantity * loi.Item.ItemPrice);

        //OR instead of read-only properties
        //public int TotalItemQuantity
        //{
        //    get
        //    {
        //        return _totalItemQuantity;
        //    }
        //    set
        //    {
        //        _totalItemQuantity = ListOrderItems.Count();
        //    }
        //}
        //private int _totalItemQuantity;

        //public double TotalPrice
        //{
        //    get
        //    {
        //        return _totalPrice;
        //    }
        //    set
        //    {
        //        _totalPrice = ListOrderItems.Select(item => item.ItemPrice).Sum();
        //    }
        //}
        //private double _totalPrice;
    }
}
