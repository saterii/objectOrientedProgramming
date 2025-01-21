using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise_15
{
    public class Employee
    {
        public string Name { get; set; }
        public string Profession { get; set; }
        public decimal Salary { get; set; }

        public virtual string ShowData()
        {
            return $"- Name: {Name}, Profession: {Profession}, Salary: {Salary}";
        }
    }
    public class  Boss : Employee
    {
        public string Car {  get; set; }
        public decimal Bonus { get; set; }

        public override string ShowData()
        {
            return $"- Name: {Name}, Profession: {Profession}, Salary: {Salary}, Car: {Car}, Bonus: {Bonus}";
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Employee employee = new Employee() { Name = "Marco Pfiffer", Profession = "In-game leader", Salary = 6000 };
            Boss boss = new Boss() { Name = "Eetu Saha", Profession = "Bossman", Salary= 8000, Car = "Audi A6", Bonus = 200 };
            Console.WriteLine("Employee: ");
            Console.WriteLine(employee.ShowData());
            Console.WriteLine("Boss: ");
            Console.WriteLine(boss.ShowData());
        }
    }
}
