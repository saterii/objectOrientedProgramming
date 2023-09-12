using System;
using System.Collections.Generic;
using System.Linq;

namespace Exercise_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] scores = { };
            for (int i = 0; i < 5; i++)
            {
                    Console.Write("Enter score: ");
                    scores[i] = Convert.ToInt32(Console.ReadLine());
                
            }
            var small = scores[0];
            var big = scores[0];
            var result = 0;
            for(var i = 0; i < scores.Length; i++)
            {
                if (scores[i] < small)
                {
                    small = scores[i];
                }
                if (scores[i] > big)
                {
                    big = scores[i];
                }
            }
            scores = scores.Where(val => val != small).ToArray();
            scores = scores.Where(val => val != big).ToArray();
            for (var i = 0; i < scores.Length; i++)
            {
                result += scores[i];
            }
            Console.WriteLine($"Total points: {result}.");
        }
    }
}
