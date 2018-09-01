﻿using System;
using ERestaurant.BL.Model;
using ERestaurant.BL.Service;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ERestaurant.Web.Tests.Services
{
    [TestClass]
    public class MenuServiceTests
    {
        [TestMethod]
        public void AddMenu_ValidInput_ExpectTwoItems()
        {
            //Act
            DtoMenu menu1 = new DtoMenu()
            {
                TypeEnum = MenuType.Meals,
                RestaurantName = "Seavus Restaurant"
            };

            DtoMenu menu2 = new DtoMenu()
            {
                TypeEnum = MenuType.Drinks,
                RestaurantName = "Seavus Restaurant"
            };

            //Arrange
            var menuService = new MenuService();
            var result1 = menuService.Add(menu1);
            var result2 = menuService.Add(menu2);
            var resultMenus = menuService.LoadAll();

            //Assert
            Assert.IsNotNull(result1);
            Assert.IsTrue(result1.Success);
            Assert.IsNotNull(result2);
            Assert.IsTrue(result2.Success);
            Assert.IsNotNull(resultMenus);
            Assert.IsTrue(resultMenus.Success);
            Assert.IsNotNull(resultMenus.ListItems);
            Assert.AreEqual(2, resultMenus.ListItems.Count);
        }
    }
}
