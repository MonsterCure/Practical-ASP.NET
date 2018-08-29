using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERestaurant.Data.Model
{
    class Item
    {
        public int ItemId { get; set; }

        public string ItemName { get; set; }

        public double ItemPrice { get; set; }

        public string ItemDescription { get; set; }

        public string ItemContents { get; set; }

        public bool ItemAvailability { get; set; }

        public virtual List<int> Orders { get; set; }
    }
}
