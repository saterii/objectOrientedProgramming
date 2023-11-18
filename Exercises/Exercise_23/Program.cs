using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise_23
{
    internal class Program
    {
        public class CheckoutQueue
        {
            public Queue<string> Customers;
            public CheckoutQueue() { Customers = new Queue<string>();}

            public Queue<String> EnterQueue(Queue<String> queue, String Customer)
            {
                queue.Enqueue(Customer);
                return queue;
            }
            public string ServeCustomer(Queue<String> queue)
            {
                return Customers.Dequeue();
            }
            public int GetQueueLength(CheckoutQueue queue)
            {
                return queue.Customers.Count();
            }
        }
        static void Main(string[] args)
        {
            CheckoutQueue queue = new CheckoutQueue();
            while(true)
            {
                Console.WriteLine("Enter the name of the person entering the queue (Enter stops): ");
                string customer = Console.ReadLine();
                if(customer == "") { break; }
                else { queue.Customers.Enqueue(customer); }
            }
            Console.WriteLine($"Queue has {queue.GetQueueLength(queue)} customers: ");
            foreach(string c in queue.Customers) { Console.WriteLine(c); }
            while(queue.Customers.Count != 0)
            {
                Console.WriteLine($"----- Serving customer {queue.Customers.Peek()}... -----");
                queue.Customers.Dequeue();
            }
            Console.WriteLine("All customers have been served.");
        }
    }
}
