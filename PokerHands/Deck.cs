using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerHands
{
    class Deck : Card  //Standard 52 card deck
    {
        public Deck()
        {
            _deck = new Card[SizeOfDeck];

            int i = 0;
            foreach (Suit s in Enum.GetValues(typeof(Suit)))  //Generate the deck with all suite and value combinations
            {
                foreach (Value v in Enum.GetValues(typeof(Value)))
                {
                    _deck[i] = new Card { CardSuit = s, CardValue = v };
                    i++;
                }
            }
        }

        public Card[] getDeck { get { return _deck; } }

        public void ShowDeck()  //Display all the cards in the deck
        {
            foreach (Card d in _deck)
            {
                Console.WriteLine("{0} of {1}", d.CardValue, d.CardSuit);
            }
        }

        public void Shuffle()  //Order the deck randomly
        {
            Random rand = new Random();

            for (int i = 0; i < _deck.Length - 1; i++)
            {
                int j = rand.Next(i, _deck.Length);
                Card temp = _deck[i];
                _deck[i] = _deck[j];
                _deck[j] = temp;
            }
        }

        private Card[] _deck;
        private const int SizeOfDeck = 52;  //Deck will always be 52 cards for this project
    }
}
