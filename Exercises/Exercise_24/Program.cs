using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise_24
{
    public class Tire
    {
        public string Manufacturer { get; set; }
        public string Model { get; set; }
        public string TireSize { get; set; }
    }
    public class Vehicle
    {
        public string Name { get; set; }
        public string Model { set; get; }
        public int Year { get; set; }
        public int TireAmount { get { return Tires.Count(); } }
        public List<Tire> Tires { get; set;}

    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Vehicle car = new Vehicle() { Name = "Volkswagen", Model = "Passat", Year = 1999 };
            car.Tires = new List<Tire>();
            Console.WriteLine($"Created a new vehicle {car.Name} {car.Model} {car.Year}");
            for (int i = 0; i < 4; i++)
            {
                Tire tire = new Tire() { Manufacturer = "Nokia", Model = "Hakkapeliitta", TireSize = "205R16" };
                car.Tires.Add(tire);
                Console.WriteLine($"Tire {tire.Manufacturer} added to vehicle {car.Name}");
            }
            Console.WriteLine("");
            Console.WriteLine($"Vehicle {car.Name} {car.Model} {car.Year} has {car.TireAmount} tires:");
            foreach(Tire tire in car.Tires)
            {
                Console.WriteLine($"-- Name: {tire.Manufacturer}, Model: {tire.Model}, Size: {tire.TireSize}");
            }
            Console.WriteLine("");
            Vehicle moped = new Vehicle() { Name = "Yamaha", Model = "DT", Year = 2004 };
            moped.Tires = new List<Tire>();
            Console.WriteLine($"Created a new vehicle {moped.Name} {moped.Model} {moped.Year}");
            
            Tire tire1 = new Tire() { Manufacturer = "Avon", Model = "Trailrider", TireSize = "110/80-18" };
            moped.Tires.Add(tire1);
            Console.WriteLine($"Tire {tire1.Manufacturer} added to vehicle {moped.Name}");
            Tire tire2 = new Tire() { Manufacturer = "Avon", Model = "Trailrider", TireSize = "130/90-19" };
            moped.Tires.Add(tire2);
            Console.WriteLine($"Tire {tire2.Manufacturer} added to vehicle {moped.Name}");

            Console.WriteLine("");
            Console.WriteLine($"Vehicle {moped.Name} {moped.Model} {moped.Year} has {moped.TireAmount} tires:");
            foreach (Tire tire in moped.Tires)
            {
                Console.WriteLine($"-- Name: {tire.Manufacturer}, Model: {tire.Model}, Size: {tire.TireSize}");
            }
        }
    }
}
