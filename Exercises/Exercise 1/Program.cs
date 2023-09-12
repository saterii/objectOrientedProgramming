using System;

namespace Exercise_1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            while (true) { 
                Console.WriteLine("Give points: ");
                string points = Console.ReadLine();
                try
                {
                    int pointsInt = Int32.Parse(points);
                    if(pointsInt > 0 && pointsInt <= 19)
                    {
                        Console.WriteLine("Your grade is 0.");
                    }
                    else if(pointsInt >= 20 && pointsInt <= 29)
                    {
                        Console.WriteLine("Your grade is 1.");
                    }
                    else if (pointsInt >= 30 && pointsInt <= 39)
                    {
                        Console.WriteLine("Your grade is 2.");
                    }
                    else if (pointsInt >= 40 && pointsInt <= 49)
                    {
                        Console.WriteLine("Your grade is 3.");
                    }
                    else if (pointsInt >= 50 && pointsInt <= 59)
                    {
                        Console.WriteLine("Your grade is 4.");
                    }
                    else if (pointsInt >= 60 && pointsInt <= 70)
                    {
                        Console.WriteLine("Your grade is 5.");
                    }
                    else
                    {
                        Console.WriteLine("Points need to be an integer between 0 and 70!");
                    }
                    Console.ReadLine();
                    Console.Clear();
                }
                catch
                {
                    Console.WriteLine($"Couldn't convert {points} into a string!");
                    Console.ReadLine();
                    Console.Clear();
                }
            }
        }
    }
}
