using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Xml.Linq;

namespace Exercise_27
{
    public class Player
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Position { get; set; }
        public int PlayerNumber { get; set; }

    }
    public class Team
    {
        public string TeamName { get; set; }
        public string HomeTown { get; set; }
        public List<Player> Players { get; set; }


        public Team(string teamName) // Add a few players to team depending on input
        {
            TeamName = teamName;
            if (teamName == "Pelicans")
            {
                HomeTown = "Lahti";
                Players = new List<Player>()
                {
                    new Player() { FirstName = "Ryan", LastName = "Lasch", PlayerNumber = 81, Position = "Right Wing" },
                    new Player() { FirstName = "Antti", LastName = "Tyrväinen", PlayerNumber = 89, Position = "Left Wing" },
                    new Player() { FirstName = "Juho", LastName = "Olkinuora", PlayerNumber = 45, Position = "Goaltender" },
                    new Player() { FirstName = "Anton", LastName = "Mylläri", PlayerNumber = 59, Position = "Defense" }
                };

            }
            else if (teamName == "Ilves")
            {
                HomeTown = "Tampere";
                Players = new List<Player>()
                {
                    new Player() { FirstName = "Jérémy", LastName = "Grégoire", PlayerNumber = 25, Position = "Center" },
                    new Player() { FirstName = "Jani", LastName = "Nyman", PlayerNumber = 33, Position = "Left Wing" },
                    new Player() { FirstName = "Jakub", LastName = "Malek", PlayerNumber = 31, Position = "Goaltender" },
                    new Player() { FirstName = "Niklas", LastName = "Friman", PlayerNumber = 3, Position = "Defense" }
                };
            }
            else if (teamName == "Kärpät")
            {
                HomeTown = "Oulu";
                Players = new List<Player>()
                {
                    new Player() { FirstName = "Joonas", LastName = "Kemppainen", PlayerNumber = 53, Position = "Center" },
                    new Player() { FirstName = "Marko", LastName = "Anttila", PlayerNumber = 12, Position = "Right Wing" },
                    new Player() { FirstName = "Niclas", LastName = "Westerholm", PlayerNumber = 23, Position = "Goaltender" },
                    new Player() { FirstName = "Atte", LastName = "Ohtamaa", PlayerNumber = 55, Position = "Defense" }
                };
            }
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Team> teams = new List<Team>();
            while (true)
            {
                Console.Clear();

                Console.WriteLine("1. Show teams");
                Console.WriteLine("2. Add team");
                Console.WriteLine("3. Remove team");
                Console.WriteLine("4. Save team's players to .csv");
                Console.WriteLine("'exit': close program");
                string action = Console.ReadLine();
                if (action == "exit") { break; }
                else if (action == "1") // Display data of all teams if there are teams in the collection
                {
                    if (teams.Count == 0) { Console.WriteLine("There are no teams in collection!"); Console.ReadLine(); }
                    else
                    {
                        foreach (Team t in teams)
                        {
                            Console.WriteLine(t.TeamName);
                            Console.WriteLine("   -Hometown:");
                            Console.WriteLine($"      --{t.HomeTown}");
                            Console.WriteLine("   -Players:");
                            foreach (Player player in t.Players)
                            {
                                Console.WriteLine($"      --{player.FirstName} {player.LastName}, {player.PlayerNumber}, {player.Position}");
                            };
                        }
                        Console.ReadLine();
                    }
                }
                else if (action == "2")
                {
                    Console.WriteLine("Enter team name to add (Pelicans, Kärpät, Ilves)");
                    string teamName = Console.ReadLine();
                    if (teamName == "Pelicans" || teamName == "Ilves" || teamName == "Kärpät")
                    {
                        Team team;
                        bool teamExists = false;
                        int teamIndex = 0;
                        for (int i = 0; i < teams.Count; i++) // If team exists, change flag to true to prevent creating multiple instances of same team
                        {
                            if (teams[i].TeamName == teamName)
                            {
                                teamExists = true;
                                teamIndex = i;
                                Console.WriteLine($"{teamName} already exists in collection!");
                                Console.ReadLine();
                                break;
                            }

                        }

                        if (!teamExists) { team = new Team(teamName); teams.Add(team); } // Create team if it doesn't exist
                        else { team = teams[teamIndex]; }
                        Console.WriteLine($"Added team {team.TeamName} to collection");
                        Console.ReadLine();
                    }

                    else
                    {
                        Console.WriteLine("Invalid input!");
                        continue;
                    }
                }
                else if (action == "3") // Remove team based on the team name that was input
                {
                    Console.WriteLine("Enter team to remove");
                    string teamToRemove = Console.ReadLine();
                    bool teamRemoved = false;
                    for (int i = 0; i < teams.Count; i++)
                    {
                        if (teams[i].TeamName == teamToRemove)
                        {
                            teams.RemoveAt(i);
                            teamRemoved = true;
                            Console.WriteLine($"Removed team {teamToRemove} from collection!");
                            Console.ReadLine();
                        }

                    }
                    if (!teamRemoved) { Console.WriteLine($"Team {teamToRemove} doesn't exist in collection!"); Console.ReadLine(); };
                }
                else if (action == "4")
                {
                    Console.WriteLine("Enter team to save data from:");
                    string teamToSave = Console.ReadLine();
                    bool teamSaved = false;
                    for (int i = 0; i < teams.Count; i++)
                    {
                        if (teams[i].TeamName == teamToSave)
                        {
                            string playersString = "";
                            foreach (Player p in teams[i].Players)
                            {
                                playersString += $"{p.FirstName};{p.LastName};{p.Position};{p.PlayerNumber} \n";
                            }

                            teamSaved = true;
                            StreamWriter writer = new StreamWriter(@"C:\Users\tervo\" + teamToSave + ".csv");
                            writer.WriteLine(playersString);
                            writer.Close();
                            
                            Console.WriteLine("Added player data to .csv!");
                            Console.ReadLine();
                        }

                    }
                    if (!teamSaved) { Console.WriteLine($"Team {teamToSave} doesn't exist in collection!"); Console.ReadLine(); };

                }
                else { continue; }
            }
        }
    }
}
