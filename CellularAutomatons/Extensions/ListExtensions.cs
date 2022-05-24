using System;
using System.Collections.Generic;

namespace CellularAutomatons.Extensions
{
    public static class ListExtensions
    {
        private static Random rng = new Random();
        public static void Shuffle<T>(this IList<T> list)
        {
            int n = list.Count;
            while (n > 1)
            {
                n--;
                int k = rng.Next(n + 1);
                (list[k], list[n]) = (list[n], list[k]);
            }
        }

        public static Stack<T> ToStack<T>(this IList<T> list)
        {
            var stack = new Stack<T>();
            foreach (var item in list)
            {
                stack.Push(item);
            }

            return stack;
        }
    }
}
