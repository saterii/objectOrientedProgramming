using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Exercise_6
{
    internal class Program
    {
        public class saunaHeater
        {
            public int ID {  get; set; }
            public int temperature { get; set; }
            public int humidity { get; set; }

            public string currentState { get; set; }

            public string showProperties()
            { return $"Sauna heater {ID} is {currentState}. It's temperature is {temperature} degrees celsius and humidity is {humidity}%"; }
        }
        static void Main(string[] args)
        {
            saunaHeater heater1 = new saunaHeater();
            heater1.ID = 1;
            heater1.temperature = 90;
            heater1.humidity = 72;
            heater1.currentState = "on";
            saunaHeater heater2 = new saunaHeater();
            heater2.ID = 2;
            heater2.temperature = 15;
            heater2.humidity = 5;
            heater2.currentState = "off";
            Console.WriteLine(heater1.showProperties());
            Console.WriteLine(heater2.showProperties());
        }
    }
}
