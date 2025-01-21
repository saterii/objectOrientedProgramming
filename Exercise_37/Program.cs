using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise_37
{
    public class Dice
    {
        Random Rnd = new Random();
        public int Result
        {
            get { return Rnd.Next(1, 7); }
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Dice dice = new Dice();
            Console.WriteLine($"Dice is thrown once, result is {dice.Result}");
            Console.WriteLine("How many times do you want to throw the dice?");
            Console.Write("Throws: ");
            string throws2 = Console.ReadLine();
            try
            {
                int iterations2 = 0;
                int throwsInt2 = Int32.Parse(throws2);
                int[] diceResults2 = new int[throwsInt2];
                for (int i = 0; i < throwsInt2; i++)
                {
                    iterations2++;
                    diceResults2[i] = dice.Result;
                }
                Console.WriteLine($"Dice were thrown {iterations2} times, average is {diceResults2.Average()}");
            }
            catch { Console.WriteLine("Please enter an integer!"); }
            Console.WriteLine("How many times do you want to throw the dice?");
            Console.Write("Throws: ");
            string throws = Console.ReadLine();
            try
            {
                int iterations = 0;
                int throwsInt = Int32.Parse(throws);
                int[] diceResults = new int[throwsInt];
                for (int i = 0; i < throwsInt; i++)
                {
                    iterations++;
                    diceResults[i] = dice.Result;
                }
                var query = diceResults.GroupBy(r => r)
                    .Select(grp => new
                    {
                        Value = grp.Key,
                        Count = grp.Count()
                    })
                    .OrderBy(grp => grp.Value);
                var queryOnes = query.Select(grp => new { Value = 1 });
                var queryTwos = query.Select(grp => new { Value = 2 });
                var queryThrees = query.Select(grp => new { Value = 3 });
                var queryFours = query.Select(grp => new { Value = 4 });
                var queryFives = query.Select(grp => new { Value = 5 });
                var querySixes = query.Select(grp => new { Value = 6 });
                Console.WriteLine($"Dice was thrown {iterations} times.");
                Console.WriteLine($"- Average is {diceResults.Average()}");
                foreach(var item in query)
                {
                    Console.WriteLine($"- {item.Value} count is {item.Count}");
                }
            }
            catch { Console.WriteLine("Please enter an integer!"); }
            
        }
    }
}
