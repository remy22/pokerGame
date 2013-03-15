using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CardTutorial
{
    class Program
    {
        static void Main(string[] args)
        {
            var cg = new CardGame<PokerCard>();

            // Add a deck
            cg.MasterDeck.AddRange(PokerCard.CreateDeck());

            Console.ReadLine();
            Dump("Master Deck", cg.MasterDeck);
            Console.ReadLine();

            cg.StartHand(3, 0);
            Dump("Shuffled", cg.CurrentDeck.Select((c) => cg.MasterDeck[c.Position]));
            Console.ReadLine();

            cg.DealHand();
            Dump("Remaining Deck", cg.CurrentDeck.Select((c) => cg.MasterDeck[c.Position]));

            for (int i = 0; i < cg.Hands.Count; i++)
                Dump("Hand " + i, cg.Hands[i].Select((c) => cg.MasterDeck[c.Position]));
            Console.ReadLine();

            for (int i = 0; i < cg.Hands.Count; i++)
                cg.DiscardFromHand(i, cg.Hands[i].First());

            Dump("Discard Pile", cg.DiscardPile.Select((c) => cg.MasterDeck[c.Position]));
            Console.ReadLine();

            for (int i = 0; i < cg.Hands.Count; i++)
                Dump("Hand " + i, cg.Hands[i].Select((c) => cg.MasterDeck[c.Position]));
            Console.ReadLine();


        }

        public static void Dump(string info, IEnumerable<PokerCard> cards)
        {
            Console.WriteLine(String.Format("\n**** {0} ****", info));
            Console.WriteLine(string.Join(", ",
                cards.Select((x) => x.ToShortString())));
        }

        public static void Dump<T>(string info, IEnumerable<T> src)
        {
            Console.WriteLine(String.Format("\n**** {0} ****", info));
            Console.WriteLine(string.Join(", ",
                src.Select((x) => x.ToString())));
        }


    }
}
