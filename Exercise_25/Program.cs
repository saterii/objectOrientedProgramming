using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise_25
{
    public class Human
    {
        public string Name { get; set; }
        public int BirthYear { get; set; }
        public int Age { get { return 2023 - BirthYear; } }
    }
    public class Actor : Human
    {
        public List<string> Awards { get; set; }
    }
    public class Director : Human
    {
        public int MoviesDirected { get; set; }
    }
    public class Movie
    {
        public string Title { get; set; }
        public int Year { get; set; }
        public Director Director { get; private set; }
        public List<Actor> Actors { get; private set; }
        
        public void AddCast(Director director, List<Actor> actors)
        {
            Actors = new List<Actor>(actors);
            Director = director;
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Actor actor1 = new Actor() { Name = "Tom Hopper", BirthYear = 1985, Awards = new List<string> { "CinEuphoria Award" } };
            Actor actor2 = new Actor() { Name = "Tobias Menzies", BirthYear = 1974, Awards = new List<string> { "Primetime Emmy", "Satellite Award", "SAG Award" } };
            Actor actor3 = new Actor() { Name = "Natalie Dormer", BirthYear = 1982, Awards = new List<string> { "EWwy Award", "Empire Award", "CinEuphoria Award" } };
            Director director1 = new Director() { Name = "Cristopher Nolan", BirthYear = 1970, MoviesDirected = 17 };
            Director director2 = new Director() { Name = "Ridley Scott", BirthYear = 1937, MoviesDirected = 52 };

            Movie movie1 = new Movie() { Title = "Not a Real Movie", Year = 2022 };
            Movie movie2 = new Movie() { Title = "Another Fake Movie 2", Year = 2022 };
            Movie movie3 = new Movie() { Title = "Another Fake Movie 3", Year = 2023 };
            movie1.AddCast(director1, new List<Actor> { actor1, actor2 });
            movie2.AddCast(director2, new List<Actor> { actor2, actor3 });
            movie3.AddCast(director2, new List<Actor> { actor1, actor2, actor3 });

            List<Movie> movies = new List<Movie>() {  movie1, movie2, movie3 };

            foreach (Movie movie in movies)
            {
                Console.WriteLine("Movie: ");
                Console.WriteLine($" Title: {movie.Title}");
                Console.WriteLine($" Release year: {movie.Year}");
                Console.WriteLine($" Director: {movie.Director.Name}");
                Console.WriteLine($"   Movies directed: {movie.Director.MoviesDirected}");
                Console.WriteLine(" Actors:");
                foreach(Actor actor in movie.Actors)
                {
                    Console.WriteLine($"   {actor.Name}, Age {actor.Age}");
                    Console.WriteLine($"        Birth year: {actor.BirthYear}");
                    Console.WriteLine($"        Awards won:");
                    foreach(string award in actor.Awards)
                    {
                        Console.WriteLine($"         Award name: {award}");
                    }
                }
            }
        }
    }
}
