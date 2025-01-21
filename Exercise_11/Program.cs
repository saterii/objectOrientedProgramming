using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise_11
{
    public class Song
    {
        public string Title { get; set; }
        public string Length { get; set; }
        public string Features { get; set; }
    }
    public class CD
    {
        // Properties
        public string Artist { get; set; }
        public string Title { get; set; }
        public decimal Price { get; set; }
        public string Genre { get; set; }
        public List<Song> Songs { get; set; }

        // Methods
        public string PlayAllSongs()
        {
            return $"Playing all songs, starting from the first song {Songs[0].Title}.";
        }
        public string PlaySong(int index)
        {
            return $"Playing song number {index}: {Songs[index].Title}.";
        }
        
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            CD cd1 = new CD() { Artist = "Costi", Title = "Safari", Price = 9.99M, Genre = "Rap" };
            cd1.Songs = new List<Song>()
            {
                new Song {Title = "Ryhtiliike", Length = "2:30"},
                new Song {Title = "Robben", Length = "2:29"},
                new Song {Title = "Vuosii", Length = "2:04"},
                new Song {Title = "5", Length = "2:08"},
                new Song {Title = "Movie", Length = "2:26"},
                new Song {Title = "Duomo", Length = "2:17", Features = "Pyrythekid"}
            };
            Console.WriteLine("CD:");
            Console.WriteLine($"    -Artist: {cd1.Artist}");
            Console.WriteLine($"    -Name: {cd1.Title}");
            Console.WriteLine($"    -Genre: {cd1.Genre}");
            Console.WriteLine($"    -Price: ${cd1.Price}");
            Console.WriteLine($"    Songs:");
            foreach (Song song in cd1.Songs)
            {
                if (song.Features != null) { 
                Console.WriteLine($"        ---Name: {song.Title} (feat. {song.Features}) - {song.Length}");
                }
                else { Console.WriteLine($"        ---Name: {song.Title} - {song.Length}"); }
            }
            Console.WriteLine(cd1.PlayAllSongs());
            Console.WriteLine(cd1.PlaySong(4));
        }
    }
}
