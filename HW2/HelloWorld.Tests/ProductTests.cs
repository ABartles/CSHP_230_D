using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using HelloWorld.Models;    // Added
using HelloWorld.Controllers;   // Added
using Moq;  // Added for use of Moq testing Method
using System.Linq; // Added for use of Moq testing Method

namespace HelloWorld.Tests
{
    [TestClass]
    public class ProductTests
    {
        // Test Method using the "FakeProductRepository"
        [TestMethod]
        public void TestMethodWithFakeClass()
        {
            // Arrange
            var controller = new HomeController(new FakeProductRepository());

            // Act
            var result = controller.Products();

            // Assert
            var products = (Product[])((System.Web.Mvc.ViewResultBase)(result)).Model;
            Assert.AreEqual(4, products.Length, "Length is invalid");
        }

        // Test method using  Moq
        [TestMethod]
        public void TestMethodWithMoq()
        {
            var mockProductRepository = new Mock<IProductRepository>();
            mockProductRepository
                .SetupGet(t => t.Products)
                .Returns(() =>
                {
                    return new Product[]{
                new Product{Name="Baseball", Price = 11},
                new Product{Name="Football", Price = 8},
                new Product{Name="Tennis Ball", Price = 13},
                new Product{Name="Golf Ball", Price = 3},
                new Product{Name="Ping Pong Ball", Price = 12}
                    };
                });

            // Arrange
            var controller = new HomeController(mockProductRepository.Object);

            // Act
            var result = controller.Products();

            // Assert
            var products = (Product[])((System.Web.Mvc.ViewResultBase)(result)).Model;
            Assert.AreEqual(5, products.Length, "Length is invalid");
            Assert.AreEqual(3, products.Where(t =>t.Price > 10).Count(), "Should have 3 prod > $10");
            Assert.AreEqual(2, products.Where(t => t.Price < 10).Count(), "Should have 2 prod < $10");
        }
    }
}
