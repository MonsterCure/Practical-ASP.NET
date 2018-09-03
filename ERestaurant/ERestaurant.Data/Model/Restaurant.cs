using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERestaurant.Data.Model
{
    public class Restaurant
    {
        [Key]
        public int RestaurantId { get; set; }
    }
}
