using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Go_Fish
{
    class MainGoFish
    {
        static void Main(string[] args)
        {
            Card[] deck = Card.InitializeDeck();
            bool winner = false;
            int turn = 0;
            Player Amer = new Player(name:"Amer");
            Player Terry = new Player(name:"Terry");
            Amer.Draw9Cards(deck);
            Terry.Draw9Cards(deck);
            while(!winner)
            {
                if(turn == 0)
                {
                    Amer.CheckIfZeroCards(deck);
                    Amer.AskForRank();
                    while(Amer.CheckIfOpponentHasRankInHand(Terry))
                    {
                        Terry.GiveCardTo(Amer);
                        Terry.CheckIfZeroCards(deck);
                        Amer.CheckIfZeroCards(deck);
                        Amer.AskForRank();
                    }
                    { Amer.DrawCard(deck); }
                }

            }

            Console.ReadKey();
        }
    }
}
