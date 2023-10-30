using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise_16
{
    public class Vehicle
    {
        // Properties
        public string Name { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public string Color { get; set; }
        // Methods
        public virtual string ShowData()
        {
            return $"- Name: {Name}, Model: {Model}, Year: {Year}, Color: {Color}.";
        }
    }
    public class Bike : Vehicle
    {
        private bool Gears() // Automatically set HasGears to true or false depending on if GearBoxModel has a value
        {
            if (GearBoxModel == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        // Properties
        public bool HasGears
        {
            get { return Gears(); }
            
        }
        public string GearBoxModel { get; set; }

        // Methods
        public override string ShowData()
        {
            
            if (HasGears)
            {
                return $"- Name: {Name}, Model: {Model}, Year: {Year}, Color: {Color}, Has gears: {HasGears}, Gearbox model: {GearBoxModel}.";
            }
            else {
                return $"- Name: {Name}, Model: {Model}, Year: {Year}, Color: {Color}, Has gears: {HasGears}.";
            }
        }
    }
    public class Boat : Vehicle
    {
        // Properties
        public string BoatType { get; set; }
        public int Seats { get; set; }
        // Methods
        public override string ShowData()
        {
            return $"- Name: {Name}, Model: {Model}, Year: {Year}, Color: {Color}, Seat count: {Seats}, Boat type: {BoatType}.";
        }
    }
    internal class TestVehicles
    {
        static void Main(string[] args)
        {
            Bike bike1 = new Bike()
            {
                Name = "Jopo",
                Model = "Street",
                Year = 2012,
                Color = "Green",
            };
            Bike bike2 = new Bike()
            {
                Name = "Tunturi",
                Model = "Cross",
                Year = 2016,
                Color = "White",
                GearBoxModel = "Shimano Nexus"
            };
            Boat boat1 = new Boat()
            {
                Name = "Yamaha",
                Model = "1400",
                Year = 2004,
                Color = "Yellow",
                Seats = 2,
                BoatType = "Motorboat"
            };
            Console.WriteLine("Bike 1:");
            Console.WriteLine(bike1.ShowData());
            Console.WriteLine("Bike 2:");
            Console.WriteLine(bike2.ShowData());
            Console.WriteLine("Boat 1:");
            Console.WriteLine(boat1.ShowData());
        }
    }
}
