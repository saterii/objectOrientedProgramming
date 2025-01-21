using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Instrumentation;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Text;
using System.Threading.Tasks;

namespace Exercise_18
{
    public abstract class Item
    {
        public string Owner { get; set; }
        public int BoughtIn { get; set; }

    }
    public class ElectricDevice : Item
    {
        public bool IsOn = false;
        public string Brand { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public bool IsWorking { get; set; }

        public void TogglePower()
        {
            if (IsOn) { IsOn = false; }
            else { IsOn = true; }
        }
    }
    public class Readable : Item
    {
        public string Title { get; set; }
        public int Pages { get; set; }
        public string ReleaseDate { get; set; }
        public string Language { get; set; }
    }
    public class Phone : ElectricDevice
    {
        public string PhoneType { get; set; }
        public string PhoneNumber { get; set; }

        public string MakeACall(string phonenumber)
        {
            return $"Making a call to {phonenumber}";
        }
        public string ShowData()
        {
            return $"Phone bought in {BoughtIn}, Owner {Owner}, Brand and model: {Brand} {Model}, Is on: {IsOn}, Release year: {Year}, Is working: {IsWorking}, Type: {PhoneType}, Number: {PhoneNumber}.";
        }
    }
    public class Laptop : ElectricDevice
    {
        public string GPUBrand { get; set; }
        public string ShowData()
        {
            return $"Laptop bought in {BoughtIn}, Owner {Owner}, Brand and model: {Brand} {Model}, Is on: {IsOn}, Release year: {Year}, Is working: {IsWorking}, GPU brand: {GPUBrand}.";
        }
    }
    public class Magazine : Readable
    {
        public string MagazineType { get; set; }
        public string ShowData()
        {
            return $"Magazine bought in {BoughtIn}, Owner {Owner}, Title: {Title}, Page count: {Pages}, Released in {ReleaseDate}, Language: {Language}, type of magazine: {MagazineType}";
        }
    }
    public class Book : Readable
    {
        public string Author { get; set; }
        public string Genre { get; set; }
        public string ShowData()
        {
            return $"Book bought in {BoughtIn}, Owner {Owner}, Title: {Title}, Page count: {Pages}, Released in {ReleaseDate}, Language: {Language}, Author: {Author}, Genre: {Genre}.";
        }
    }

    internal class TestBookshelf
    {
        static void Main(string[] args)
        {
            
            Phone SampsasPhone = new Phone()
            {
                BoughtIn = 2021,
                Owner = "Sampsa Tervo",
                Brand = "Oneplus",
                Model = "7T",
                Year = 2019,
                IsWorking = true,
                IsOn = true,
                PhoneType = "Touchscreen",
                PhoneNumber = "+358330123456"
            };
            Book book = new Book()
            {
                BoughtIn = 2022,
                Owner = "Sampsa Tervo",
                Title = "The Blade Itself",
                Pages = 515,
                ReleaseDate = "04-05-2006",
                Language = "English",
                Author = "Joe Abercrombie",
                Genre = "Grimdark/Fantasy"
            };
            Magazine magazine = new Magazine()
            {
                BoughtIn = 2023,
                Owner = "Sampsa Tervo",
                Title = "Keskisuomalainen",
                Pages = 42,
                ReleaseDate = "28-10-2023",
                Language = "Finnish",
                MagazineType = "Newspaper"
            };
            Console.WriteLine("Phone");
            Console.WriteLine(SampsasPhone.ShowData());
            Console.WriteLine(SampsasPhone.MakeACall("+358324324"));
            Console.WriteLine("Book");
            Console.WriteLine(book.ShowData());
            Console.WriteLine("Magazine");
            Console.WriteLine(magazine.ShowData());
        }
        
        
    }
}
