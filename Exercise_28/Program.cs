using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Exercise_28
{
    public class Item
    {
        public string Name {  get; set; }
        public virtual string ShowData()
        {
            return $"";
        }
    }
    public class Food : Item
    {
        public int Weight { get; set; }
        public string ExpireDate { get; set; }

        public override string ShowData()
        {
            return $"{Name}, Weight: {Weight}g, Expires in: {ExpireDate}";
        }

    }
    public class Meat : Food
    {
        public string MeatType { get; set; }
        public override string ShowData()
        {
            return $"{MeatType} {Name}, Weight: {Weight}g, Expires in: {ExpireDate}";
        }
    }
    public class Vegetable : Food
    {
        public string Color { get; set; }
        public override string ShowData()
        {
            return $"{Name}, Weight: {Weight}g, Expires in: {ExpireDate}, Color: {Color}";
        }
    }
    public class Drink : Item
    {
        public string Brand { get; set; }
        public bool IsOpened { get; set; }
        public int Amount { get; set; }
        public override string ShowData()
        {
            return $"{Brand} {Name}, Amount {Amount}ml, Is opened: {IsOpened}";
        }
    }
    public class Refrigerator
    {
        private int temperature = 4;
        public string Brand { get; set; }
        public int Temperature { get { return temperature; } }
        public List<Item> Items { get; set; }

        public void SetTemperature(int temp)
        {
            temperature = temp;
        }
        public void AddMeat(string name, int weight, string expireDate, string meatType)
        {
            Meat meat = new Meat();
            Items.Add(new Meat() { Name = name, Weight = weight, ExpireDate = expireDate, MeatType = meatType });
        }
        public void AddVegetable(string name, int weight, string expireDate, string color)
        {
            Items.Add(new Vegetable() { Name = name, Weight = weight, ExpireDate = expireDate, Color = color});
        }
        public void AddDrink(string brand, bool isOpened, string name, int amount)
        {
            Items.Add(new Drink() { Brand = brand, IsOpened = isOpened, Name = name, Amount = amount });
        }
        
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Refrigerator refrigerator = new Refrigerator() { Brand = "Samsung" };
            refrigerator.Items = new List<Item>();
            refrigerator.AddMeat( "Tenderloin", 200, "25.12.2023", "Beef");
            refrigerator.AddMeat("Ribs", 1500, "31.12.2023", "Lamb");
            refrigerator.AddMeat("Steak", 400, "27.12.2023", "Pork");
            refrigerator.AddVegetable("Carrot", 50, "03.01.2023", "Orange");
            refrigerator.AddVegetable("Red Onion", 125, "09.01.2023", "Red");
            refrigerator.AddDrink("Arla", false, "Milk", 1000);
            refrigerator.AddDrink("Rainbow", true, "Juice", 450);
            refrigerator.AddDrink("Koff", false, "Beer", 330);

            Console.WriteLine($"Refrigerator {refrigerator.Brand} is at {refrigerator.Temperature} degrees celsius and has the following items:");
            Console.WriteLine("   -Foods:");
            for(int i = 0; i < refrigerator.Items.Count(); i++) 
            {
                
                if (refrigerator.Items[i].GetType() == typeof(Meat))
                {
                    Console.WriteLine($"     --{refrigerator.Items[i].ShowData()}");
                }
                else if (refrigerator.Items[i].GetType() == typeof(Vegetable))
                {
                    Console.WriteLine($"     --{refrigerator.Items[i].ShowData()}");
                }
                else if(refrigerator.Items[i].GetType() == typeof(Food))
                {
                    Console.WriteLine($"     --{refrigerator.Items[i].ShowData()}");
                }
            }
            Console.WriteLine("   -Drinks:");
            for (int i = 0; i < refrigerator.Items.Count(); i++)
            {
                if (refrigerator.Items[i].GetType() == typeof(Drink))
                {
                    Console.WriteLine($"     --{refrigerator.Items[i].ShowData()}");
                }
            }

        }
    }
}
