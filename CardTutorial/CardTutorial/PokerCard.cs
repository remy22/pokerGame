using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CardTutorial
{

    public enum CardSuit
    {
        Heart,
        Diamond,
        Club,
        Spade
    }

    public class PokerCard
    {
        public CardSuit Suit { get; set; }

        private int _value;
        public int Value 
        { 
            get { return _value; }

            set
            {
                if (value >= PokerCard.ValueName.Length || value < 0)
                    throw new ArgumentOutOfRangeException("Invalid Value");
                _value = value;
            }
        }

        public static readonly string[] ValueName =
            new string[] 
            {
                "Ace",
                "2", "3", "4", "5", "6", "7", "8", "9", "10",
                "Jack",
                "Queen",
                "King",                
            };


        public override string ToString()
        {
            return string.Format("{0} of {1}s", PokerCard.ValueName[Value], Suit);
        }

        public virtual string ToShortString()
        {
            return string.Format("{0}{1}",
                PokerCard.ValueName[Value].Length < 3 ? PokerCard.ValueName[Value] : PokerCard.ValueName[Value].Substring(0,1),
                (char)(Suit+3));
        }


        public static PokerCard[] CreateDeck()
        {
            var d = new PokerCard[52];
            for (int i = 0; i < 52; i++)
                d[i] = new PokerCard() { Value = i / 4, Suit = (CardSuit)(i % 4) };
            return d;
        }


    }
}
