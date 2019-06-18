using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerHands
{
    public class Deck : Card  //Standard 52 card deck
    {
        public Deck()
        {
            _deckOfCards = new Card[SizeOfDeck];

            int i = 0;
            foreach (Suit s in Enum.GetValues(typeof(Suit)))  //Generate the deck with all suite and value combinations
            {
                foreach (Value v in Enum.GetValues(typeof(Value)))
                {
                    _deckOfCards[i] = new Card { CardSuit = s, CardValue = v };
                    i++;
                }
            }
        }

        public void ShowDeck()  //Display all the cards in the deck
        {
            foreach (Card d in _deckOfCards)
            {
                Console.WriteLine("{0} of {1}", d.CardValue, d.CardSuit);
            }
        }

        public void ShuffleDeck()  //Order the deck randomly
        {
            Random rand = new Random();

            for (int i = 0; i < _deckOfCards.Length - 1; i++)
            {
                int j = rand.Next(i, _deckOfCards.Length);
                Card temp = _deckOfCards[i];
                _deckOfCards[i] = _deckOfCards[j];
                _deckOfCards[j] = temp;
            }
        }

        public Card[] DeckOfCards { get { return _deckOfCards; } }

        private Card[] _deckOfCards;
        private const int SizeOfDeck = 52;  //Deck will always be 52 cards for this project
    }
}
