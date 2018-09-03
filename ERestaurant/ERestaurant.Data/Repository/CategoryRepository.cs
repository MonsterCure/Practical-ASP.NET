using ERestaurant.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERestaurant.Data.Repository
{
    public class CategoryRepository : BaseRepository, IRepository<Category>
    {
        public IList<Category> GetAll()
        {
            return DbContext.Categories.ToList();
        }

        public Category GetById(int id)
        {
            Category category = DbContext.Categories.SingleOrDefault(categoryItem => categoryItem.CategoryId == id);
            return category;
        }

        public Category Create(Category category)
        {
            DbContext.Categories.Add(category);
            DbContext.SaveChanges();

            return category;
        }

        public void Update(Category category)
        {
            var dbItem = DbContext.Categories.Single(categoryItem => categoryItem.CategoryId == category.CategoryId);
            dbItem.MenuId = category.MenuId;
            dbItem.CategoryName = category.CategoryName;
            DbContext.Entry(dbItem).State = System.Data.Entity.EntityState.Modified;
            DbContext.SaveChanges();
        }

        public void Delete(Category category)
        {
            var dbItem = DbContext.Categories.Single(categoryItem => categoryItem.CategoryId == category.CategoryId);
            DbContext.Categories.Remove(dbItem);
            DbContext.SaveChanges();
        }
    }
}
