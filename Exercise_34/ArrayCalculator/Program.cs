using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise_34
{
    public class ArrayCalculator
    {
        public static double CalcSum(double[] array)
        {
            double sum = 0;
            foreach(var x in array)
            {
                sum += x;
            }
            return sum;
        }
        public static double CalcAverage(double[] array)
        {
            double sum = 0;
            foreach (var x in array)
            {
                sum += x;
            }
            return sum / array.Length;
        }
        public static double CalcMin(double[] array)
        {
            double min = array[0];
            foreach(var x in array)
            {
                if (x < min) min = x;
            }
            return min;
        }
        public static double CalcMax(double[] array)
        {
            double max = array[0];
            foreach(var x in array)
            {
                if (x > max) max = x;
            }
            return max;
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            double[] array = { 1.0, 2.0, 3.3, 5.5, 6.3, -4.5, 12.0 };
            double[] empty = { };
            Console.WriteLine($"Sum: {ArrayCalculator.CalcSum(array)}");
            Console.WriteLine($"Avg: {ArrayCalculator.CalcAverage(array)}");
            Console.WriteLine($"Min: {ArrayCalculator.CalcMin(array)}");
            Console.WriteLine($"Max: {ArrayCalculator.CalcMax(array)}");
            Console.WriteLine($"Empty average: {ArrayCalculator.CalcAverage(empty)}");
        }
    }
}