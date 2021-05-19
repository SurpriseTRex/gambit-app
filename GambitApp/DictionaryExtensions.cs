using System.Collections.Generic;

namespace GambitApp
{
    public static class DictionaryExtensions
    {
        public static int Increment<T>(this Dictionary<T, int> dictionary, T key, int amount = 1)
        {
            dictionary.TryGetValue(key, out var count);
            var newCount = count + amount;
            dictionary[key] = newCount;
            
            return newCount;
        }

        public static int Decrement<T>(this Dictionary<T, int> dictionary, T key, int amount = 1)
        {
            var newCount = Increment(dictionary, key, amount * -1);
            if (newCount < 0) newCount = 0;

            return newCount;
        }
    }
}