using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Exercise_5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please, give names and birth year of a person. Empty input will stop the input.");
            List<Tuple<int, string>> personInfo = new List<Tuple<int, string>>();
            while (true)
            {
                string info = Console.ReadLine();
                if (info != "")
                {
                string[] allInfo = info.Split(',');
                string name = allInfo[1];
                
                personInfo.Add(new Tuple<int, string>(2023 - Int32.Parse(allInfo[1]), (allInfo[0])));
                }
                else { break; }
            }
            personInfo.Sort();
            Console.WriteLine($"{personInfo.Count()} names were given.");
            foreach (var i in personInfo)
            {
                Console.WriteLine($"{i.Item2} is {i.Item1} years old.");
            }
        }
    }
}
