using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise_4
{   
    
    internal class Program
    {
        static bool checkPalindrome(char[] stringArray)
        {
            string originalString = new string(stringArray);
            Array.Reverse(stringArray);
            string reverseStr = new string(stringArray);
            bool retVal = (originalString == reverseStr);
            return retVal;            
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Enter string: ");
            string stringToCheck = Console.ReadLine();
            char[] stringArray = stringToCheck.ToCharArray();
            Console.WriteLine(checkPalindrome(stringArray));
        }
    }
}
