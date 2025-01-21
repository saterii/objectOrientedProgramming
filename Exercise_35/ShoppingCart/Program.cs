using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCart
{
    public class Product
    {
        public string Name { get; set; }
        public double Price { get; set; }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Product product1 = new Product() { Name = "Milk", Price = 1.24 };
            Product product2 = new Product() { Name = "Butter", Price = 3.79 };
            Product product3 = new Product() { Name = "Cheese", Price = 5.14 }; 
            Product product4 = new Product() { Name = "Bread", Price = 2.29 };
            Product product5 = new Product() { Name = "Coke", Price = 2.19 };
            List<Product> products = new List<Product> { product1, product2, product3, product4, product5 };
            Console.WriteLine("Your items in shopping cart:");
            foreach(Product product in products)
            {
                Console.WriteLine($"- Item: {product.Name} {product.Price}e");
            }
            Console.WriteLine($"There are {products.Count} items in the shopping cart");
        }
    }
}
