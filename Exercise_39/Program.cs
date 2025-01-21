using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
namespace Exercise_39
{
    public class Timer
    {
        public int Seconds { get; set; }
        public int Minutes { get; set; }
        public string Alarm = "Wake wake, little bird";
        public string SetAlarm(string alarm)
        {
            Alarm = alarm;
            return $"Alarm is now {alarm}";
        }
        public string SetTimer(int minutes, int seconds)
        {
            Minutes = minutes;
            Seconds = seconds;
            if (minutes == 0)
            {
                return $"Timer set to {seconds} seconds.";
                
            }
            else
            {
                return $"Timer set to {minutes} minutes, {seconds} seconds.";
            }

        }
        public void CountDown(Action<String> onAlarm)
        {
            int time = (Minutes * 60 + Seconds) * 1000;
            Thread.Sleep(time);
            onAlarm?.Invoke(Alarm);
        }

    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Timer timer = new Timer();
            while (true)
            {
                Console.WriteLine("1. Set alarm text");
                Console.WriteLine("2. Set time");
                Console.WriteLine("3. Start timer");
                Console.Write("Action: ");
                string action = Console.ReadLine();
                if(action == "1")
                {
                    Console.WriteLine($"Alarm text is currently '{timer.Alarm},'");
                    Console.Write("Set new alarm: ");
                    timer.SetAlarm(Console.ReadLine());
                }
                else if (action == "2")
                {
                    int minutes = 0;
                    int seconds = 0;
                    Console.WriteLine($"Timer is currently set to {timer.Minutes} minutes, {timer.Seconds} seconds.");
                    Console.Write("Set minutes (0-60): ");
                    try
                    {
                        minutes = Convert.ToInt32(Console.ReadLine());
                        if(minutes < 0 ||  minutes > 60) { throw new Exception(); }
                        if (minutes == 0)
                        {
                            Console.Write("Set seconds (1-60): ");
                            seconds = Convert.ToInt32(Console.ReadLine());
                            if (seconds < 1 || seconds > 60) { throw new Exception(); }
                        }
                        else
                        {
                            Console.Write("Set seconds (0-60): ");
                            seconds = Convert.ToInt32(Console.ReadLine());
                            if (seconds < 0 || seconds > 60) { throw new Exception(); }
                        }

                        timer.SetTimer(minutes, seconds);
                    }
                    catch { Console.WriteLine("Enter an integer within the specified range!!"); }
                }
                else if (action == "3")
                {
                    Console.WriteLine($"Timer started, alarming in {timer.Minutes} min {timer.Seconds} sec...");
                    timer.CountDown((alarmText) =>
                    {
                        Console.WriteLine(alarmText);
                    });
                }
                else
                {
                    Console.WriteLine("Enter valid input!");
                }
            }
        }
    }
}
