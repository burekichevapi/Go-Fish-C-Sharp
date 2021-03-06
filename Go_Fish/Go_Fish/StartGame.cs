﻿using System;
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
            List<Card> deck = Card.InitializeDeck();
            int turn = 0;
            Player Player1 = new Player(name:"Player 1");
            Player Player2 = new Player(name:"Player 2");
            Player1.Draw9Cards(deck);
            Player2.Draw9Cards(deck);

            while(Card.books > 0)
            {
                while(turn == 0)
                {
                    Player1.CheckIfZeroCards(deck);
                    Player2.CheckIfZeroCards(deck);
                    string askForRank = Player1.AskForRank();
                    while(askForRank == null)
                    {
                        askForRank = Player1.AskForRank();
                    }
                    if(Player1.CheckIfOpponentHasRankInHand(Player2, askForRank))
                    {
                        Player1.CheckIfZeroCards(deck);
                        Player2.GiveCardTo(Player1, askForRank);
                        Player1.CheckIfZeroCards(deck);
                        Player2.CheckIfZeroCards(deck);
                        if(Player1.DiscardBooks())
                        {
                            Card.books--;
                            Player1.AddOneCounterForBooks();
                        }
                        if(Card.books == 0)
                        {
                            break;
                        }
                        Player1.CheckIfZeroCards(deck);
                    }
                    else { Player1.DrawCard(deck); turn++; Console.WriteLine("Your turn is over, please press any key to pass the turn..."); Console.ReadKey(); Console.Clear(); Console.WriteLine($"{Player2.Name}'s turn."); }
                }
                while(turn == 1)
                {
                    Player2.CheckIfZeroCards(deck);
                    Player1.CheckIfZeroCards(deck);
                    string askForRank = Player2.AskForRank();
                    while(askForRank == null)
                    {
                        askForRank = Player2.AskForRank();
                    }
                    if(Player2.CheckIfOpponentHasRankInHand(Player1, askForRank))
                    {
                        Player2.CheckIfZeroCards(deck);
                        Player1.GiveCardTo(Player2, askForRank);
                        Player1.CheckIfZeroCards(deck);
                        Player2.CheckIfZeroCards(deck);
                        if(Player2.DiscardBooks())
                        {
                            Card.books--;
                            Player2.AddOneCounterForBooks();
                        }
                        if(Card.books == 0)
                        {
                            break;
                        }
                        Player2.CheckIfZeroCards(deck);
                    }
                    else { Player2.DrawCard(deck); turn = 0; Console.WriteLine("Your turn is over, please press any key to pass the turn..."); Console.ReadKey(); Console.Clear(); Console.WriteLine($"{Player1.Name}'s turn."); }
                }
            }
            if(Player1.Books > Player2.Books) { Console.WriteLine($"{Player1.Name} wins with {Player1.Books} Books!"); }
            else if(Player1.Books > Player2.Books) { Console.WriteLine($"{Player2.Name} wins with {Player2.Books} Books!"); }
            else { Console.WriteLine($"We have a draw."); }
            Console.ReadKey();
        }
    }
}