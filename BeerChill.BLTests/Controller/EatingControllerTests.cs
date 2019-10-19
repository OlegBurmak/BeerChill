using BeerChill.BL.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;

namespace BeerChill.BL.Controller.Tests
{
    [TestClass()]
    public class EatingControllerTests
    {
        [TestMethod()]
        public void AddEatingTest()
        {

            // Arrange
            var userName = Guid.NewGuid().ToString();
            var foodName = Guid.NewGuid().ToString();
            var rnd = new Random();
            var userController = new UserController(userName);
            var eatingController = new EatingController(userController.CurrentUser);
            var food = new Food(foodName, rnd.Next(50, 500), rnd.Next(50, 500), rnd.Next(50, 500), rnd.Next(50, 500));

            // Act
            eatingController.AddEating(food, 100);

            // Assert
            Assert.AreEqual(food.Name, eatingController.Foods.SingleOrDefault(f => f.Name == food.Name).ToString());

        }
    }
}