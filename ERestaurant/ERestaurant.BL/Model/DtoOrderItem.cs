using ERestaurant.Data.Model;

namespace ERestaurant.BL.Model
{
    public class DtoOrderItem
    {
        public DtoOrderItem()
        {

        }

        public DtoOrderItem(OrderItem orderItem)
        {
            OrderItemId = orderItem.OrderItemId;
            OrderId = orderItem.OrderId;
            ItemId = orderItem.ItemId;
            ItemQuantity = orderItem.ItemQuantity;
        }

        public int OrderItemId { get; set; }

        public int OrderId { get; set; }

        public int ItemId { get; set; }

        public short ItemQuantity { get; set; }
    }
}
