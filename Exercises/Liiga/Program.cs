using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Liiga
{
    public class Player
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int PlayerNumber { get; set; }
        public string Position { get; set; }
    }
    public class Team
    {
        public string Name { get; set; }
        public string HomeTown { get; set; }
        public List<Player> Players { get; set; }
        public Team(string team)
        {
            Name = team;
            if (team == "Pelicans")
            {
                Players = new List<Player>()
                {
                    new Player() { FirstName = "Ryan", LastName = "Lasch", PlayerNumber = 81, Position = "Right Wing" },
                    new Player() { FirstName = "Antti", LastName = "Tyrväinen", PlayerNumber = 89, Position = "Left Wing" },
                    new Player() { FirstName = "Juho", LastName = "Olkinuora", PlayerNumber = 45, Position = "Goaltender" },
                    new Player() { FirstName = "Anton", LastName = "Mylläri", PlayerNumber = 59, Position = "Defense" }
                };

            }
            else if (team == "Ilves")
            {
                Players = new List<Player>()
                {
                    new Player() { FirstName = "Jérémy", LastName = "Grégoire", PlayerNumber = 25, Position = "Center" },
                    new Player() { FirstName = "Jani", LastName = "Nyman", PlayerNumber = 33, Position = "Left Wing" },
                    new Player() { FirstName = "Jakub", LastName = "Malek", PlayerNumber = 31, Position = "Goaltender" },
                    new Player() { FirstName = "Niklas", LastName = "Friman", PlayerNumber = 3, Position = "Defense" }
                };
            }
            else if (team == "Kärpät")
            {
                Players = new List<Player>()
                {
                    new Player() { FirstName = "Joonas", LastName = "Kemppainen", PlayerNumber = 53, Position = "Center" },
                    new Player() { FirstName = "Marko", LastName = "Anttila", PlayerNumber = 12, Position = "Right Wing" },
                    new Player() { FirstName = "Niclas", LastName = "Westerholm", PlayerNumber = 23, Position = "Goaltender" },
                    new Player() { FirstName = "Atte", LastName = "Ohtamaa", PlayerNumber = 55, Position = "Defense" }
                };
            }
        }
        public string RemovePlayer(Player player)
        {

            if (Players.Contains(player))
            {
                Player tempPlayer = player;
                Players.Remove(player); return $"Player {tempPlayer.FirstName} {tempPlayer.LastName} has been removed from {Name}.";
            }
            else { return "Could not remove player"; }
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {

            while (true)
            {
                Console.WriteLine("Clear screen by pressing enter, exit with input 'exit'. ");
                Console.WriteLine("Enter team name (Pelicans, Ilves, Kärpät): ");

                string teamName = Console.ReadLine();
                if (teamName == "Pelicans" || teamName == "Ilves" || teamName == "Kärpät")
                {
                    Console.Clear();
                    Team team = new Team(teamName);
                    Console.WriteLine(team.Name);
                    Console.WriteLine("   -Hometown:");
                    Console.WriteLine($"      --{team.HomeTown}");
                    Console.WriteLine("   -Players:");
                    foreach (Player player in team.Players)
                    {
                        Console.WriteLine($"      --{player.FirstName} {player.LastName}, {player.PlayerNumber}, {player.Position}");
                    }
                    Console.WriteLine("Continue with enter, remove player by typing in his number: ");
                    int delPlayer = Int32.Parse(Console.ReadLine());

                    for (int i = 0; i < team.Players.Count() - 1; i++)
                    {
                        if (team.Players[i].PlayerNumber == delPlayer)
                        {
                            Console.WriteLine(team.RemovePlayer(team.Players[i]));

                        }

                    }
                    Console.ReadLine();

                }
                else if (teamName == "exit") { break; }
                else if (teamName == "") { Console.Clear(); }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Enter one of the specified teams!");
                }
            }
        }
    }
}
