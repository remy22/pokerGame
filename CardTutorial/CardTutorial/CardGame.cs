using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using CardTutorial.Extensions;

namespace CardTutorial
{
    public class CardGame<T>
    {
        
        public List<CardInstance> CurrentDeck;
        public List<CardInstance> DiscardPile;
        public List<HashSet<CardInstance>> Hands;

        public int DealerPosition { get; private set; }
        public int DeckCount { get; set; }

        public List<T> MasterDeck;

        public CardGame()
        {
            MasterDeck = new List<T>();
            CurrentDeck = new List<CardInstance>();
            Hands = new List<HashSet<CardInstance>>();
            DeckCount = 1;
        }

        public virtual void StartHand(int playercount, int dealerposition)
        {
            // Clear hands, discard pile and setup the deck;
            Hands.Clear();
            for (int i = 0; i < playercount; i++)
                Hands.Add(new HashSet<CardInstance>());

            DiscardPile = new List<CardInstance>();

            CurrentDeck.Clear();
            for (int i = 0; i < DeckCount; i++)
                CurrentDeck.AddRange(MasterDeck.Select((x, j) => new CardInstance(this, j)));

            CurrentDeck = CurrentDeck.Shuffle().ToList();

            DealerPosition = dealerposition;
        }


        public virtual void DealTo(int handID)
        {
            if (CurrentDeck.Count == 0)
                throw new Exception("No Cards to Deal");

            if (handID >= Hands.Count || handID < 0)
                throw new ArgumentException("Invalid Hand", "handID");

            var cardid = CurrentDeck[0];
            Hands[handID].Add(cardid);
            CurrentDeck.RemoveAt(0);
        }

        public virtual void DealHand()
        {
            var cards = CurrentDeck.Take(5 * Hands.Count);
            CurrentDeck.RemoveRange(0, 5 * Hands.Count);

            int currentpos = DealerPosition + 1;

            foreach (var card in cards)
            {
                if (currentpos >= Hands.Count)
                    currentpos = 0;
                Hands[currentpos].Add(card);

                currentpos++;
            }
        }

        public virtual void DiscardFromHand(int handID, CardInstance ci)
        {
            Hands[handID].MoveTo(ci, DiscardPile);
        }

        public virtual void DiscardHand(int handID)
        {
            DiscardPile.AddRange(Hands[handID]);
            Hands[handID].Clear();
        }


    }

}