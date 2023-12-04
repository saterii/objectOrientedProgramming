using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise_38
{
    public class Window
    {
        public double Width { get; set; }
        public double Height { get; set; }
        public double Area { get
            {
                return Width * Height;
            } }
        public double Circumference { get
            {
                return (Width * 2) + (Height * 2);
            } }
        public double TotalGlass {  get
            {
                return Area * 3;
            } }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                double height = 0;
                double width = 0;
                try
                {
                    Console.Write("Enter window height in meters (for example 1,8): ");
                    height = Convert.ToDouble(Console.ReadLine());
                }
                catch { Console.WriteLine("Enter a number!"); continue; }
                try
                {
                    Console.Write("Enter window width in meters (for example 0,9): ");
                    width = Convert.ToDouble(Console.ReadLine());
                }
                catch { Console.WriteLine("Enter a number (like 1,2)!"); continue; }
                Window window = new Window() { Width = width, Height = height };
                Console.WriteLine($"Window area: {window.Area} squaremeters,");
                Console.WriteLine($"Wood needed: {window.Circumference} meters,");
                Console.WriteLine($"Total glass needed: {window.TotalGlass} squaremeters.");
                Console.ReadLine();
            }
        }
    }
}
