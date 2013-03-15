using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CardTutorial
{
    public class CardInstance
    {
        public int Position { get; private set; }
        public object Game { get; private set; }


        internal CardInstance(object game, int position)
        {
            Game = game;
            Position = position;
        }
    }
}
