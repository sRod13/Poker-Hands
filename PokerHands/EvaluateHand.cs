using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerHands
{
    public enum HandValue  // Poker hands in order of lowest rank to highest
    {
        HighCard,
        OnePair,
        TwoPairs,
        ThreeOfAKind,
        Straight,
        Flush,
        FullHouse,
        FourOfAKind,
        StraightFlush
    }

    public class EvaluateHand : Hands
    {
        public EvaluateHand(Card[] singleHand)
        {
            _cards = new Card[SizeOfHand];
            _cards = singleHand;
        }

        public HandValue GetHandValue()  // Check to see which poker hands the player has and return the value
        {
            if (StraightFlush())
            {
                return HandValue.StraightFlush;
            }
            else if (FourOfAKind())
            {
                return HandValue.FourOfAKind;
            }
            else if (FullHouse())
            {
                return HandValue.FullHouse;
            }
            else if (Flush())
            {
                return HandValue.Flush;
            }
            else if (Straight())
            {
                return HandValue.Straight;
            }
            else if (ThreeOfAKind())
            {
                return HandValue.ThreeOfAKind;
            }
            else if (TwoPairs())
            {
                return HandValue.TwoPairs;
            }
            else if (OnePair())
            {
                return HandValue.OnePair;
            }
            else
            {
                return HandValue.HighCard;
            }
        }

        public bool StraightFlush()
        {
            if(Flush() && Straight())
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool FourOfAKind()
        {
            if(_cards[0].CardValue == _cards[3].CardValue)
            {
                _highCard = _cards[0].CardValue;
                return true;
            }
            else if (_cards[1].CardValue == _cards[4].CardValue)
            {
                _highCard = _cards[1].CardValue;
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool FullHouse()
        {
            if (OnePair() && ThreeOfAKind())
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool Flush()
        {
            if(_cards[0].CardSuit == _cards[1].CardSuit && _cards[1].CardSuit == _cards[2].CardSuit && _cards[2].CardSuit == _cards[3].CardSuit && _cards[3].CardSuit == _cards[4].CardSuit)
            {
                _highCard = _cards[0].CardValue;
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool Straight()
        {
            if(_cards[0].CardValue == _cards[1].CardValue - 1 && _cards[1].CardValue == _cards[2].CardValue - 1 && _cards[2].CardValue == _cards[3].CardValue - 1 && _cards[3].CardValue == _cards[4].CardValue - 1)
            {
                _highCard = _cards[0].CardValue;
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool ThreeOfAKind()
        {
            if (_cards[0].CardValue == _cards[2].CardValue)
            {
                _highCard = _cards[0].CardValue;
                return true;
            }
            else if (_cards[1].CardValue == _cards[3].CardValue)
            {
                _highCard = _cards[1].CardValue;
                return true;
            }
            else if (_cards[2].CardValue == _cards[4].CardValue)
            {
                _highCard = _cards[2].CardValue;
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool TwoPairs()
        {
            if ((_cards[0].CardValue == _cards[1].CardValue && _cards[2].CardValue == _cards[3].CardValue) || (_cards[0].CardValue == _cards[1].CardValue && _cards[3].CardValue == _cards[4].CardValue))
            {
                _highCard = _cards[0].CardValue;
                return true;
            }
            else if (_cards[1].CardValue == _cards[2].CardValue && _cards[3].CardValue == _cards[4].CardValue)
            {
                _highCard = _cards[1].CardValue;
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool OnePair()
        {
            if(_cards[0].CardValue == _cards[1].CardValue)
            {
                _highCard = _cards[0].CardValue;
                return true;
            }
            else if(_cards[1].CardValue == _cards[2].CardValue)
            {
                _highCard = _cards[1].CardValue;
                return true;
            }
            else if (_cards[2].CardValue == _cards[3].CardValue)
            {
                _highCard = _cards[2].CardValue;
                return true;
            }
            else if (_cards[3].CardValue == _cards[4].CardValue)
            {
                _highCard = _cards[3].CardValue;
                return true;
            }
            else
            {
                return false;
            }
        }

        public Value HighCard
        {
            get { return _highCard; }
        }

        private Card[] _cards;
        private Value _highCard;
        const int SizeOfHand = 5;
    }
}
