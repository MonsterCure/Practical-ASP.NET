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
    public class CategoryServiceTests
    {
        [TestMethod]
        public void AddCategory_ValidInput_ExpectTwoItems()
        {
            //Act
            //add menus first if none exist in the database!!!
            //DtoMenu menu1 = new DtoMenu()
            //{
            //    TypeEnum = MenuType.Meals,
            //    RestaurantName = "Seavus Restaurant"
            //};

            //DtoMenu menu2 = new DtoMenu()
            //{
            //    TypeEnum = MenuType.Drinks,
            //    RestaurantName = "Seavus Restaurant"
            //};

            DtoCategory category1 = new DtoCategory()
            {
                MenuId = 1,
                CategoryName = "Salads"
            };

            DtoCategory category2 = new DtoCategory()
            {
                MenuId = 2,
                CategoryName = "Sodas"
            };

            DtoCategory category3 = new DtoCategory()
            {
                MenuId = 1,
                CategoryName = "Sandwiches"
            };

            //Arrange
            var categoryService = new CategoryService();
            var result1 = categoryService.Add(category1); // will add them to the database each time the test is run, and the entries are repeated
            var result2 = categoryService.Add(category2);
            var result3 = categoryService.Add(category3);
            var resultCategories = categoryService.LoadAll();

            //Assert
            Assert.IsNotNull(result1);
            Assert.IsTrue(result1.Success);
            Assert.IsNotNull(result2);
            Assert.IsTrue(result2.Success);
            Assert.IsNotNull(result3);
            Assert.IsTrue(result3.Success);
            Assert.IsNotNull(resultCategories);
            Assert.IsTrue(resultCategories.Success);
            Assert.IsNotNull(resultCategories.ListItems);
            //Assert.AreEqual(2, resultCategories.ListItems.Count);
            Assert.IsTrue(resultCategories.ListItems.Count >= 3); // since test method adds the same entries to the database, here we check if there are at least 3 created
        }
    }
}
