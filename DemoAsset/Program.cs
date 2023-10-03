using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jamk.IT.TTC8440.DemoAsset
{
    public class Asset
    {
        public string Name { get; set; }
        public virtual decimal Value { get; set; }
    }
    public class Gold : Asset
    {
        public double Weight { get; set; }
        public decimal DailyPrice { get; private set; }
        public Gold(double weight, decimal dailyPrice)
        {
            Weight = weight;
            DailyPrice = dailyPrice;
        }
        public override decimal Value => (decimal)Weight * DailyPrice;
    }
    public class Stock : Asset
    {
        public long SharesOwned { get; set; }
        public decimal ValuePerShare { get; set; }
        public override decimal Value => (decimal)SharesOwned * ValuePerShare;
    }
    internal class TestAsset
    {
        public static void TestMyValuableThings()
        {
            // Collection of valuable things

            List<Asset> myProperty = new List<Asset>();

            Gold GoldBar1 = new Gold(13200, 55.97M);
            GoldBar1.Name = "Goldbar1";
            Console.WriteLine(GoldBar1.Value);
            Stock Nokia = new Stock();
                Nokia.Name = "Nokia";
                Nokia.ValuePerShare = 3.54M;
                Nokia.SharesOwned = 130;
            myProperty.Add(Nokia);
            myProperty.Add(GoldBar1 );
            Console.WriteLine("Your assets:");
            foreach (Asset x in myProperty)
            {
                Console.WriteLine(x.Name);
            }
        }
        static void Main(string[] args)
        {
            TestMyValuableThings();
        }
    }
}
