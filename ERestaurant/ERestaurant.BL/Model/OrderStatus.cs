using System.ComponentModel.DataAnnotations;

namespace ERestaurant.BL.Model
{
    public enum OrderStatus
    {
        Undefined = 0,

        Created = 1,

        [Display(Name ="In progress")]
        InProgress = 2,

        Prepared = 3,

        Delivered = 4
    }
}
