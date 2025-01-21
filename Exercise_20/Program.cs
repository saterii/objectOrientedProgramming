using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise_20
{
    public abstract class Mammal
    {
        public int Age { get; set; }
        public abstract string Move();
        public abstract string ShowInfo();
    }
    public class Human : Mammal
    {
        public int Height { get; set; }
        public int Weight { get; set; }
        public string Name { get; set; }
        public void Grow()
        {
            Age += 1;
        }
        public override string Move()
        {
            return "Moving...";
        }
        public override string ShowInfo()
        {
            return $"Human's Age: {Age}, Height: {Height}cm, Weight: {Weight}kg, Name: {Name}.";
        }

    }
    public class Baby : Human
    {
        public string Diaper { get; set; }
        public override string Move()
        {
            return "Crawling...";
        }
        public override string ShowInfo()
        {
            return $"Baby's Age: {Age}, Height: {Height}cm, Weight: {Weight}kg, Name: {Name}, Diaper: {Diaper}.";
        }
    }
    public class Adult : Human
    {
        public string Car { get; set; }
        public override string Move()
        {
            return "Walking...";
        }
        public override string ShowInfo()
        {
            return $"Adult's Age: {Age}, Height: {Height}cm, Weight: {Weight}kg, Name: {Name}, Car: {Car}.";
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Human human1 = new Human()
            {
                Age = 16,
                Height = 163,
                Weight = 53,
                Name = "Kirsi Kernel"
            };
            Baby baby1 = new Baby()
            {
                Age = 1,
                Height = 34,
                Weight = 12,
                Name = "Pekka Kallio",
                Diaper = "Pampers"
            }; ;
            Adult adult1 = new Adult()
            {
                Age = 23,
                Height = 173,
                Weight = 62,
                Name = "Sampsa Tervo",
                Car = "Volkswagen Passat"
            };
            Console.WriteLine(human1.ShowInfo());
            Console.WriteLine(human1.Move());
            
            Console.WriteLine(adult1.ShowInfo());
            adult1.Grow();
            Console.WriteLine(adult1.ShowInfo());
            Console.WriteLine(adult1.Move());
            
            Console.WriteLine(baby1.ShowInfo());
            Console.WriteLine(baby1.Move());
            baby1.Grow();
            Console.WriteLine(baby1.ShowInfo());


        }
    }
}
