using ERestaurant.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERestaurant.BL.Model
{
    public class DtoCategory
    {
        public DtoCategory()
        {

        }

        public DtoCategory(Category category)
        {
            CategoryId = category.CategoryId;
            CategoryName = category.CategoryName;
            MenuId = category.MenuId;
        }

        public int CategoryId { get; set; }

        public string CategoryName { get; set; }

        public int MenuId { get; set; }
    }
}
