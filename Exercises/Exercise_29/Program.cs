using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Exercise_29
{
    public interface ITransaction
    {
        // interface members
        string ShowTransaction();
        float Money { get; set; }
    }
    public class Paid
    {
        public static int TransactionID;
        public static float BankAccountBalance { get;  set; }
        public static float CashRegisterBalance { get;  set; }
        public string ShowAllMoney()
        {
            return $"Total sales: {BankAccountBalance + CashRegisterBalance}$";
        }
    }
    public class PaidWithCash : Paid, ITransaction
    {
        public int CashTransactionID { get; set; }
        public float Money { get; set; }
        public string TransactionDate { get; set; }
        public float CashBalance = 0;
        public string ShowCash()
        {
            return $"Total money in cash register: {CashRegisterBalance}$";
        }
        public string ShowTransaction()
        {
            CashRegisterBalance += Money;
            return $"Transaction {CashTransactionID} of {Money}$ was made with cash on {TransactionDate}.";
        }
        public PaidWithCash()
        {
            CashTransactionID = Interlocked.Increment(ref TransactionID);
        }
    }
    public class PaidWithCard : Paid, ITransaction
    {
        public int CardTransactionID { get; set; }
        public float Money { get; set; }
        public string AccountNumber { get; set; }
        public string TransactionDate { get; set; }
        public string ShowTotal()
        {
            return $"Total money in bank account: {BankAccountBalance}$";
        }
        public string ShowTransaction()
        {
            BankAccountBalance += Money;
            return $"Transaction {CardTransactionID} to bank from card {AccountNumber} was made in {TransactionDate} with amount {Money}$.";
        }
        public PaidWithCard()
        {
            CardTransactionID = Interlocked.Increment(ref TransactionID);
        }

    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Paid paid = new Paid();
            PaidWithCard purchase1 = new PaidWithCard() { Money = 125.64F, AccountNumber = "A9761-4352-76", TransactionDate = "17.11.2023" };
            PaidWithCard purchase2 = new PaidWithCard() { Money = 43.12F, AccountNumber = "A3321-5453-22", TransactionDate = "17.11.2023" };
            Console.WriteLine(purchase1.ShowTransaction());
            Console.WriteLine(purchase2.ShowTransaction());
            Console.WriteLine(purchase1.ShowTotal());
            PaidWithCash purchase3 = new PaidWithCash() { Money = 100, TransactionDate = "17.11.2023" };
            PaidWithCash purchase4 = new PaidWithCash() { Money = 35, TransactionDate = "17.11.2023" };
            Console.WriteLine(purchase3.ShowTransaction());
            Console.WriteLine(purchase4.ShowTransaction());
            Console.WriteLine(purchase4.ShowCash());
            Console.WriteLine(paid.ShowAllMoney());
        }
    }
}
