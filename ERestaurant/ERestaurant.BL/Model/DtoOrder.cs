using ERestaurant.Data.Model;
using System;
using System.Collections.Generic;

namespace ERestaurant.BL.Model
{
    public class DtoOrder
    {
        public DtoOrder()
        {

        }

        public DtoOrder(Order order)
        {
            OrderId = order.OrderId;
            WhenCreated = order.WhenCreated;
            Table = order.Table;
            Comments = order.Comments;
            StatusId = order.StatusId;
            ListOrderItems = order.ListOrderItems;
        }

        public int OrderId { get; set; }

        public DateTime WhenCreated { get; set; }

        public string Table { get; set; }

        public string Comments { get; set; }

        public byte StatusId { get; set; }

        public List<OrderItem> ListOrderItems { get; set; }
    }
}
