﻿using ERestaurant.Data.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERestaurant.Data
{
    internal class ApplicationDbInitializer : CreateDatabaseIfNotExists<ApplicationDbContext>
    {
        protected override void Seed(ApplicationDbContext context)
        {
            context.Restaurants.Add(new Restaurant()
            {
                RestaurantId = 1,
                RestaurantName = "Veneto"
            });

            context.Restaurants.Add(new Restaurant()
            {
                RestaurantId = 2,
                RestaurantName = "Gino"
            });

            context.Restaurants.Add(new Restaurant()
            {
                RestaurantId = 3,
                RestaurantName = "Irish Pub"
            });

            context.Restaurants.Add(new Restaurant()
            {
                RestaurantId = 4,
                RestaurantName = "Pelister"
            });

            context.Restaurants.Add(new Restaurant()
            {
                RestaurantId = 5,
                RestaurantName = "Enriko"
            });

            context.Menus.Add(new Menu()
            {
                MenuId = 1,
                TypeId = 1,
                RestaurantId = 1
            });

            context.Menus.Add(new Menu()
            {
                MenuId = 2,
                TypeId = 3,
                RestaurantId = 1
            });

            context.Menus.Add(new Menu()
            {
                MenuId = 3,
                TypeId = 1,
                RestaurantId = 2
            });

            context.Menus.Add(new Menu()
            {
                MenuId = 4,
                TypeId = 3,
                RestaurantId = 2
            });

            context.Menus.Add(new Menu()
            {
                MenuId = 5,
                TypeId = 1,
                RestaurantId = 3
            });

            context.Menus.Add(new Menu()
            {
                MenuId = 6,
                TypeId = 2,
                RestaurantId = 3
            });

            context.Menus.Add(new Menu()
            {
                MenuId = 7,
                TypeId = 1,
                RestaurantId = 4
            });

            context.Menus.Add(new Menu()
            {
                MenuId = 8,
                TypeId = 3,
                RestaurantId = 4
            });

            context.Menus.Add(new Menu()
            {
                MenuId = 9,
                TypeId = 1,
                RestaurantId = 5
            });

            context.Menus.Add(new Menu()
            {
                MenuId = 10,
                TypeId = 2,
                RestaurantId = 5
            });

            context.Categories.Add(new Category()
            {
                CategoryId = 1,
                CategoryName = "Salads",
                MenuId = 1
            });

            context.Categories.Add(new Category()
            {
                CategoryId = 2,
                CategoryName = "White wines",
                MenuId = 2
            });

            context.Categories.Add(new Category()
            {
                CategoryId = 3,
                CategoryName = "Pasta",
                MenuId = 3
            });

            context.Categories.Add(new Category()
            {
                CategoryId = 4,
                CategoryName = "Red wines",
                MenuId = 4
            });

            context.Categories.Add(new Category()
            {
                CategoryId = 5,
                CategoryName = "Sandwiches",
                MenuId = 5
            });

            context.Categories.Add(new Category()
            {
                CategoryId = 6,
                CategoryName = "Beers",
                MenuId = 6
            });

            context.Categories.Add(new Category()
            {
                CategoryId = 7,
                CategoryName = "Desserts",
                MenuId = 7
            });

            context.Categories.Add(new Category()
            {
                CategoryId = 8,
                CategoryName = "Red wines",
                MenuId = 8
            });

            context.Categories.Add(new Category()
            {
                CategoryId = 9,
                CategoryName = "Pizzas",
                MenuId = 9
            });

            context.Categories.Add(new Category()
            {
                CategoryId = 10,
                CategoryName = "Juices",
                MenuId = 10
            });

            context.Items.Add(new Item()
            {
                ItemName = "Caesar salad",
                ItemPrice = 120,
                ItemDescription = "Ceasar salad with chicken meat, Romaine lettuce, carrots and cheese.",
                ItemContents = "grilled chicken, romaine lettuce, olive oil, croutons, carrots, Parmesan cheese",
                ItemAvailability = true,
                CategoryId = 1
            });

            context.Items.Add(new Item()
            {
                ItemName = "Caprese salad",
                ItemPrice = 150,
                ItemDescription = "Caprese salad with salmon, tomatoes and mozzarella.",
                ItemContents = "smoked salmon, tomatoes, mozzarella, basil, olive oil, lemon dressing",
                ItemAvailability = true,
                CategoryId = 1
            });

            context.Items.Add(new Item()
            {
                ItemName = "Chardonnay",
                ItemPrice = 100,
                ItemDescription = "A 175 ml glass of Chardonnay wine.",
                ItemContents = "Chardonnay wine",
                ItemAvailability = true,
                CategoryId = 2
            });

            context.Items.Add(new Item()
            {
                ItemName = "Sauvignon Blanc",
                ItemPrice = 110,
                ItemDescription = "A 175 ml glass of Sauvignon Blanc wine.",
                ItemContents = "Sauvignon Blanc wine",
                ItemAvailability = true,
                CategoryId = 2
            });

            context.Items.Add(new Item()
            {
                ItemName = "Lasagne al forno",
                ItemPrice = 170,
                ItemDescription = "A serving of Lasagne al forno.",
                ItemContents = "lasagne noodles, ground beef, tomato paste, ricotta cheese, Parmesan cheese, mozzarella, onion, garlic, basil, olive oil",
                ItemAvailability = true,
                CategoryId = 3
            });

            context.Items.Add(new Item()
            {
                ItemName = "Gnocchi ai 4 formaggi",
                ItemPrice = 190,
                ItemDescription = "A serving of Gnocchi ai 4 formaggi.",
                ItemContents = "gnocchi, Gorgonzola cheese, Emmentaler cheese, mozzarella, Parmesan cheese, black pepper",
                ItemAvailability = true,
                CategoryId = 3
            });

            context.Items.Add(new Item()
            {
                ItemName = "Cabernet Sauvignon",
                ItemPrice = 110,
                ItemDescription = "A 175 ml glass of Cabernet Sauvignon wine.",
                ItemContents = "Cabernet Sauvignon wine",
                ItemAvailability = true,
                CategoryId = 4
            });

            context.Items.Add(new Item()
            {
                ItemName = "Merlot",
                ItemPrice = 115,
                ItemDescription = "A 175 ml glass of Merlot wine.",
                ItemContents = "Merlot wine",
                ItemAvailability = true,
                CategoryId = 4
            });
            
            context.Items.Add(new Item()
            {
                ItemName = "Club sandwich",
                ItemPrice = 140,
                ItemDescription = "Club sandwich with ham.",
                ItemContents = "toast bread, ham, cheese, lettuce, tomato, cucumber, french fries",
                ItemAvailability = true,
                CategoryId = 5
            });

            context.Items.Add(new Item()
            {
                ItemName = "Pizza sandwich",
                ItemPrice = 130,
                ItemDescription = "Pizza sandwich with ham and mushrooms.",
                ItemContents = "spicy home-made sauce, ham, yellow cheese, mushrooms, peppers, tomatoes, lettuce, olives",
                ItemAvailability = true,
                CategoryId = 5
            });
            
            context.Items.Add(new Item()
            {
                ItemName = "Guinness beer",
                ItemPrice = 210,
                ItemDescription = "A 300ml glass of Irish dry stout beer.",
                ItemContents = "Guinness beer",
                ItemAvailability = true,
                CategoryId = 6
            });
            
            context.Items.Add(new Item()
            {
                ItemName = "Paulaner Dunkel beer",
                ItemPrice = 280,
                ItemDescription = "A 300ml glass of German dark lager beer.",
                ItemContents = "Paulaner Dunkel beer",
                ItemAvailability = true,
                CategoryId = 6
            });
            
            context.Items.Add(new Item()
            {
                ItemName = "Chocolate cake",
                ItemPrice = 175,
                ItemDescription = "A piece of chocolate cake.",
                ItemContents = "chocolate, flour, eggs, milk, cream, sugar, whipped cream",
                ItemAvailability = true,
                CategoryId = 7
            });
            
            context.Items.Add(new Item()
            {
                ItemName = "Hazelnut mousse",
                ItemPrice = 165,
                ItemDescription = "A serving of hazelnut mousse.",
                ItemContents = "chocolate, hazelnuts, eggs, milk, cream, sugar, whipped cream",
                ItemAvailability = true,
                CategoryId = 7
            });
            
            context.Items.Add(new Item()
            {
                ItemName = "Pinot Noir",
                ItemPrice = 125,
                ItemDescription = "A 175 ml glass of Pinot Noir wine.",
                ItemContents = "Pinot Noir wine",
                ItemAvailability = true,
                CategoryId = 8
            });
            
            context.Items.Add(new Item()
            {
                ItemName = "Syrah",
                ItemPrice = 135,
                ItemDescription = "A 175 ml glass of Syrah wine.",
                ItemContents = "Syrah wine",
                ItemAvailability = false,
                CategoryId = 8
            });
            
            context.Items.Add(new Item()
            {
                ItemName = "Stellato pizza",
                ItemPrice = 320,
                ItemDescription = "Stellato pizza.",
                ItemContents = "ham, cheese, mushrooms, tomato sauce, oregano, sour cream",
                ItemAvailability = true,
                CategoryId = 9
            });
            
            context.Items.Add(new Item()
            {
                ItemName = "Quattro stagioni pizza",
                ItemPrice = 360,
                ItemDescription = "Quattro stagioni pizza.",
                ItemContents = "ham, cheese, mushrooms, olives, prosciutto, bacon, tomato sauce, oregano",
                ItemAvailability = true,
                CategoryId = 9
            });
            
            context.Items.Add(new Item()
            {
                ItemName = "Coca-Cola",
                ItemPrice = 80,
                ItemDescription = "A 250ml bottle of Coca-Cola.",
                ItemContents = "Coca-Cola",
                ItemAvailability = true,
                CategoryId = 10
            });
            
            context.Items.Add(new Item()
            {
                ItemName = "Sprite",
                ItemPrice = 80,
                ItemDescription = "A 250ml bottle of Sprite.",
                ItemContents = "Sprite",
                ItemAvailability = true,
                CategoryId = 10
            });
            
            base.Seed(context);
        }
    }
}