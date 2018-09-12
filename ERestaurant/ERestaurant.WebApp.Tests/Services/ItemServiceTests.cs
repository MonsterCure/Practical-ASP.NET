using ERestaurant.BL.Model;
using ERestaurant.BL.Service;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERestaurant.WebApp.Tests.Services
{
    [TestClass]
    public class ItemServiceTests
    {
        [TestMethod]
        public void AddItem_ValidInput_ExpectTwoItems()
        {
            //Act
            //add categories first if none exist in the database!!!
            //DtoCategory category1 = new DtoCategory()
            //{
            //    MenuId = 1,
            //    CategoryName = "Salads"
            //};

            //DtoCategory category2 = new DtoCategory()
            //{
            //    MenuId = 2,
            //    CategoryName = "Sodas"
            //};

            //DtoCategory category3 = new DtoCategory()
            //{
            //    MenuId = 3,
            //    CategoryName = "Sandwiches"
            //};

            DtoItem item1 = new DtoItem()
            {
                ItemName = "Sandwich",
                ItemPrice = 120,
                ItemDescription = "Tuna sandwich",
                ItemContents = "Bread, tuna, sesame, mayonnaise",
                ItemAvailability = true,
                CategoryId = 3
            };

            DtoItem item2 = new DtoItem()
            {
                ItemName = "Caesar salad",
                ItemPrice = 140,
                ItemDescription = "Caesar salad",
                ItemContents = "Chicken meat, iceberg salad, carrots, cheese, sauce",
                ItemAvailability = true,
                CategoryId = 1
            };

            DtoItem item3 = new DtoItem()
            {
                ItemName = "Coca-Cola",
                ItemPrice = 40,
                ItemDescription = "Coca-Cola",
                ItemContents = "Coca-Cola soda drink",
                ItemAvailability = true,
                CategoryId = 2
            };

            //Arrange
            var itemService = new ItemService();
            var result1 = itemService.Add(item1); // will add them to the database each time the test is run, and the entries are repeated
            var result2 = itemService.Add(item2);
            var result3 = itemService.Add(item3);
            var resultItems = itemService.LoadAll();

            //Assert
            Assert.IsNotNull(result1);
            Assert.IsTrue(result1.Success);
            Assert.IsNotNull(result2);
            Assert.IsTrue(result2.Success);
            Assert.IsNotNull(result3);
            Assert.IsTrue(result3.Success);
            Assert.IsNotNull(resultItems);
            Assert.IsTrue(resultItems.Success);
            Assert.IsNotNull(resultItems.ListItems);
            //Assert.AreEqual(2, resultItems.ListItems.Count);
            Assert.IsTrue(resultItems.ListItems.Count >= 3); // since test method adds the same entries to the database, here we check if there are at least 2 created
        }
    }
}
