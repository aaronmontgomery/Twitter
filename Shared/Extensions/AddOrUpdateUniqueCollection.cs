﻿using System.Collections.Generic;

namespace Shared
{
    public static partial class Extensions
    {
        public static void AddOrUpdateUniqueCollection(IDictionary<string, ulong> collection, string key, ulong value)
        {
            if (collection.ContainsKey(key))
            {
                collection[key]++;
            }

            else
            {
                collection.Add(key, value);
            }
        }
    }
}
