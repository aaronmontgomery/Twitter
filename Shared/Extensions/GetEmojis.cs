using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;

namespace Shared
{
    public static partial class Extensions
    {
        public static IList<Models.Shared.Emoji> GetEmojis(this string s, IEnumerable<Models.Shared.Emoji> emojis)
        {
            List<Models.Shared.Emoji> symbols;
            char[] chars;
            byte[] bytes;
            string stringUtf32;
            StringBuilder stringBuilder;
            string[] stringParts;
            string unified;
            Models.Shared.Emoji emoji;
            
            symbols = new();
            chars = s.Where(x => x > 127).ToArray();

            try
            {
                if (chars.Length % 2 == 0)
                {
                    for (int i = 0; i < chars.Length; i += 1)
                    {
                        bytes = Encoding.UTF32.GetBytes(new char[] { chars[i], chars[i + 1] }.ToArray());
                        stringUtf32 = BitConverter.ToString(bytes);
                        stringBuilder = new();
                        stringParts = stringUtf32.Split('-');
                        foreach (string stringPart in stringParts.Reverse())
                        {
                            stringBuilder.Append(stringPart);
                        }
                        
                        unified = stringBuilder.ToString().TrimStart('0');
                        emoji = emojis.SingleOrDefault(x => x.Unified == unified);
                        if (emoji != null)
                        {
                            emoji.Unicode = new char[] { chars[i], chars[++i] };
                            symbols.Add(emoji);
                        }
                    }
                }

                else
                {

                }
            }

            catch
            {

            }

            return symbols;
        }
    }
}
