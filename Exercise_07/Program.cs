using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Exercise_7
{
    internal class Program
    {
        public class WashingMachine
        {
            //properties
            public int Id {  get; set; }
            public string Brand { get; set; }
            public int WashTime { get; set; }
            public int TimeElapsed { get; set; }
            public int TimeLeft { get { return WashTime - TimeElapsed; } }
            public string CurrentState;
            public bool IsOn { get; set; }
            public int CurrentTemperature { get; set; }

            //methods
            public int SetTemperature(int temperature)
            {
                CurrentTemperature = temperature;
                return CurrentTemperature;
            }
            public string ShowProperties()
            {

                if (CurrentState == "off") { return $"Washing machine {Id} is a {Brand} and it is currently {CurrentState}. It takes {WashTime} minutes to complete a wash."; }
                else { return $"Washing machine {Id} is a {Brand} and it is currently {CurrentState} at {CurrentTemperature} degrees celsius. It takes {WashTime} minutes to complete, and as it was turned on {TimeElapsed} minutes ago, it will complete in {TimeLeft} minutes."; }

            }

            //constructors
            public WashingMachine(bool IsOn)
            {
                if(!IsOn) { CurrentState = "off"; }else { CurrentState = "on"; }
                
            }
            public WashingMachine(bool isOn,int InitialTemperature) : this(isOn)
            {
                CurrentTemperature = InitialTemperature;
            }
            
            
        }
        static void Main(string[] args)
        {
            WashingMachine wm1 = new WashingMachine(true ,0);
            wm1.Id = 1;
            wm1.Brand = "Bosch";
            wm1.WashTime = 80;
            wm1.TimeElapsed = 30;
            wm1.SetTemperature(50);

            WashingMachine wm2 = new WashingMachine(false, 0);
            wm2.Id = 2;
            wm2.Brand = "Samsung";
            wm2.WashTime = 90;
            wm2.TimeElapsed = 0;

            
            Console.WriteLine(wm1.ShowProperties());
            Console.WriteLine(wm2.ShowProperties());
        }
    }
}
