using System.Collections.Generic;

namespace Shared
{
    public static partial class Extentions
    {
        public static IReadOnlyDictionary<string, ulong> CountStringPatternsEndsWithSpace(this string s, string[] patterns)
        {
            Dictionary<string, ulong> symbols = new Dictionary<string, ulong>();

            foreach (string p in patterns)
            {
                for (int i = 0; i < s.Length - p.Length;)
                {
                    if (s.Substring(i, p.Length) == p)
                    {
                        int length = s.IndexOf(' ', i) > 0 ? s.IndexOf(' ', i) - i : s.Length - i;
                        string subString = s.Substring(i, length);

                        if (!s.EndsWith(p))
                        {
                            AddOrUpdateUniqueCollection(symbols, subString, 1);
                        }
                    }

                    i++;
                }
            }

            return symbols;
        }
    }
}
