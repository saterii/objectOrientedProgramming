using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise_3
{
    internal class Program
    {
        static (float, float) calcConsumption(float distance)
        {
            Random rnd = new Random();
            double gasPriceTemp = (rnd.NextDouble() * 0.75) + 1.75;
            float gasPrice = (float)gasPriceTemp;
            float consumption = rnd.Next(6, 10);
            return ((distance / 100) * consumption, gasPrice * (distance / 100) * consumption);
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Enter traveled distance: ");
            int distance = Convert.ToInt32(Console.ReadLine());
            float distanceFloat = (float)distance;
            float totalConsumption = calcConsumption(distanceFloat).Item1;
            float gasPrice = calcConsumption(distanceFloat).Item2;
            decimal gasDecimal = Math.Round((decimal)gasPrice, 2);
            Console.WriteLine($"Fuel consumption is {totalConsumption} liters and it costs {gasDecimal} euros.");
        }

    }
}
