using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerHands
{
    class Program
    {
        static void Main(string[] args)
        {
            Deck myDeck = new Deck();
            Hands playerHands = new Hands();

            playerHands.DealCards("Carl", "Eddie");
            playerHands.ShowHands();
            playerHands.EvaluateWinner();
        }
    }
}
