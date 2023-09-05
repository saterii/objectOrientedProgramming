using System;
using System.Collections.Generic;

namespace JAMK.IT.DemoAnimals
{
    public class Animal
    {
        public string Name { get; set; }
        public virtual void Talk() => Console.WriteLine("The animal is talking.");
        public override string ToString()
        {
            return $"I'm a {base.ToString()}, and my name is {Name}, and I can talk:";
        }
    }
    public class Cat : Animal
    {
        public override void Talk() => Console.WriteLine("Miaaauuu");
    }
    public class Dog : Animal
    {
        public override void Talk() => Console.WriteLine("Wufff");
    }

    internal class TestProgram
    {
        static void TestPolymorphism()
        {
            //a list for different animals
            List<Animal> animals = new List<Animal>();
            animals.Add(new Animal() { Name = "Anonymous" });
            animals.Add(new Cat() { Name = "Tassu" });
            animals.Add(new Dog() { Name = "Snoopy" });
            //show all animals
            foreach (var item in animals)
            {
                Console.WriteLine(item.ToString());
                item.Talk();
                //voidaanko tunnistaa mitä tyyppiä item on
                if (item is Cat)
                {
                    item.Talk();
                    //voidaanko tehdä castaus
                    //implisiittinen
                    //Animal a = (Animal)item;
                    //Console.WriteLine(a.ToString());
                }
                if (item is Animal)
                {
                    //eksplisiittinen muutos
                    Dog dog = item as Dog;
                    if (dog != null)
                        dog.ToString();

                }
            }
        }
        static void Main(string[] args)
        {
            TestPolymorphism();
        }
    }
}
