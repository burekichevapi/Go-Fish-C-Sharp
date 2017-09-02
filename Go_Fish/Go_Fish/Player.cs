using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Go_Fish
{
    class Player
    {
        Random randCard = new Random();
        private string name;
        private List<Card> cardsInHand = new List<Card>();
        int books = 0;

        public Player(string name)
        {
            this.name = name;
        }       //Player Constructor

        public void DrawCard(Card[] deck)
        {    
            int drawCard = randCard.Next(deck.Length);  //Takes random card object and adds it to 'cardsInHand' List.
            cardsInHand.Add(deck[drawCard]);

            List<Card> deckList = deck.ToList();   //Converts deck into List and removes the same card object; converts back to Array.
            deckList.RemoveAt(drawCard);
            deckList.ToArray();
        }       //Adds a random card from deck to Player.cardsInHand and removes that same card from deck Array.

        public void Draw9Cards(Card[] deck)     //Draws 9 cards to start game.
        {
            int x = 0;
            while(x < 9)
            {
                DrawCard(deck);
                x++;
            }
        }

        public string AskForRank()      //Takes input for which card rank the player is asking for and returns that value in a string.
        {
            Console.Write("Write a rank: ");
            return Console.ReadLine();
        }

        public bool CheckIfOpponentHasRankInHand(Player opponent)   //Tests if opponent has AskForRank() card in hand Returns true or false.
        {
            foreach(Card c in opponent.cardsInHand)
            {
                if (c.Rank == AskForRank())
                {
                    return true;
                }
            }
            return false;
        }

        public void GiveCardTo(Player player )          //Is triggered when CheckIfOpponentHasRankInHand is true. Loops through opponents hand and 
        {                                            // removes all cards from AskForRank() input and add them to players hand.
            foreach(Card c in this.cardsInHand)
            {
                if(c.Rank == AskForRank())
                {
                    this.cardsInHand.Remove(c);
                    player.cardsInHand.Add(c);
                }
            }
        }

        public void CheckIfZeroCards(Card[] deck)       //Checks if cards in hand are = 0 and if deck.lenght > 0. If true, player adds 1 card.
        {
            if(deck.Length > 0 && this.cardsInHand.Count == 0)
            {
                this.DrawCard(deck);
            }
        }

        public void AddOneCounterForBooks()
        {
            this.books++;
        }       //Adds +1 to Books attribute.

        public void DiscardBooks()      //Calls on CheckForBooks() and removes all 13 cards from cardsInHand of the same suit and --Card.books.
        {
            foreach(Card c in this.cardsInHand)
            {
                if(c.Suit == CheckForBooks()) { cardsInHand.Remove(c); Card.books--; }
            }
        }

        public string CheckForBooks()     //Loops through players cardInHand and counts the total number of each suit player has. 
        {                                 //If suit = 13 suit is returned as a string.
            int spades = 0, hearts = 0, diamonds = 0, clubs = 0;
            foreach(Card c in this.cardsInHand)
            {
                if(c.Suit == "Spades")
                {
                    spades++; if(spades == 13) { return "Spades"; }
                }
                if(c.Suit == "Hearts")
                {
                    hearts++; if(hearts == 13) { return "Hearts"; }
                }
                if(c.Suit == "Diamonds")
                {
                    diamonds++; if(diamonds == 13) { return "Diamonds"; }
                }
                if(c.Suit == "Clubs")
                {
                    clubs++; if(clubs == 13) { return "Clubs"; }
                }
            }
            return null;
        }

        private List<Card> CardsInHand => cardsInHand;
    }

}
