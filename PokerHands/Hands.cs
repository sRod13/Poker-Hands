using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerHands
{
    public class Hands : Deck //Deal out card hands for two players
    {
        public Hands()
        {
            _playerOneHand = new Card[5];
            _playerTwoHand = new Card[5];
        }

        public void DealCards(string firstPlayerName, string secondPlayerName)  //Constructor takes two player names
        {
            _playerOneName = firstPlayerName;
            _playerTwoName = secondPlayerName;

            ShuffleDeck();  //Shuffle the deck before distributing cards to players

            for (int i = 0; i < 5; i++)
            {
                _playerOneHand[i] = DeckOfCards[i];  //First player receives top five cards from the deck
                _playerTwoHand[i] = DeckOfCards[i + 5];  //Second player receives next five cards from the deck
            }
        }

        public void ShowHands()
        {
            Array.Sort(_playerOneHand, delegate(Card x, Card y) { return y.CardValue.CompareTo(x.CardValue); });  //Order the first player's cards by value, highest to lowest
            Array.Sort(_playerTwoHand, delegate (Card x, Card y) { return y.CardValue.CompareTo(x.CardValue); });  //Order the second player's cards by value, highest to lowest

            Console.WriteLine("{0} has:", _playerOneName);  //Display the first player's ordered cards
            foreach (Card p in _playerOneHand)
            {
                Console.WriteLine("{0} of {1}", p.CardValue, p.CardSuit);
            }

            Console.WriteLine("\n{0} has:", _playerTwoName);  //display the second player's ordered cards
            foreach (Card p in _playerTwoHand)
            {
                Console.WriteLine("{0} of {1}", p.CardValue, p.CardSuit);
            }
        }


        public void EvaluateWinner()  // Evalute the player hands and determine a winner
        {
            EvaluateHand evaluatePlayerOne = new EvaluateHand(PlayerOneHand);
            EvaluateHand evaluatePlayerTwo = new EvaluateHand(PlayerTwoHand);

            if (evaluatePlayerOne.GetHandValue() > evaluatePlayerTwo.GetHandValue())  // See if we have a clear winner based on poker hand rank alone
            {
                Console.WriteLine("\n{0} wins with {1}.", _playerOneName, evaluatePlayerOne.GetHandValue());
            }
            else if (evaluatePlayerOne.GetHandValue() < evaluatePlayerTwo.GetHandValue())
            {
                Console.WriteLine("\n{0} wins with {1}.", _playerTwoName, evaluatePlayerTwo.GetHandValue());
            }
            else if (evaluatePlayerOne.GetHandValue() == evaluatePlayerTwo.GetHandValue())  // If poker hands are equal, compare the high card value of the poker hand to determine a winner
            {
                if (evaluatePlayerOne.HighCard > evaluatePlayerTwo.HighCard)
                {
                    Console.WriteLine("\nBoth players have {0} but {1} wins with high card value of {2}.", evaluatePlayerOne.GetHandValue(), _playerOneName, evaluatePlayerOne.HighCard);
                }
                else if (evaluatePlayerOne.HighCard < evaluatePlayerTwo.HighCard)
                {
                    Console.WriteLine("\nBoth players have {0} but {1} wins with high card value of {2}.", evaluatePlayerTwo.GetHandValue(), _playerTwoName, evaluatePlayerTwo.HighCard);
                }
                else if (evaluatePlayerOne.HighCard == evaluatePlayerTwo.HighCard)  // If poker hand high cards are equal, look at the remaining cards to see if we can determine a winner. Two pair presents an issue due to the possible ordering of the cards.
                {
                    for (int i = 0; i < 5; i++)
                    {
                        if (PlayerOneHand[i].CardValue > PlayerTwoHand[i].CardValue)
                        {
                            Console.WriteLine("\nBoth players have {0} but {1} wins with high card value of {2}.", evaluatePlayerOne.GetHandValue(), _playerOneName, PlayerOneHand[i].CardValue);
                            break;
                        }
                        else if (PlayerOneHand[i].CardValue < PlayerTwoHand[i].CardValue)
                        {
                            Console.WriteLine("\nBoth players have {0} but {1} wins with high card value of {2}.", evaluatePlayerTwo.GetHandValue(), _playerTwoName, PlayerTwoHand[i].CardValue);
                            break;
                        }
                    }
                }
                else  // If all values are equal we have a tie
                {
                    Console.WriteLine("\nWow! A tie!");
                }
            }
        }

        public Card[] PlayerOneHand
        {
            get { return _playerOneHand; }
            set { _playerOneHand = value; }
        }

        public Card[] PlayerTwoHand
        {
            get { return _playerTwoHand; }
            set { _playerTwoHand = value; }
        }

        private Card[] _playerOneHand;
        private Card[] _playerTwoHand;
        private string _playerOneName;
        private string _playerTwoName;
    }
}
