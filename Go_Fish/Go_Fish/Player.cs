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
        int _books = 0;
        public Player(string name)
        {
            this.name = name;
        }
        public void DrawCard(Card[] deck)
        {    
            int drawCard = randCard.Next(deck.Length);  //Takes random card object and adds it to 'cardsInHand' List.
            cardsInHand.Add(deck[drawCard]);

            List<Card> deckList = deck.ToList();   //Converts deck into List and removes the same card object; converts back to Array.
            deckList.RemoveAt(drawCard);
            deckList.ToArray();
        }
        public void Draw9Cards(Card[] deck)     //Draws 9 cards to start game.
        {
            int x = 0;
            while(x < 9)
            {
                DrawCard(deck);
                x++;
            }
        }

        public string AskForRank()
        {
            Console.Write("Write a rank: ");
            return Console.ReadLine();
        }

        public bool CheckIfOpponentHasRankInHand(Player opponent)
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
        public void GiveCardTo(Player player)
        {
            foreach(Card c in this.cardsInHand)
            {
                if(c.Rank == AskForRank())
                {
                    this.cardsInHand.Remove(c);
                    player.cardsInHand.Add(c);
                }
            }
        }

        public void CheckIfZeroCards(Card[] deck)
        {
            if(deck.Length > 0)
            {
                if(this.cardsInHand.Count == 0)
                {
                    this.DrawCard(deck);
                }
            }
        }

        public List<Card> CardsInHand => cardsInHand;
    }

}
