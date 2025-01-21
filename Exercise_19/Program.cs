using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise_19
{
    public abstract class Animal
    {
        public string LatinName { get; set; }
        public int Weight { get; set; }
        public string Color { get; set; }
        public int MaxSpeed { get; set; }
        public abstract string Move();
        public abstract string Communicate();
    }
    public class Bird : Animal
    {
        public int Wingspan { get; set; }
        public override string Move() { return "Flying"; }
        public override string Communicate() { return "Chirping"; }
        public string ShowData()
        {
            return $"Bird {LatinName}, Weight: {Weight}g, Color: {Color}, Max speed: {MaxSpeed}km/h, Wingspan {Wingspan}cm.";
        }
    }
    public abstract class Mammal : Animal
    {
        public int Legs { get; set; }
        public string Gender { get; set; }
        public override string Move() { return "Walking"; }
        public abstract override string Communicate();
    }
    public class Human : Mammal
    {
        public string Name { get; set; }
        public string EyeColor { get; set; }
        public string Nationality { get; set; }
        public int Height { get; set; }
        public override string Communicate()
        {
            return "Talking";
        }
        public string ShowData()
        {
            return $"Human {Name}, Weight: {Weight}g, Height: {Height}cm, Legs: {Legs}, Gender: {Gender}, Nationality: {Nationality}.";
        }
    }
    public class Cat : Mammal
    {
        public string Name { get; set; }
        public string CatType { get; set; }
        public override string Communicate()
        {
            return "Meowing";
        }
        public string ShowData()
        {
            return $"Cat {Name}, Color: {Color}, Max speed: {MaxSpeed}km/h Weight: {Weight}g, Legs: {Legs}, Gender: {Gender}, Cat type: {CatType}.";
        }
    }
    internal class TestAnimal
    {
        static void Main(string[] args)
        {
            Human human = new Human()
            {
                Weight = 70000,
                Legs = 2,
                Gender = "Male",
                Name = "Jaakko Teppo",
                Height = 181,
                Nationality = "Finnish"
            };
            Cat cat = new Cat()
            {
                Name = "Pöpi",
                Color = "Grey",
                MaxSpeed = 25,
                Weight = 4500,
                Legs = 4,
                Gender = "Male",
                CatType = "House cat"
            };
            Bird bird = new Bird()
            {
                LatinName = "Peregrine falcon",
                MaxSpeed = 320,
                Wingspan = 120,
                Weight = 1000,
                Color = "Black/White"
            };
            Console.WriteLine(cat.ShowData());
            Console.WriteLine(cat.Move());
            Console.WriteLine(cat.Communicate());
            Console.WriteLine(human.ShowData());
            Console.WriteLine(human.Move());
            Console.WriteLine(human.Communicate());
            Console.WriteLine(bird.ShowData());
            Console.WriteLine(bird.Move());
            Console.WriteLine(bird.Communicate());
           

        }
    }
}
