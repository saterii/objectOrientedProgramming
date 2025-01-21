using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Globalization;

namespace Exercise_33
{
    internal class Program
    {
        public class Friend
        {
            public string Name { get; set; }
            public string Email { get; set; }
        }
        public class MailBook
        {
            public readonly List<Friend> Friends;

            public string AddFriend(string name, string email)
            {
                try
                {
                    Friends.Add(new Friend() { Name = name, Email = email });
                    using (StreamWriter sw = File.AppendText("../../friends.csv"))
                    {
                        sw.WriteLine($"{name}\t{email}");
                    }
                    return $"Added friend with name {name}";
                }
                catch (Exception ex) { return "Failed with error" + ex; }
            }

            public MailBook()
            {
                Friends = new List<Friend>();
                try
                {
                    string[] lines = File.ReadAllLines("../../friends.csv");
                    foreach (string line in lines)
                    {
                        string[] parts = line.Split(new char[] { '	' });
                        Friends.Add(new Friend() { Name = parts[0], Email = parts[1] });
                    }
                }catch (Exception ex) { Console.WriteLine(ex); }
            }
        }
        static void Main(string[] args)
        {
            while(true)
            {
                MailBook mb = new MailBook();
                Console.WriteLine($"{mb.Friends.Count()} names in the address book:");
                foreach(Friend friend in mb.Friends)
                {
                    Console.WriteLine(friend.Name);
                }
                Console.Write("1. Search for a friend, 2. Add friend: ");
                string action = Console.ReadLine();
                if (action == "1")
                {
                    Console.Write("Enter the name or part of the name of the person you are looking for: ");
                    string partialString = Console.ReadLine();
                    var matches = from friend in mb.Friends
                                   where friend.Name.ToLower().StartsWith(partialString)
                                   select friend;
                    foreach (Friend friend in matches)
                    {
                        Console.WriteLine(friend.Name + " " + friend.Email);
                    }
                    Console.ReadLine();
                    Console.WriteLine();
                }
                else if (action == "2")
                {
                    Console.Write("Enter friend's name: ");
                    string newName = Console.ReadLine();
                    Console.Write("Enter friend's email: ");
                    string newEmail = Console.ReadLine();
                    Console.WriteLine(mb.AddFriend(newName, newEmail));
                    Console.ReadLine();
                    Console.WriteLine();
                }
            }
        }
    }
}
