using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise_13
{
    public class Elevator
    {
        private int MinFloor = 1;
        private int MaxFloor = 5;
        public int currentFloor = 1;

        public bool MoveToFloor(int floor)
        {
            if(floor <= MaxFloor && floor >= MinFloor)
            {
                currentFloor = floor;
                return true;
            }
            else
            {
                return false;
            }
        }
    }
    internal class ElevatorTest
    {
        static void Main(string[] args)
        {
            Elevator elevator = new Elevator();
            while (true)
            {
                Console.WriteLine($"Elevator is now on floor {elevator.currentFloor}.");
                Console.WriteLine("Enter the floor you want to go to: ");
                if(elevator.MoveToFloor(Int32.Parse(Console.ReadLine())) == false) { Console.WriteLine("Please enter a number between 1-5!"); };
            }
            
        }
    }
}
