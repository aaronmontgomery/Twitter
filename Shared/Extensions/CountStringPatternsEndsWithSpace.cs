using System.Collections.Generic;

namespace Shared
{
    public static partial class Extensions
    {
        public static IDictionary<string, ulong> CountStringPatternsEndsWithSpace(this string s, string[] patterns)
        {
            Dictionary<string, ulong> symbols;
            int length;
            string subString;
            
            symbols = new();
            
            foreach (string pattern in patterns)
            {
                for (int i = 0; i < s.Length - pattern.Length; i++)
                {
                    if (s.Substring(i, pattern.Length) == pattern)
                    {
                        length = s.IndexOf(' ', i) > 0 ? s.IndexOf(' ', i) - i : s.Length - i;
                        subString = s.Substring(i, length);
                        if (!s.EndsWith(pattern))
                        {
                            AddOrUpdateUniqueCollection(symbols, subString, 1);
                        }
                    }
                }
            }

            return symbols;
        }
    }
}
