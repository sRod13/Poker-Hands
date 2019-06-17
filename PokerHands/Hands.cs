using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerHands
{
    class Hands  //Deal out card hands for two players
    {
        public Hands()
        {
            playerOneHand = new Card[5];
            playerTwoHand = new Card[5];
        }

        public void dealCards(Deck someDeck, string firstPlayerName, string secondPlayerName)  //Constructor takes a deck and two player names
        {
            playerOneName = firstPlayerName;
            playerTwoName = secondPlayerName;

            for (int i = 0; i < 5; i++)
            {
                playerOneHand[i] = someDeck.getDeck[i];  //First player receives top five cards from the deck
                playerTwoHand[i] = someDeck.getDeck[i + 5];  //Second player receives next five cards from the deck
            }
        }

        public void showHands()
        {
            Array.Sort(playerOneHand, delegate(Card x, Card y) { return y.CardValue.CompareTo(x.CardValue); });  //Order the first player's cards by value, highest to lowest
            Array.Sort(playerTwoHand, delegate (Card x, Card y) { return y.CardValue.CompareTo(x.CardValue); });  //Order the second player's cards by value, highest to lowest

            Console.WriteLine("{0} has:", playerOneName);  //Display the first player's ordered cards
            foreach (Card p in playerOneHand)
            {
                Console.WriteLine("{0} of {1}", p.CardValue, p.CardSuit);
            }

            Console.WriteLine("\n{0} has:", playerTwoName);  //display the second player's ordered cards
            foreach (Card p in playerTwoHand)
            {
                Console.WriteLine("{0} of {1}", p.CardValue, p.CardSuit);
            }
        }

        private Card[] playerOneHand;
        private Card[] playerTwoHand;
        private string playerOneName;
        private string playerTwoName;
    }
}
