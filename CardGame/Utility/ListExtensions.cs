using System;
using System.Collections.Generic;

namespace CardGame.Utility
{
    public static class ListExtensions
    {
        /// <summary>
        /// Shuffle list using Fisher yates shuffle algorithm 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="items"></param>
        public static void Shuffle<T>(this IList<T> items)
        {
            Random rnd = new Random();
            var count = items.Count;
            
            while(count > 1)
            {
                count--;
                int randomIndex = rnd.Next(count + 1);
                var temp = items[randomIndex];
                items[randomIndex] = items[count];
                items[count] = temp;
            }
        }
    }
}
