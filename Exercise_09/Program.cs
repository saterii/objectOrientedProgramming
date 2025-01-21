using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise_9
{
    public class Vehicle
    {
        // Properties
        public string Brand { get; set; }
        public string Model { get; set; }
        public int Speed { get; set; }
        public int Tires { get; set; }

        // Methods

        public string ShowInfo()
        {
            return $"{Brand} {Model}";
        }

        public override string ToString()
        {
            return $"{Brand} {Model}, Speed: {Speed} km/h, Tires: {Tires}";
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Vehicle vehicle1 = new Vehicle();
            Vehicle vehicle2 = new Vehicle();
            vehicle1.Brand = "Audi";
            vehicle1.Model = "A4";
            vehicle1.Speed = 170;
            vehicle1.Tires = 4;

            vehicle2.Brand = "Yamaha";
            vehicle2.Model = "DT";
            vehicle2.Speed = 45;
            vehicle2.Tires = 2;

            Console.WriteLine(vehicle1.ToString());
            Console.WriteLine(vehicle2.ToString());
        }
    }
}
