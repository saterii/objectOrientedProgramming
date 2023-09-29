using System;
using System.Collections.Generic;
using System.Linq;

namespace Exercise_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] scores = new int[5];
            for (int i = 0; i < 5; i++)
            {
                    Console.Write("Enter score: ");
                    scores[i] = Convert.ToInt32(Console.ReadLine());
            }
            var result = scores.Sum() - scores.Min() - scores.Max();
            Console.WriteLine($"Total points: {result}.");
        }
    }
}
 