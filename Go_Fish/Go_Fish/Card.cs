using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Go_Fish
{
    class Card
    {
        private string suit;
        private string rank;
        private string name;
        public static int books = 4;

        private Card(int suit, int rank )        //Constructor for Card.
        {
            this.suit = SetSuit(suit);
            this.rank = SetRank(rank);
            this.name = $"{this.rank} of {this.suit}";
        }
        private string SetSuit(int suit)        //Sets all suits for cards.
        {
            switch (suit)
            {
                case 0:
                    return "Spades";
                case 1:
                    return "Hearts";
                case 2:
                    return "Diamonds";
                default:
                    return "Clubs";
            }
        }
        private string SetRank( int rank )        //Sets all ranks for cards.
        {
            switch(rank)
            {
            case 0:
                return "Ace";
            case 1:
                return "2";
            case 2:
                return "3";
            case 3:
                return "4";
            case 4:
                return "5";
            case 5:
                return "6";
            case 6:
                return "7";
            case 7:
                return "8";
            case 8:
                return "9";
            case 9:
                return "10";
            case 10:
                return "Jack";
            case 11:
                return "Queen";
            default:
                return "King";
            }
        }
        public static List<Card> InitializeDeck()       //Returns a 52 card Array.
        {
            var deck = new List<Card>();
            int suit = 0;
            int rank = 0;
            int d = 0;
            while(d < 52)
            {
                while(suit < 4)
                {
                    while(rank < 13)
                    {
                        deck.Add(new Card(suit, rank));
                        d++;
                        rank++;
                    }
                    rank = 0;
                    suit++;
                }
            }
            return deck;
        }

        public string Suit => suit;
        public string Rank => rank;
        public string Name => name;
    }
}