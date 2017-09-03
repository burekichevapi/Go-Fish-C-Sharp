using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Go_Fish
{
    class StartGame
    {
        static void Main(string[] args)
        {
            Card[] deck = Card.InitializeDeck();
            int turn = 0;
            Player Player1 = new Player(name:"Amer");
            Player Player2 = new Player(name:"Terry");
            Player1.Draw9Cards(deck);
            Player2.Draw9Cards(deck);
            while(Card.books > 0)
            {
                while(turn == 0)
                {
                    Player1.CheckIfZeroCards(deck);
                    Player1.AskForRank();
                    while(Player1.CheckIfOpponentHasRankInHand(Player2))
                    {
                        Player2.GiveCardTo(Player1);
                        if(Player1.CheckForBooks() != null) { Player1.DiscardBooks(); Player1.AddOneCounterForBooks(); }
                        Player2.CheckIfZeroCards(deck);
                        Player1.CheckIfZeroCards(deck);
                    }
                    { Player1.DrawCard(deck); turn++; }
                }
                while(turn == 1)
                {
                    Player2.CheckIfZeroCards(deck);
                    Player2.AskForRank();
                    while(Player2.CheckIfOpponentHasRankInHand(Player1))
                    {
                        Player1.GiveCardTo(Player2);
                        if(Player2.CheckForBooks() != null) { Player2.DiscardBooks(); Player2.AddOneCounterForBooks(); }
                        Player2.CheckIfZeroCards(deck);
                        Player2.CheckIfZeroCards(deck);
                    }
                    { Player2.DrawCard(deck); turn = 0; }
                }
            }
            Console.ReadKey();
        }
    }
}
