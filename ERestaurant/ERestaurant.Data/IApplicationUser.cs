using ERestaurant.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERestaurant.Data
{
    public interface IApplicationUser
    {
        List<Order> Orders { get; set; }
    }
}
