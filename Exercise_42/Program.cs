using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise_42
{
    public abstract class Shape
    {
        public string Name { get; set; }
        public abstract double Circumference();
        public abstract double Area();
        public abstract string DisplayData();
    }
    public class Circle : Shape
    {
        public double Radius { get; set; }
        public override double Area()
        {
              return Math.Round(Math.PI * Radius * Radius, 2);
        }
        public override double Circumference()
        {
            return Math.Round(2 * Math.PI * Radius, 2);
        }
        public override string DisplayData()
        {
            return $"{Name} Radius={Radius} Area={Area()} Circumference={Circumference()}";
        }
        public Circle( double radius)
        {
            Radius = radius;
        }
    }
    public class Rectangle : Shape
    {
        public double Width { get; set; }
        public double Height { get; set; }
        public override double Area()
        {
            return Math.Round(Width * Height, 2);
        }
        public override double Circumference()
        {
            return Math.Round((2 * Width) + (2 * Height), 2);
        }
        public override string DisplayData()
        {
            return $"{Name} Width={Width} Height={Height} Area={Area()} Circumference={Circumference()}";
        }
        public Rectangle(double width, double height)
        {
            Width = width;
            Height = height;
        }
    }
    public class Shapes
    {
        public List<Shape> ShapesList = new List<Shape>();
        public string AddShape(Shape shape)
        {
            ShapesList.Add(shape);
            return $"Added {shape.Name} to the list.";
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Circle c1 = new Circle(1) { Name = "Circle"};
            Circle c2 = new Circle(2) { Name = "Circle"};
            Circle c3 = new Circle(3) { Name = "Circle"}; ;
            Rectangle r1 = new Rectangle(10, 20) { Name = "Rectangle" };
            Rectangle r2 = new Rectangle(20, 30) { Name = "Rectangle" };
            Rectangle r3 = new Rectangle(40, 50) { Name = "Rectangle"};
            Shapes shapes = new Shapes() { ShapesList = new List<Shape>() { c1, c2, c3, r1, r2, r3 } };
            shapes.AddShape(new Circle(4) { Name = "Circle" });
            shapes.AddShape(new Rectangle(50, 60) { Name = "Rectangle" });

            var shapesOrdered = shapes.ShapesList.OrderBy(x => x.Name).ToList(); // Print circles first, then rectangles

            foreach(Shape shape in shapesOrdered)
            {
                Console.WriteLine(shape.DisplayData());
            }
        }
    }
}
