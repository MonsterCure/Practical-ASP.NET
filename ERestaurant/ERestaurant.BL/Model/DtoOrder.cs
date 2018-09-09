using ERestaurant.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;

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
            ListOrderItems = order.ListOrderItems.Select(loi => new DtoOrderItem(loi)).ToList();
            TotalCost = order.TotalCost ?? 0;
            TotalQuantity = order.TotalQuantity ?? 0;
        }

        public int OrderId { get; set; }

        public DateTime WhenCreated { get; set; }

        public string Table { get; set; }

        public string Comments { get; set; }

        public byte StatusId { get; set; }

        public List<DtoOrderItem> ListOrderItems { get; set; }

        public double TotalCost { get; set; }

        public int TotalQuantity { get; set; }
    }
}
