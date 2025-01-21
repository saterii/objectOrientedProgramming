using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise_14
{
    public class Amplifier
    {
        private int MinVolume = 0;
        private int MaxVolume = 100;
        private int currentVolume = 0;

        private string ErrorMessage;
        public int Volume
        {
            get { return currentVolume; }
            set
            {
                if (value <= MaxVolume && value >= MinVolume)
                {
                    currentVolume = value;
                    ErrorMessage = null;
                }
                else if (value > MaxVolume)
                {
                    ErrorMessage = "Value can't be more than 100!";
                }
                else if (value < MinVolume)
                {
                    ErrorMessage = "Value can't be less than 100!";
                }
            }

        }
        internal class TestAmplifier
        {
            static void Main(string[] args)
            {
                Amplifier amplifier = new Amplifier();
                while (true)
                {
                    Console.WriteLine("Give a new volume value (0 - 100): ");
                    amplifier.Volume = Int32.Parse(Console.ReadLine());
                    if(amplifier.ErrorMessage != null) { Console.WriteLine(amplifier.ErrorMessage); }
                    Console.WriteLine($"Amplifier volume is set to {amplifier.Volume}");
                }
            }
        }
    }
}
