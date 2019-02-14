using System;
using DL.ModernStore.Domain.Entities;
using DL.ModernStore.Domain.ValueObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DL.ModernStore.Domain.Tests
{
    [TestClass]
    public class OrderTest
    {
        private readonly Customer _customer = new Customer(new Name("Diego", "Longhi"), 
                                                            new Document("90909000") ,
                                                            new Email("andrebaltieri@hotmail.com"),
                                                            null,
                                                            new User("andrebaltieri", "andrebaltieri"));


        [TestMethod]
        [TestCategory("Order - New Order")]
        public void GivenAnOutOfStockProductItShouldReturnAnError()
        {
            var mouse = new Product("Mouse", 299, 0, "mouse.jpg");

            var order = new Order(_customer, 8, 10);
            order.AddItem(new OrderItem(mouse, 2));

            Assert.IsFalse(order.Valid);
        }

        [TestMethod]
        [TestCategory("Order - New Order")]
        public void GivenAnInStockProductItShouldUpdateQuantityOnHand()
        {
            var mouse = new Product("Mouse", 299, 20, "mouse.jpg");

            var order = new Order(_customer, 8, 10);
            order.AddItem(new OrderItem(mouse, 2));

            Assert.IsTrue(mouse.QuantityOnHand == 18);
        }

        [TestMethod]
        [TestCategory("Order - New Order")]
        public void GivenAValidOrderTheTotalShouldBe310()
        {
            var mouse = new Product("Mouse", 300, 20, "mouse.jpg");

            var order = new Order(_customer, 12, 2);
            order.AddItem(new OrderItem(mouse, 1));

            Assert.IsTrue(order.Total() == 310);
        }
    }
}
