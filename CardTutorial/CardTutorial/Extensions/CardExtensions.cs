using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CardTutorial.Extensions
{
    public static class CardExtensions
    {
        private static readonly Random rng = new Random();


        public static bool MoveTo<T>(this ICollection<T> self, T item, ICollection<T> destination)
        {
            if (self.Remove(item) == false)
                return false;
            destination.Add(item);
            return true;
        }

        public static IEnumerable<T> Shuffle<T>(this IList<T> self)
        {
            // TODO: we should probably shuffle indexes instead of the items itself incase its expensive

            var ret = self.ToArray();

            lock (rng)
            {
                for (int i = 0; i < ret.Length; i++)
                {
                    int j = rng.Next(ret.Length);
                    T tmp = self[j];
                    ret[j] = ret[i];
                    ret[i] = tmp;
                }
            }

            for (int i = 0; i < ret.Length; i++)
                yield return ret[i];

        }

    }
}
