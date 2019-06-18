using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PokerHands;

namespace EvaluateHands.Tests
{
    [TestClass]
    public class EvaluateHandsTests
    {
        [TestMethod]
        public void TestFlush()
        {
            Hands testHands = new Hands();

            //Setup a flush hand
            testHands.PlayerOneHand[0].CardValue = Value.Ace;
            testHands.PlayerOneHand[0].CardSuit = Suit.Clubs;
            testHands.PlayerOneHand[1].CardValue = Value.Eight;
            testHands.PlayerOneHand[1].CardSuit = Suit.Clubs;
            testHands.PlayerOneHand[2].CardValue = Value.Five;
            testHands.PlayerOneHand[2].CardSuit = Suit.Clubs;
            testHands.PlayerOneHand[3].CardValue = Value.Four;
            testHands.PlayerOneHand[3].CardSuit = Suit.Clubs;
            testHands.PlayerOneHand[4].CardValue = Value.Jack;
            testHands.PlayerOneHand[4].CardSuit = Suit.Clubs;

            testHands.PlayerTwoHand[0].CardValue = Value.Ace;
            testHands.PlayerTwoHand[0].CardSuit = Suit.Diamonds;
            testHands.PlayerTwoHand[1].CardValue = Value.Eight;
            testHands.PlayerTwoHand[1].CardSuit = Suit.Diamonds;
            testHands.PlayerTwoHand[2].CardValue = Value.Five;
            testHands.PlayerTwoHand[2].CardSuit = Suit.Diamonds;
            testHands.PlayerTwoHand[3].CardValue = Value.Four;
            testHands.PlayerTwoHand[3].CardSuit = Suit.Diamonds;
            testHands.PlayerTwoHand[4].CardValue = Value.Jack;
            testHands.PlayerTwoHand[4].CardSuit = Suit.Diamonds;

            EvaluateHand testEvaluation = new EvaluateHand(testHands.PlayerOneHand);
            testHands.EvaluateWinner();

            //Assert.AreEqual(testHands.PlayerOneValue, HandValue.Flush);
        }
    }
}
