using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter traveled distance: ");
            try
            {
                int distance = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine(distance);
                Console.ReadLine();
            }
            catch
            {
                Console.WriteLine("Input needs to be an integer!");
                Console.ReadLine();
            }

        }
    }
}
