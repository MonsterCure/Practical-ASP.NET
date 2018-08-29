using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERestaurant.Data.Model
{
    enum ItemStatus
    {
        Processing = 1,

        Accepted = 2, //Created

        BeingPrepared = 3,

        Prepared = 4,

        BeingDelivered = 5,

        Delivered = 6,

        Unsuccessful = 0
    }
}
