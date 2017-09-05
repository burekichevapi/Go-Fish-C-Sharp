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
        private int books = 0;

        public Player(string name)
        {
            this.name = name;
        }       //Player Constructor

        public void DrawCard(List<Card> deck)
        {    
            int drawCard = randCard.Next(deck.Count);  //Takes random card object and adds it to 'cardsInHand' List.
            this.cardsInHand.Add(deck[drawCard]);
            Console.WriteLine($"{deck[drawCard].Name}");
            deck.RemoveAt(drawCard);
            Console.WriteLine($"{this.name} drew 1 card.");
        }       //Adds a random card from deck to Player.cardsInHand and removes that same card from deck Array.

        public void Draw9Cards(List<Card> deck)     //Draws 9 cards to start game.
        {
            int x = 0;
            while(x < 9) { DrawCard(deck); x++; }
        }
        public string AskForRank()      //Takes input for which card rank the player is asking for and returns that value in a string.
        {
            try
            {
                Console.Write($"{this.name} Ask for a rank (Ace - 10, Jack, Queen, or King)... To see your hand type 'Hand': ");
                string input = Console.ReadLine().Trim();
                int totalLetters = input.Length;
                char firstLetter = char.ToUpper(input[0]);
                string restOfLetters = null;
                for(int i = 1; i < totalLetters; i++) { restOfLetters += char.ToLower(input[i]); }
                input = firstLetter.ToString() + restOfLetters;
                while(input == "Hand")
                {
                    Console.WriteLine($"\nYou have: ");
                    foreach(Card c in this.CardsInHand)
                    {
                        Console.WriteLine($"The {c.Name} ");
                    }
                    Console.Write($"{this.name} Ask for a rank (Ace - 10, Jack, Queen, or King)... To see your hand type 'Hand': ");
                    input = Console.ReadLine().Trim();
                    totalLetters = input.Length;
                    firstLetter = char.ToUpper(input[0]);
                    restOfLetters = null;
                    for(int i = 1; i < totalLetters; i++) { restOfLetters += char.ToLower(input[i]); }
                    input = firstLetter.ToString() + restOfLetters;
                }
                restOfLetters = null;
                for(int i = 1; i < totalLetters; i++) { restOfLetters += char.ToLower(input[i]); }
                //How to throw custom exception???
                return input;
            }
            catch
            {
                throw new ArgumentOutOfRangeException("You must pick Ace, 2 - 10, Jack, Queen, or King as a rank.");
            }
        }
        public bool CheckIfOpponentHasRankInHand(Player opponent, string askForRank )   //Tests if opponent has AskForRank() card in hand Returns true or false.
        {
            int numOfCards = opponent.CardsInHand.Count;
            int numberRank;
            if(int.TryParse(askForRank, out numberRank))
            {
                for(int c = 0; c < numOfCards; c++)
                {
                    int testCardInHand;
                    if(int.TryParse(opponent.CardsInHand[c].Rank, out testCardInHand))
                    {
                        if(numberRank == testCardInHand) { Console.WriteLine($"{opponent.name} has {testCardInHand}."); return true; }
                    }
                }
                Console.WriteLine($"{opponent.name} does not have this rank.");
                return false;
            }
            else
            {
                for(int c = 0; c < numOfCards; c++)
                {
                    if(string.Compare(opponent.CardsInHand[c].Rank, askForRank) == 0)
                    {
                        Console.WriteLine($"{opponent.name} has {opponent.cardsInHand[c].Rank}.");
                        return true;
                    }
                }
                Console.WriteLine($"{opponent.name} does not have this rank.");
                return false;
            }
        }

        public void GiveCardTo(Player player, string askForRank)          //Is triggered when CheckIfOpponentHasRankInHand is true. Loops through opponents hand and 
        {                                                                 // removes all cards from AskForRank() input and add them to players hand.
            int numOfCards = this.CardsInHand.Count;
            int numberRank;
            if(int.TryParse(askForRank, out numberRank))
            {
                foreach(Card c in this.CardsInHand.ToList())        //Why did I have to .ToList() CardsInHand?
                {
                    int testCardInHand;
                    if(int.TryParse(c.Rank, out testCardInHand))
                    {
                        if(numberRank == testCardInHand)
                        {
                            this.cardsInHand.Remove(c);
                            player.cardsInHand.Add(c);
                            Console.WriteLine($"{this.name} removed {c.Name} from hand and gave it to {player.name}.");
                        }
                    }
                }
            }
            else
            {
                foreach(Card c in this.CardsInHand.ToList())           //Why did I have to .ToList() CardsInHand?
                {
                    if(string.Compare(c.Rank, askForRank) == 0)
                    {
                        this.cardsInHand.Remove(c);
                        player.cardsInHand.Add(c);
                        Console.WriteLine($"{this.name} removed {c.Name} from hand and gave it to {player.name}.");
                    }
                }
            }
        }

        public void CheckIfZeroCards(List<Card> deck)       //Checks if cards in hand are = 0 and if deck.lenght > 0. If true, player adds 1 card.
        {
            if(deck.Count > 0 && this.CardsInHand.Count == 0) { this.DrawCard(deck); Console.WriteLine($"{this.name} has no cards in hand! draw 1 card."); }
        }

        public void AddOneCounterForBooks()       //Adds +1 to Books attribute.
        {
            this.books++;
            Console.WriteLine($"{this.name} Obtained 1 book!");
        }

        public bool DiscardBooks()      //Calls on CheckForBooks() and removes all 13 cards from cardsInHand of the same suit and --Card.books.
        {
            foreach(Card c in this.CardsInHand)
            {
                if(CheckForBooks() != null) { cardsInHand.Remove(c); Console.WriteLine($"{this.name} discards {c.Name}."); return true; }
            }
            return false;
        }

        public string CheckForBooks()     //Loops through players cardInHand and counts the total number of each suit player has. 
        {                                 //If suit = 13 suit is returned as a string.
            int spades = 0, hearts = 0, diamonds = 0, clubs = 0;
            foreach(Card c in this.CardsInHand)
            {
                if(c.Suit == "Spades")
                {
                    spades++; if(spades == 13) { Console.WriteLine($"{this.name} collected a Book of Spades"); return "Spades"; }
                }
                if(c.Suit == "Hearts")
                {
                    hearts++; if(hearts == 13) { Console.WriteLine($"{this.name} collected a Book of Hearts"); return "Hearts"; }
                }
                if(c.Suit == "Diamonds")
                {
                    diamonds++; if(diamonds == 13) { Console.WriteLine($"{this.name} collected a Book of Diamonds"); return "Diamonds"; }
                }
                if(c.Suit == "Clubs")
                {
                    clubs++; if(clubs == 13) { Console.WriteLine($"{this.name} collected a Book of Clubs"); return "Clubs"; }
                }
            }
            return null;
        }

        private List<Card> CardsInHand => cardsInHand;
        public int Books => books;
        public string Name => name;
    }

}
