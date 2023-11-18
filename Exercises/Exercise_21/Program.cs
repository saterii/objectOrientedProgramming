using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace Exercise_21
{
    public class Song
    {
        public string Title { get; set; }
        public int Minutes { get; set; }
        public int Seconds { get; set; }
        public string Length { get
            {
                string SecondsString = "";
                if(Seconds < 10) { SecondsString = "0" + Seconds.ToString(); }else { SecondsString = Seconds.ToString(); };
                return Minutes.ToString() + ":" + SecondsString;
            }
        }
    }
    public class CD
    {
        public string Name { get; set; }
        public string Artist { get; set; }
        public int Songs { get { return SongsList.Count; } }
        public string TotalLength { get { return CalculateLength(SongsList); } }
        public List<Song> SongsList { get; set; }

        public string CalculateLength(List<Song> list)
        {
            int totalMinutes = 0;
            int totalSeconds = 0;
            
            foreach (Song song in list) {
                totalMinutes += song.Minutes;
                totalSeconds += song.Seconds;
            }
            while(totalSeconds > 60)
            {
                totalSeconds -= 60;
                totalMinutes += 1;
            };
            string totalLength = totalMinutes.ToString() + ":" + totalSeconds.ToString();
            return totalLength;
        }
        
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            CD cd1 = new CD() { Artist = "Costi", Name = "Safari" };
            cd1.SongsList = new List<Song>()
            {
                new Song {Title = "Ryhtiliike", Minutes = 2, Seconds = 30},
                new Song {Title = "Robben", Minutes = 2, Seconds = 29},
                new Song {Title = "Vuosii", Minutes = 2, Seconds = 4},
                new Song {Title = "5", Minutes = 2, Seconds = 8},
                new Song {Title = "Movie", Minutes = 2, Seconds = 26},
                new Song {Title = "Duomo", Minutes = 2, Seconds = 17}
            };
            Console.WriteLine("CD info:");
            Console.WriteLine($"    -Artist: {cd1.Artist}");
            Console.WriteLine($"    -Name: {cd1.Name}");
            Console.WriteLine($"    -Total length: {cd1.TotalLength}");
            Console.WriteLine($"    -{cd1.Songs} Songs:");
            foreach (Song song in cd1.SongsList)
            {
                { Console.WriteLine($"        ---Name: {song.Title} - {song.Length}"); }
            }
        }
    }
}
