using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace Exercise_36
{
    internal class Program
    {
        public class Item
        {
            public string Name { get; set; }
            public double Price { get; set; }
            public int Quantity { get; set; }
            public double Total { get { return Price * Quantity; } }
            public string ItemToString()
            {
                return $"{Name}: {Quantity} x {Price}e, total: {Total}e";
            }
        }
        public class Invoice
        {
            public string Customer { get; set; }
            public List<Item> Items { get; set; }
            public int ItemsCount { get { return Items.Count(); } }
            public int ItemsTogether
            {
                get
                {
                    int count = 0;
                    foreach (Item item in Items)
                    {
                        count += item.Quantity;
                    }
                    return count;
                }
            }
            public double CountTotal
            {
                get
                {
                    double total = 0;
                    foreach (Item item in Items)
                    {
                        total += item.Total;
                    }
                    return total;
                }
            }
        }
        private static void PrintInvoice(Invoice invoice)
        {
            Console.WriteLine($"Customer {invoice.Customer}'s invoice:");
            Console.WriteLine("=======================================");
            foreach (Item item in invoice.Items)
            {
                Console.WriteLine(item.ItemToString());
            }
            Console.WriteLine("=======================================");
            Console.WriteLine($"Total: {invoice.ItemsTogether} items, {invoice.CountTotal} euros.");
        }
        static void Main(string[] args)
        {
            Item item1 = new Item() { Name = "Milk", Price = 1.35, Quantity = 2 };
            Item item2 = new Item() { Name = "Minced meat", Price = 2.75, Quantity = 1 };
            Item item3 = new Item() { Name = "Book: The Winds of Winter", Price = 25.59, Quantity = 0 };
            Item item4 = new Item() { Name = "Butter", Price = 3.49, Quantity = 1 };
            Item item5 = new Item() { Name = "Coca-Cola 0.33l", Price = 1.09, Quantity = 15 };
            List <Item> items = new List<Item>() { item1, item2, item3, item4, item5 };
            Invoice invoice = new Invoice() { Customer = "Sampsa Tervo", Items = items };

            PrintInvoice(invoice);
        }
    }
}
