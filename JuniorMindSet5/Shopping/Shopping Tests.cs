using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Shopping
{
    [TestClass]
    public class ShoppingTests
    {
        [TestMethod]
        public void CalculateTotal()
        {
            var cart = new Product[] { new Product("Milk", 6), new Product("Eggs", 10), new Product("Butter", 4) };
            Assert.AreEqual(20, CalculateTotalCost(cart)); 
        }
        public struct Product
        {
            public string name;
            public double price;
            public Product(string name, double price)
            {
                this.name = name;
                this.price = price;
            }
        }
        double CalculateTotalCost(Product[] cart)
        {
            double total = 0;
            for (int i = 0; i < cart.Length; i++)
                total += cart[i].price;
            return total;
        }
    }
}
