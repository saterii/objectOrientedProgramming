using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Security.Authentication.ExtendedProtection;
using System.Text;
using System.Threading.Tasks;

namespace Exercise_8
{
    public class Television
    {
        // Properties
        public string Brand {get;set;}
        public int Size { get;set;}
        public bool IsOn { get;set;}
        public string CurrentState { get { if (IsOn) return "On"; else return "Off"; } }
        public int Volume { get;set;}
        public int Channel { get; set; }

        // Methods

        public void TogglePower()
        {
            if (IsOn) { IsOn = false; }
            else { IsOn = true; }
        }

        public string ShowProperties()
        {
            if (!IsOn) 
            {
                return $"{Brand} TV (Size: {Size} inches) is currently {CurrentState}";
            }
            else
            {
                return $"{Brand} TV (Size: {Size} inches) is currently {CurrentState}. The channel is set to {Channel} and the volume is at {Volume}%";
            }
            
        }

        public string AdjustVolume(int volume)
        {
            Volume = volume;
            return $"Volume set at {Volume}%";
        }
        public string ChangeChannel(int channel)
        {
            Channel = channel;
            return $"Channel changed to {Channel}";
        }

    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Television tv1 = new Television();
            tv1.Brand = "LG";
            tv1.Size = 55;
            tv1.IsOn = true;
            tv1.Volume = 10;
            tv1.Channel = 4;
            Console.WriteLine(tv1.ShowProperties());
            tv1.TogglePower();
            Console.WriteLine(tv1.ShowProperties());
            tv1.TogglePower();
            Console.WriteLine(tv1.ShowProperties());
            tv1.ChangeChannel(12);
            tv1.AdjustVolume(25);
            Console.WriteLine(tv1.ShowProperties());
        }
    }
}
