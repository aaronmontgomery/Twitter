using System.Collections.Generic;

namespace Shared
{
    public static partial class Extentions
    {
        public static void AddOrUpdateUniqueCollection(Dictionary<string, ulong> collection, string key, ulong value)
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
