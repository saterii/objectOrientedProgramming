using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Populating the list with Human objects takes about 9-11 milliseconds, while populating the dict takes about 12-14 milliseconds
// So in this case creating a list is faster than creating a dict because the dict needs to check for duplicates and add more data,
// But finding items in the dict blows the list out of the water, with an average of 175ms to find matches in the list vs. under a millisecond for the dict
// This is because when looking for items in the list, it needs to go through the whole list, and that is not the case for a dictionary.

namespace Exercise_31
{
    public class Human
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
    internal class Program
    {
        static void ListRandom()
        {
            // List implementation

            List<Human> people = new List<Human>();
            var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            var random = new Random();
            Stopwatch clock = Stopwatch.StartNew();

            for (int i = 0; i < 10000; i++)
            {
                var firstNameString = "";
                var lastNameString = "";
                for (int j = 0; j < 4; j++)
                {
                    firstNameString += chars[random.Next(chars.Length)];
                }
                for (int j = 0; j < 10; j++)
                {
                    lastNameString += chars[random.Next(chars.Length)];
                }
                people.Add(new Human() { FirstName = firstNameString, LastName = lastNameString });
            }
            clock.Stop();
            Console.WriteLine("List Collection: ");
            Console.WriteLine("- Time elapsed: " + clock.ElapsedMilliseconds + "ms");
            Console.WriteLine("- Persons count: " + people.Count());
            Console.WriteLine();
            Console.WriteLine("Finding persons in list collection by first name: ");
            List<Human> matches = new List<Human>();
            var iterations = 0;
            Stopwatch clock2 = Stopwatch.StartNew();
            for (int i = 0; i < 1000; i++)
            {
                iterations++;
                var randomFirstName = "";
                for (int j = 0; j < 4; j++)
                {
                    randomFirstName += chars[random.Next(chars.Length)];
                }
                matches.AddRange(people.Where(x => x.FirstName == randomFirstName).ToList());
            }
            clock2.Stop();
            foreach (var match in matches)
            {
                Console.WriteLine(match.FirstName + " " + match.LastName);
            }
            Console.WriteLine("Found " + matches.Count() + " matches in " + iterations + " checks.");
            Console.WriteLine("- Time elapsed: " + clock2.ElapsedMilliseconds + "ms");
        }

        static void DictRandom()
        {
            var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            var random = new Random();
            IDictionary<string, Human> peopleDict = new Dictionary<string, Human>();
            Stopwatch clock = Stopwatch.StartNew();

            for (int i = 0; i < 10000; i++)
            {
                var firstNameString = "";
                var lastNameString = "";
                for (int j = 0; j < 4; j++)
                {
                    firstNameString += chars[random.Next(chars.Length)];
                }
                for (int j = 0; j < 10; j++)
                {
                    lastNameString += chars[random.Next(chars.Length)];
                }

                while (peopleDict.ContainsKey(firstNameString))
                {
                    firstNameString = "";
                    for (int j = 0; j < 4; j++)
                    {
                        firstNameString += chars[random.Next(chars.Length)];
                    }
                }

                peopleDict.Add(firstNameString, new Human() { FirstName = firstNameString, LastName = lastNameString });
            }
            clock.Stop();
            Console.WriteLine();
            Console.WriteLine("Dictionary Collection: ");
            Console.WriteLine("- Time elapsed: " + clock.ElapsedMilliseconds + "ms");
            Console.WriteLine("- Persons count: " + peopleDict.Count());
            Console.WriteLine();
            Console.WriteLine("Finding persons in dictionary collection by first name: ");
            IDictionary<int, Human> matches = new Dictionary<int, Human>();
            var iterations = 0;

            Stopwatch clock2 = Stopwatch.StartNew();
            for (int i = 0; i < 1000; i++)
            {
                iterations++;
                var randomFirstName = "";
                for (int j = 0; j < 4; j++)
                {
                    randomFirstName += chars[random.Next(chars.Length)];
                }
                if (peopleDict.TryGetValue(randomFirstName, out var person))
                {
                    matches.Add(i, person);
                }
            }
            clock2.Stop();
            foreach (var match in matches)
            {
                Console.WriteLine(match.Value.FirstName + " " + match.Value.LastName);
            }
            Console.WriteLine("Found " + matches.Count() + " matches in " + iterations + " checks.");
            Console.WriteLine("- Time elapsed: " + clock2.ElapsedMilliseconds + "ms");
        }

        static void Main(string[] args)
        {
            ListRandom();
            DictRandom();
        }
    }
}
