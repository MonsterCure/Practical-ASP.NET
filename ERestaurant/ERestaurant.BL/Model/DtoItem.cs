using ERestaurant.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERestaurant.BL.Model
{
    public class DtoItem
    {
        public DtoItem()
        {

        }

        public DtoItem(Item item)
        {
            ItemId = item.ItemId;
            ItemName = item.ItemName;
            ItemPrice = item.ItemPrice;
            ItemDescription = item.ItemDescription;
            ItemContents = item.ItemContents;
            ItemAvailability = item.ItemAvailability;
            CategoryId = item.CategoryId;
        }

        public int ItemId { get; set; }

        public string ItemName { get; set; }

        public double ItemPrice { get; set; }

        public string ItemDescription { get; set; }

        public string ItemContents { get; set; }

        public bool ItemAvailability { get; set; }

        public int CategoryId { get; set; }
    }
}
