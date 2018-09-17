using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ERestaurant.Data.Model;
using Microsoft.AspNet.Identity.EntityFramework;

namespace ERestaurant.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("name=RestaurantConnection", throwIfV1Schema: false) // RestaurantConnection or DefaultConnection
        {
            Database.SetInitializer<ApplicationDbContext>(new ApplicationDbInitializer());
            //Database.Create();
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        public DbSet<Restaurant> Restaurants { get; set; }

        public DbSet<Menu> Menus { get; set; }

        public DbSet<Category> Categories { get; set; }

        public DbSet<Item> Items { get; set; }

        public DbSet<Order> Orders { get; set; }

        public DbSet<OrderItem> OrderItems { get; set; }
        
        //protected override void OnModelCreating(DbModelBuilder modelBuilder)
        //{
        //     base.OnModelCreating(modelBuilder);
        //}
    }

    //public class RestaurantContext : DbContext
    //{
    //    public RestaurantContext() : base("name=RestaurantConnection")
    //    {

    //    }

    //    public DbSet<Menu> Menus { get; set; }

    //    public DbSet<Category> Categories { get; set; }

    //    public DbSet<Item> Items { get; set; }

    //    public DbSet<Order> Orders { get; set; }

    //    public DbSet<OrderItem> OrderItems { get; set; }
    //}
}
