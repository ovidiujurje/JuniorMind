﻿using System;
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
            Assert.AreEqual(new Product("Butter", 4), GetCheapestProduct(cart));
        }
        [TestMethod]
        public void ShouldRemoveMostExpensive()
        {
            var cart = new Product[] { new Product("Milk", 6), new Product("Eggs", 10), new Product("Butter", 4) };
            CollectionAssert.AreEqual(new Product[] { new Product("Milk", 6), new Product("Butter", 4) }, RemoveMostExpensiveProduct(cart));
        }
        [TestMethod]
        public void ShouldAddProduct()
        {
            var cart = new Product[] { new Product("Milk", 6), new Product("Eggs", 10), new Product("Butter", 4) };
            CollectionAssert.AreEqual(new Product[] { new Product("Milk", 6), new Product("Eggs", 10), new Product("Butter", 4), new Product("Bread", 2) }, AddProduct(cart, new Product("Bread", 2) ));
        }
        [TestMethod]
        public void ShouldCalculateMean()
        {
            var cart = new Product[] { new Product("Milk", 6), new Product("Eggs", 10), new Product("Butter", 5) };
            Assert.AreEqual(7, CalculateMeanPrice(cart));
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
        public enum PriceType { Cheapest, MostExpensive }
        double CalculateTotalCost(Product[] cart)
        {
            double total = 0;
            for (int i = 0; i < cart.Length; i++)
                total += cart[i].price;
            return total;
        }
        Product GetCheapestProduct(Product[] cart)
        {
            Product cheapest = GetCheapestOrMostExpensive(cart, PriceType.Cheapest);
            return cheapest;
        }
        Product[] RemoveMostExpensiveProduct(Product[] cart)
        {
            Product[] newCart = new Product[cart.Length - 1];
            Product mostExpensive = GetCheapestOrMostExpensive(cart, PriceType.MostExpensive);
            int place = 0;
            for (int i = 0; i < cart.Length; i++)
            {
                if (cart[i].name != mostExpensive.name)
                {
                    newCart[place] = cart[i];
                    place += 1;
                }
            }
            return newCart;
        }
        private static Product GetCheapestOrMostExpensive(Product[] cart, PriceType cheapestOrMostExpensive)
        {
            Product result = cart[0];
            for (int i = 1; i < cart.Length; i++)
                switch (cheapestOrMostExpensive)
                {
                    case PriceType.Cheapest:
                        if (cart[i].price <= cart[i - 1].price)
                            result = cart[i];
                        break;
                    case PriceType.MostExpensive:
                        if (cart[i].price >= cart[i - 1].price)
                            result = cart[i];
                        break;
                }
            return result;
        }
        Product[] AddProduct(Product[] cart, Product newProduct)
        {
            Array.Resize(ref cart, cart.Length + 1);
            cart[cart.Length - 1] = newProduct;
            return cart;
        }
        double CalculateMeanPrice(Product[] cart)
        {
            return CalculateTotalCost(cart) / cart.Length;
        }
    }
}
