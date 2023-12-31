﻿using System;

namespace JBQCompleteIt.ViewModel.Extensions
{
    public static class ListExtensions
    {
        public static IList<T> Shuffle<T>(this IList<T> list)
        {
            if (list == null) throw new ArgumentNullException(nameof(list));
            int n = list.Count;
            while (n > 1)
            {
                n--;
                int k = ThreadSafeRandom.Next(n + 1);
                (list[n], list[k]) = (list[k], list[n]);
            }
            return list;
        }
    }

    internal class ThreadSafeRandom
    {
        private static readonly Random _global = new Random();
        private static readonly ThreadLocal<Random> _local = new ThreadLocal<Random>(() =>
        {
            int seed;
            lock (_global)
            {
                seed = _global.Next();
            }
            return new Random(seed);
        });

        public static int Next(int maxValue)
        {
            return _local.Value.Next(maxValue);
        }
    }
}
