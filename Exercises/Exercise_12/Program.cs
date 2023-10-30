using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise_12
{
    public class Tank
    {
        private const float SpeedMax = 100F;
        private float speed = 0;
        private int Seats = 4;
        // Properties

        public string Name { get; set; }
        public string Type { get; set; }
        public int CrewNumber
        {
            get {  return Seats; }
            set { if (value <= 6 && value >= 4) { this.Seats = value; } }
        }
        public float Speed
        {
            get { return speed; }
        }
        

        // Methods
        public float AccelerateTo(float targetSpeed)
        {
            if (targetSpeed < SpeedMax && targetSpeed > 0 && targetSpeed > speed)
            {
                speed = targetSpeed;
            }
            
            return speed;
        }
        public float SlowTo(float targetSpeed)
        {
            if (targetSpeed < SpeedMax && targetSpeed > 0 && targetSpeed > speed)
            {
                speed = targetSpeed;
            }
            return speed;
        }
    }
    internal class TestTank
    {
        static void Main(string[] args)
        {
            Tank tank1 = new Tank()
            {
                Name = "Leopard 2A6",
                Type = "Battle Tank"
            };
            Console.WriteLine($"Current speed: {tank1.Speed} km/h");
            tank1.AccelerateTo(30);
            Console.WriteLine($"Current speed: {tank1.Speed} km/h");
            tank1.AccelerateTo(20);
            Console.WriteLine($"Current speed: {tank1.Speed} km/h"); // Speed doesn't change because of it's trying to accelerate to a lower speed
            tank1.SlowTo(20);
            Console.WriteLine($"Current speed: {tank1.Speed} km/h"); // Speed goes down with SlowTo()
            tank1.AccelerateTo(120);
            Console.WriteLine($"Current speed: {tank1.Speed} km/h"); // Doesn't go above 100
            tank1.SlowTo(-10);
            Console.WriteLine($"Current speed: {tank1.Speed} km/h"); // Doesn't go below 0

            // Trying to set the crew number to less than 4 and more than 6, it doesn't change
            tank1.CrewNumber = 1;
            Console.WriteLine(tank1.CrewNumber);

            tank1.CrewNumber = 5;
            Console.WriteLine(tank1.CrewNumber);
            tank1.CrewNumber = 7;
            Console.WriteLine(tank1.CrewNumber);
        }
    }
}
