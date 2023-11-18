using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise_22
{
    public class Card
    {
        public string Suit {  get; set; }
        public string Value { get; set; }
    }
    public class CardDeck
    {
        public List<Card> Cards {get; set;}
        public List<Card> GenerateCards() // Generate all of the 52 cards and assign letters if applicable using DetermineValue()
        {
            List<Card> cards = new List<Card>();
            for (int i = 0; i <= 4; i++)
            {
                
                for (int j = 1; j <= 13; j++)
                {
                    if (i == 0) { cards.Add(new Card { Suit = "Spades", Value = DetermineValue(j.ToString()) }); }
                    else if (i == 1) { cards.Add(new Card { Suit = "Clubs", Value = DetermineValue(j.ToString()) }); }
                    else if (i == 2) { cards.Add(new Card { Suit = "Hearts", Value = DetermineValue(j.ToString()) }); }
                    else if (i == 3) { cards.Add(new Card { Suit = "Diamonds", Value = DetermineValue(j.ToString()) }); }
                }
            }
            return cards;
        }
        public CardDeck ShuffleDeck(CardDeck deck) // Change the position of a random card 200 times
        {
            int min = 0;
            int max = deck.Cards.Count;
            Random rnd = new Random();
            for (int i = 0; i < 200; i++)
            {
                Card card = deck.Cards[rnd.Next(min, max)];
                deck.Cards.Remove(card);
                deck.Cards.Add(card);
            }
            return deck;
        }
        public string DetermineValue(string value) // Assign letter (A, J, Q or K) to corresponding values
        {
            if (value == "11") { value = "J"; }
            else if (value == "12") { value = "Q"; }
            else if (value == "13") { value = "K"; }
            else if (value == "1") { value = "A"; }
            return value;
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            CardDeck deck = new CardDeck();
            deck.Cards = deck.GenerateCards();
            Console.WriteLine($"There are {deck.Cards.Count()} cards:");
            foreach(Card card in deck.Cards)
            {
                Console.WriteLine($"{card.Value} of {card.Suit}");
            }
            deck.ShuffleDeck(deck); // Shuffle the deck
            Console.WriteLine($"There are {deck.Cards.Count()} cards in the shuffled deck:"); 
            foreach (Card card in deck.Cards)
            {
                Console.WriteLine($"{card.Value} of {card.Suit}");
            }
        }
    }
}
