using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace Shared
{
    public static partial class Extensions
    {
        public static List<Models.Shared.Emoji> GetEmojis(this string s, List<Models.Shared.Emoji> emojis)
        {
            List<Models.Shared.Emoji> symbols = new List<Models.Shared.Emoji>();

            char[] chars = s.Where(x => x > 127).ToArray();

            try
            {
                if (chars.Length % 2 == 0)
                {
                    for (int i = 0; i < chars.Length; i+=2)
                    {
                        byte[] bytes = Encoding.UTF32.GetBytes(chars);

                        string stringUtf32 = BitConverter.ToString(bytes);

                        StringBuilder stringBuilder = new StringBuilder();
                        string[] stringParts = stringUtf32.Split('-');
                        foreach (string stringPart in stringParts.Reverse())
                        {
                            stringBuilder.Append(stringPart);
                        }

                        string unified = stringBuilder.ToString().TrimStart('0');

                        Models.Shared.Emoji emoji = emojis.SingleOrDefault(x => x.Unified == unified);

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
