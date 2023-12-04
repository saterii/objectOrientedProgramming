using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Exercise_32
{
    internal class Program
    {
        delegate string FormatString(string str);
        static void Main(string[] args)
        {
            while (true)
            {
                Console.Write("Enter string to process: ");
                string str = Console.ReadLine();
                string tempStr = str;
                if (str == null || str.Length == 0)
                {
                    Console.WriteLine("Please enter a string! ");
                    continue;
                }
                else
                {
                    Console.WriteLine("Choose the treatment you want, you can give several treatments at once as one string, e.g. '123'");
                    Console.WriteLine("1. To capital letters");
                    Console.WriteLine("2. To lowercase letters");
                    Console.WriteLine("3. To title");
                    Console.WriteLine("4. To palindrome");
                    Console.WriteLine("0. Terminate");
                    Console.Write("Treatment: ");

                    string treatment = Console.ReadLine();
                    if(treatment == "0") // Exit program with 0
                    {
                        break;
                    }
                    List<int> treatments = new List<int>(); // Create list and add treatments based on user input
                    try
                    {
                        foreach(char number in treatment)
                        {
                            int treatmentToAdd = Int32.Parse(number.ToString());
                            if(treatmentToAdd > 0 && treatmentToAdd < 5)
                            {
                                treatments.Add(treatmentToAdd);
                            }
                            else { throw new Exception(); } // If treatment not in 0-5, go back to the start
                        }
                    }
                    catch { Console.WriteLine("Please only enter numbers between 0 and 4!"); continue; }
                    FormatString f1 = InitializeString;
                    foreach (int i in treatments)
                    {
                        if (i == 1)
                        {
                            f1 += CapitalizeString;
                        }
                        else if (i == 2)
                        {
                            f1 += DeCapitalizeString;
                        }
                        else if (i == 3)
                        {
                            f1 += CapitalizeFirstLetter;
                        }
                        else if (i == 4)
                        {
                            f1 += CreatePalindrome;
                        }
                        
                        str = f1.Invoke(str); // Invoke the delegate so that it actually performs the actions
                        Console.WriteLine(tempStr + " changed to " + str);

                    }
                    Console.WriteLine();
                }
                
            }
        }
        static string InitializeString(string str)
        {
            return str;
        }
        static string CapitalizeString(string str)
        {
            return str.ToUpper();
        }
        static string DeCapitalizeString(string str)
        {
            return str.ToLower();
        }
        static string CapitalizeFirstLetter(string str)
        {
            return str[0].ToString().ToUpper() + str.Substring(1).ToLower();
        }
        static string CreatePalindrome(string str2)
        {
            char[] charArray = str2.ToCharArray();
            Array.Reverse(charArray);
            str2 = new string(charArray);
            return str2;
        }
    }
}
