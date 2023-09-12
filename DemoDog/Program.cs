using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Jamk.IT.TTC8440.FirstProgram;

namespace Jamk.IT.TTC8440
{
    internal class FirstProgram
    {
        public class Dog
        {
            // Fields = Variables
            private int currentYear = DateTime.Today.Year;
            // Properties
            public string Name { get; set; }
            public string Breed { get; set; }
            public int BirthYear { get; set; }
            public int Age {
                get {
                    return currentYear - BirthYear;
                    }
            }
            // Methods
            public string ShowAllData()
            {
                return $"{Name} is a {Age} years old dog born in {BirthYear} and his breed is {Breed}";
            }
            // Constructors
            public Dog()
            {
                currentYear = DateTime.Today.Year;
            }
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Testing the Dog class.");
            // Create one Dog object
            Dog dog = new Dog();
            dog.Name = "Reiska";
            dog.Breed = "Beagle";
            dog.BirthYear = 2012;
            // Show properties of dog
            Console.WriteLine(dog.ShowAllData());
        }
    }
}
