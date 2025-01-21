using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using ShoppingCart;
using System.Collections.Generic;

namespace UnitTestShoppingCart
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestEmptyList()
        {
            List<Product> products = new List<Product>();
            int expected = 0;
            int actual = products.Count;
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void TestOneItem()
        {
            Product product1 = new Product() { Name = "Milk", Price = 1.24 };

            List<Product> products = new List<Product> { product1 };
            int expected = 1;
            int actual = products.Count;
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void TestTwoItems()
        {
            Product product1 = new Product() { Name = "Milk", Price = 1.24 };
            Product product2 = new Product() { Name = "Butter", Price = 3.79 };
            
            List<Product> products = new List<Product> { product1, product2 };
            int expected = 2;
            int actual = products.Count;
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void TestFiveItems()
        {
            Product product1 = new Product() { Name = "Milk", Price = 1.24 };
            Product product2 = new Product() { Name = "Butter", Price = 3.79 };
            Product product3 = new Product() { Name = "Cheese", Price = 5.14 };
            Product product4 = new Product() { Name = "Bread", Price = 2.29 };
            Product product5 = new Product() { Name = "Coke", Price = 2.19 };
            List<Product> products = new List<Product> { product1, product2, product3, product4, product5 };
            int expected = 5;
            int actual = products.Count;
            Assert.AreEqual(expected, actual);
        }
    }
}
