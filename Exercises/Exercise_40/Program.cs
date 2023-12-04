using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Exercise_40
{
    public class Student
    {
        static int NextID;
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Group { get; set; }
        public string StudentID { get; set; }
            
        public string DisplayData()
        {
            return $"{FirstName} {LastName} {StudentID} {Group}";
        }

        public Student(string firstName, string lastName)
        {
            FirstName = firstName ;
            LastName = lastName ;
            int studentidNumber = Interlocked.Increment(ref NextID);
            string studentid = "";
            studentid += firstName[0].ToString();
            studentid += lastName[0].ToString();
            if (studentidNumber < 10)
            {
                studentid += $"00{studentidNumber}";
            }
            else if (studentidNumber > 100)
            {
                studentid += $"0{studentidNumber}";
            }
            else { studentid += $"{studentidNumber}"; }
            StudentID = studentid;
        }
    
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Student student1 = new Student("Hanna", "Husso") { Group = "TTV19S1"};
            Student student2 = new Student("Kirsi", "Kernell") { Group = "TTV19S2" }; 
            Student student3 = new Student("Masa", "Niemi") { Group = "TTV19S3" }; ;
            Student student4 = new Student("Frank", "Tester") { Group = "TTV19SM" }; 
            Student student5 = new Student("Allan", "Aalto") { Group = "TTV19SMM" }; 
            List<Student> students = new List<Student>() { student1, student2, student3, student4, student5 };

            Console.WriteLine("First student in the MiniPeppi:");
            Console.WriteLine($"{students[0].DisplayData()}");
            Console.WriteLine("Last student in the MiniPeppi:");
            Console.WriteLine($"{students[students.Count - 1].DisplayData()}");
            Console.WriteLine();
            Console.WriteLine($"All of the {students.Count()} students in MiniPeppi:");
            foreach (Student student in students)
            {
                Console.WriteLine(student.DisplayData());
            }
            var studentsAlphabetical = students.OrderBy(x => x.LastName).ToList();
            Console.WriteLine();
            Console.WriteLine($"All of the {students.Count()} students in alphabetical order in MiniPeppi:");
            foreach (Student student in studentsAlphabetical)
            {
                Console.WriteLine(student.FirstName + " " + student.LastName);
            }
            Console.WriteLine();
            Console.WriteLine("Please, give data of the new student:");
            Console.Write("StudentID: ");
            string idToAdd = Console.ReadLine();
            Console.Write("First name: ");
            string firstNameToAdd = Console.ReadLine();
            Console.Write("Last name: ");
            string lastNameToAdd = Console.ReadLine();
            Console.Write("Group: ");
            string groupToAdd = Console.ReadLine();

            try
            {
                string[] allIDs = new string[students.Count];
                int index = 0;
                foreach (Student student in students)
                {
                    allIDs[index] = student.StudentID;
                    index++;
                }
                if (allIDs.Contains(idToAdd)) { throw new Exception(); }
                Student studentToAdd = new Student(firstNameToAdd, lastNameToAdd) { Group = groupToAdd, StudentID = idToAdd };
                students.Add(studentToAdd);
                Console.WriteLine($"Added {firstNameToAdd} {lastNameToAdd} to the MiniPeppi, there are now {students.Count()} students.");
                Console.WriteLine($"All of the {students.Count()} students in MiniPeppi:");
                foreach (Student student in students)
                {
                    Console.WriteLine(student.DisplayData());
                }
                Console.WriteLine() ;
            }
            catch { Console.WriteLine($"Failed to add student {firstNameToAdd} {lastNameToAdd} to the MiniPeppi."); }

        }
    }
}
