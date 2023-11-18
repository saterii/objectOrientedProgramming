using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise_30
{
    public interface IVehicle
    {
        string Start();
        string Stop();
        string AccelerateTo(int targetSpeed);
        string DecelerateTo(int targetSpeed);
        
        int MaxSpeed { get; set; }
        string Color { get; set; }
    }
    public class Vehicle : IVehicle
    {
        public string Make { get; set; }
        public string Model { get; set; }
        public int MaxSpeed { get; set; }
        public string Color { get; set; }
        public virtual bool IsRunning { get; set; }
        public int Speed { get; set; }
        public virtual string Start()
        {
            if (IsRunning == false) { IsRunning = true; return $"Vehicle {Make} {Model} has been started"; }
            else { return $"Vehicle {Make} {Model} is already running!"; }
        }
        public virtual string Stop()
        {
            if (IsRunning == true) { IsRunning = false; Speed = 0; return $"Vehicle {Make} {Model} has been stopped"; }
            else { return $"Vehicle {Make} {Model} is already off!"; }
        }
        public virtual string AccelerateTo(int targetSpeed)
        {
            if (IsRunning == true)
            {
                if (targetSpeed > MaxSpeed || targetSpeed <= 0 || targetSpeed <= Speed) { return $"{targetSpeed}km/h is not a valid speed to accelerate to!"; }
                else { Speed = targetSpeed; return $"Vehicle {Make} {Model} accelerated to {Speed}km/h"; }
            }
            else { return $"Vehicle {Make} {Model} is not running!"; }
        }
        public virtual string DecelerateTo(int targetSpeed)
        {
            if (IsRunning == true)
            {
                if (targetSpeed <= 0 || targetSpeed >= Speed) { return $"{targetSpeed}km/h is not a valid speed to decelerate to!"; }
                else { Speed = targetSpeed; return $"Vehicle {Make} {Model} decelerated to {Speed}km/h"; }
            }else { return $"Vehicle {Make} {Model} is not running!"; }
        }
        public virtual string DisplayAllData()
        {
            return $"Vehicle {Make} {Model} is {Color}, has max speed of {MaxSpeed}km/h. Vehicle is running {IsRunning}, speed: {Speed}km/h.";
        }
    }
    public class Car : Vehicle, IVehicle
    {
        private bool CarIsRunning;
        
        public override bool IsRunning { get { return CarIsRunning; } }
        public int HorsePower {  get; set; }
        public override string DisplayAllData()
        {
            return $"Car {Make} {Model} is {Color}, has max speed of {MaxSpeed}km/h and {HorsePower}hp. Vehicle is running: {IsRunning}, speed: {Speed}km/h.";
        }

        public override string Start()
        {
            if (IsRunning == false) { CarIsRunning = true; return $"Car {Make} {Model} has been started"; }
            else { return $"Car {Make} {Model} is already running!"; }
        }
        public override string Stop()
        {
            if (IsRunning == true) { CarIsRunning = false; Speed = 0; return $"Car {Make} {Model} has been stopped"; }
            else { return $"Car {Make} {Model} is already off!"; }
        }
        // Constructors
        public Car() { CarIsRunning = false; }
    }
    public class Motorcycle : Vehicle, IVehicle
    {
        public int CubicCapacity { get; set; }

        public override string DisplayAllData()
        {
            return $"Motorcycle {Make} {Model} is {Color}, has max speed of {MaxSpeed}km/h and cubic capacity of {CubicCapacity}CC. Vehicle is running: {IsRunning}, speed: {Speed}km/h.";
        }
        // Constructors
        public Motorcycle() { IsRunning = false; }
    }
    
    internal class Program
    {
        static void Main(string[] args)
        {
            Car car1 = new Car() { Make = "Volkswagen", Model = "Passat", MaxSpeed = 170, Color = "Light blue", HorsePower = 90 };
            Console.WriteLine("Car:");
            Console.WriteLine(car1.DisplayAllData());
            Console.WriteLine(car1.AccelerateTo(160));
            Console.WriteLine(car1.Start());
            Console.WriteLine(car1.AccelerateTo(90));
            Console.WriteLine(car1.DecelerateTo(95));
            Console.WriteLine(car1.DecelerateTo(60));
            Console.WriteLine(car1.Stop());
            Console.WriteLine($"Current speed for car {car1.Make} {car1.Model}: {car1.Speed}km/h.");
            Console.WriteLine();
            Console.WriteLine("Moped:");
            Motorcycle mc1 = new Motorcycle() { Make = "Peugeot", Model = "XPS", MaxSpeed = 55, Color = "Blue", CubicCapacity = 50 };
            Console.WriteLine(mc1.DisplayAllData());
            Console.WriteLine(mc1.Stop());
            Console.WriteLine(mc1.Start());
            Console.WriteLine(mc1.AccelerateTo(60));
            Console.WriteLine(mc1.AccelerateTo(45));
            Console.WriteLine(mc1.DecelerateTo(30));
            Console.WriteLine(mc1.Stop());
            Console.WriteLine($"Current speed for moped {mc1.Make} {mc1.Model}: {mc1.Speed}km/h.");

        }
    }
}
