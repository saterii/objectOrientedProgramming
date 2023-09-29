using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Exercise_10
{
    public class Student
    {
        // Properties
        static int nextID = 10001;
        public int StudentID { get; private set;}
        public string FirstName { get; set;}
        public string LastName { get; set;}
        public string LineOfStudy { get; set;}

        // Methods
        public string ShowAllData()
        {
            return $"Student {FirstName} {LastName} is studying {LineOfStudy} and their ID is {StudentID}";
        }

        // Constructors

        public Student()
        {
            StudentID = Interlocked.Increment(ref nextID);
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            var students = new List<Student>()
            {
                new Student { FirstName = "Harry", LastName = "Strickland", LineOfStudy = "Swordplay"},
                new Student { FirstName = "Jon", LastName = "Connington", LineOfStudy = "Leadership"},
                new Student { FirstName = "Thoros", LastName = "of Myr", LineOfStudy = "Magic"},
                new Student { FirstName = "Aegon", LastName = "Targaryen III", LineOfStudy = "Dragontaming"},
                new Student { FirstName = "Brandon", LastName = "Stark", LineOfStudy = "Construction"}
            };

            foreach (var student in students)
            {
                Console.WriteLine(student.ShowAllData());
            }
        }
    }
}
