﻿using System;
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

            myDeck.Shuffle();
            myDeck.ShowDeck();
        }
    }
}
