﻿using ERestaurant.Data.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERestaurant.Data.Repository
{
    public class RestaurantContext : DbContext
    {
        public RestaurantContext() : base("name=RestaurantConnection")
        {
            
        }

        public DbSet<Menu> Menus { get; set; }

        public DbSet<Category> Categories { get; set; }

        public DbSet<Item> Items { get; set; }

        public DbSet<Order> Orders { get; set; }

        public DbSet<OrderItem> OrderItems { get; set; }
    }
}
