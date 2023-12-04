using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// NOTE: I don't know if this program was supposed to be interactive, but this at least prints out the same data as in the example.

namespace Exercise_41
{
    public class Fisher
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public List<Fish> CaughtFish { get; set; }

        public Fisher()
        {
            CaughtFish = new List<Fish>();
        }
    }
    public class Fish
    {
        public int Length { get; set; }
        public string Species { get; set; }
        public double Weight { get; set; }
        public Place PlaceCaught { get; set; }
        public Fish()
        {
            PlaceCaught = new Place();
        }
    }
    public class Place
    {
        public string Name { get; set; }
        public string Location { get; set; }
    }
    internal class MyFishRegister
    {
        static void Main(string[] args)
        {
            List<Fisher> fishers = new List<Fisher>();
            List<Fish> fishList = new List<Fish>();
            Fisher fisher1 = new Fisher() { FirstName = "Kirsi", LastName = "Kernel", Phone = "010-32454345" };
            Fisher fisher2 = new Fisher() { FirstName = "Keijo", LastName = "Kernel", Phone = "020-43287623" };
            Fisher fisher3 = new Fisher() { FirstName = "Jon", LastName = "Connington", Phone = "050-23491843" };
            fishers.Add(fisher1);
            fishers.Add(fisher2);
            fishers.Add(fisher3);
            Console.WriteLine("New fishers added to register: ");
            foreach (Fisher f in fishers)
            {
                Console.WriteLine($"- Fisher: {f.FirstName} {f.LastName} Phone: {f.Phone}");
            }
            Place place1 = new Place() { Name = "River Teno", Location = "Northern Finland"};
            Place place2 = new Place() { Name = "Lake Jyväskylä", Location = "Central Finland, Jyväskylä" };
            Place place3 = new Place() { Name = "Kalajoki river", Location = "Northern Ostrobothnia" };
            Fish fish1 = new Fish() { Species = "Salmon", Length = 64, Weight = 4.52, PlaceCaught = place1};
            Fish fish2 = new Fish() { Species = "Salmon", Length = 93, Weight = 8.41, PlaceCaught = place1};
            Fish fish3 = new Fish() { Species = "Perch", Length = 23, Weight = 1.42, PlaceCaught = place2};
            Fish fish4 = new Fish() { Species = "Pike", Length = 113, Weight = 9.87, PlaceCaught = place3};
            Fish fish5 = new Fish() { Species = "Perch", Length = 31, Weight = 2.24, PlaceCaught = place2};
            Console.WriteLine();
            fisher1.CaughtFish.Add( fish1 ); Console.WriteLine($"Fisher {fisher1.FirstName} {fisher1.LastName} caught a new fish:");
            Console.WriteLine($"- Species: {fish1.Species} {fish1.Length}cm {fish1.Weight}kg");
            Console.WriteLine($"- Place: {fish1.PlaceCaught.Name}");
            Console.WriteLine($"- Location: {fish1.PlaceCaught.Location}");
            Console.WriteLine();
            fisher1.CaughtFish.Add(fish2); Console.WriteLine($"Fisher {fisher1.FirstName} {fisher1.LastName} caught a new fish:");
            Console.WriteLine($"- Species: {fish2.Species} {fish2.Length}cm {fish2.Weight}kg");
            Console.WriteLine($"- Place: {fish2.PlaceCaught.Name}");
            Console.WriteLine($"- Location: {fish2.PlaceCaught.Location}");
            Console.WriteLine();
            fisher2.CaughtFish.Add(fish3); Console.WriteLine($"Fisher {fisher2.FirstName} {fisher2.LastName} caught a new fish:");
            Console.WriteLine($"- Species: {fish3.Species} {fish3.Length}cm {fish3.Weight}kg");
            Console.WriteLine($"- Place: {fish3.PlaceCaught.Name}");
            Console.WriteLine($"- Location: {fish3.PlaceCaught.Location}");
            Console.WriteLine();
            fisher2.CaughtFish.Add(fish4); Console.WriteLine($"Fisher {fisher2.FirstName} {fisher2.LastName} caught a new fish:");
            Console.WriteLine($"- Species: {fish4.Species} {fish4.Length}cm {fish4.Weight}kg");
            Console.WriteLine($"- Place: {fish4.PlaceCaught.Name}");
            Console.WriteLine($"- Location: {fish4.PlaceCaught.Location}");
            Console.WriteLine();
            fisher3.CaughtFish.Add(fish5); Console.WriteLine($"Fisher {fisher3.FirstName} {fisher3.LastName} caught a new fish:");
            Console.WriteLine($"- Species: {fish5.Species} {fish5.Length}cm {fish5.Weight}kg");
            Console.WriteLine($"- Place: {fish5.PlaceCaught.Name}");
            Console.WriteLine($"- Location: {fish5.PlaceCaught.Location}");
            Console.WriteLine();
            Console.WriteLine("All fish in register: ");
            foreach(Fisher f in fishers)
            {
                Console.WriteLine($"{f.FirstName} {f.LastName} has got the following fish:");
                int number = 1;
                foreach (Fish fish in f.CaughtFish)
                {
                    fishList.Add(fish);
                    Console.WriteLine($"{number}) {fish.Species} {fish.Length}cm {fish.Weight}kg at {fish.PlaceCaught.Name}, {fish.PlaceCaught.Location}");
                    number++;
                }
            }
            Console.WriteLine();
            Console.WriteLine("All fish in register (sorted): ");
            fishList = fishList.OrderByDescending(x => x.Weight).ToList();
            int number2 = 1;
            foreach (Fish fish in fishList)
            {
                var caughtBy = from fisher in fishers
                               where fisher.CaughtFish.Contains(fish)
                               select fisher;
                Fisher currentFisher = new Fisher();
                foreach(Fisher f in caughtBy)
                {
                    currentFisher.FirstName = f.FirstName;
                    currentFisher.LastName = f.LastName;
                    currentFisher.Phone = f.Phone;
                }
                Console.WriteLine($"{number2}) {fish.Species} {fish.Length}cm {fish.Weight}kg at {fish.PlaceCaught.Name}, {fish.PlaceCaught.Location} by {currentFisher.FirstName} {currentFisher.LastName}"); 
                number2++;
            }
        }
    } 
    
}
