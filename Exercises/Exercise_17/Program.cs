using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise_17
{
    public class ElectricalDevice
    {
        // Properties
        public bool IsOn = false;
        public float Power = 0;
    }
    public class PortableRadio : ElectricalDevice
    {
        // Properties
        private int volume = 0;
        private double frequency = 2000.00;
        public int Volume {
            get { return volume; }
        }
        public double Frequency
        {
            get { return frequency; }
        }
        // Methods
        public void Switch() {
            if (IsOn) {
                IsOn = false; Power = 0;
            }
            else { IsOn = true; Power = 0.75F; }
        }
        public void SetVolume(int newVolume)
        {
            if(IsOn == true)
            { 
                if (newVolume <= 9 && newVolume >= 0) { volume = newVolume; }
            }
        }
        public void SetFrequency(double newFrequency)
        {
            if (IsOn == true)
            {
                if (newFrequency <= 26000.00 && newFrequency >= 2000.00) { frequency = newFrequency; }
            }
        }

        public string ShowData()
        {
            if (IsOn) return $"Radio - Is on: {IsOn}, Volume: {Volume}, Channel: {Frequency}, Operating at {Power} watts.";
            else return $"Radio - Is on: {IsOn}, Power is {Power} watts.";
        }

    }
    internal class TestDevices
    {
        static void Main(string[] args)
        {
            PortableRadio radio = new PortableRadio();
            
            Console.WriteLine(radio.ShowData());

            radio.SetVolume(7); // Volume and frequency won't change because the radio is off
            radio.SetFrequency(2600.5);
            radio.Switch(); // Turn the radio on
            Console.WriteLine(radio.ShowData());

            radio.SetVolume(7);
            radio.SetFrequency(2600.7);
            Console.WriteLine(radio.ShowData());

            radio.SetVolume(12); // Volume and frequency won't change because the values are too high
            radio.SetFrequency(27000);
            Console.WriteLine(radio.ShowData());


        }
    }
}
