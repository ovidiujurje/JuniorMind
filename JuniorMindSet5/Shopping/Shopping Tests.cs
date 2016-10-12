using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Shopping
{
    [TestClass]
    public class ShoppingTests
    {
        [TestMethod]
        public void ShouldCalculateTotal()
        {
            var cart = new Product[] { new Product("Milk", 6), new Product("Eggs", 10), new Product("Butter", 4) };
            Assert.AreEqual(20, CalculateTotalCost(cart)); 
        }
        [TestMethod]
        public void ShouldGetCheapest()
        {
            var cart = new Product[] { new Product("Milk", 6), new Product("Eggs", 10), new Product("Butter", 4) };
            Assert.AreEqual("Butter", GetCheapestProduct(cart));
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
        string GetCheapestProduct(Product[] cart)
        {
            string cheapest = cart[0].name;
            for (int i = 1; i < cart.Length; i++)
                if (cart[i].price <= cart[i - 1].price)
                    cheapest = cart[i].name;
            return cheapest;
        }
    }
}
