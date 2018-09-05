using System.ComponentModel.DataAnnotations;

namespace ERestaurant.Data.Model
{
    public class Item
    {
        [Key]
        public int ItemId { get; set; }

        [Required]
        [MaxLength(200)]
        public string ItemName { get; set; }

        [Required]
        public double ItemPrice { get; set; }

        [MaxLength(1000)]
        public string ItemDescription { get; set; }

        [MaxLength(2500)]
        public string ItemContents { get; set; }

        [Required]
        public bool ItemAvailability { get; set; }

        [Required]
        //[ForeignKey("Category")] //not necessary because the two properties are named the same, and EF recognizes which is the navigation property
        public int CategoryId { get; set; }

        public Category Category { get; set; }

        //public virtual List<int> Orders { get; set; } //doesn't seem necessary enough
    }
}
