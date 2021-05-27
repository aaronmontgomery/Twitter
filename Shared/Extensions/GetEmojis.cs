using System.Collections.Generic;

namespace Shared
{
    public static partial class Extensions
    {
        public static IReadOnlyDictionary<string, ulong> GetEmojis(this string s, IReadOnlyCollection<Models.Shared.Emoji> emojis)
        {

            char[] chars = s.ToCharArray();

            Dictionary<string, ulong> symbols = new Dictionary<string, ulong>();

            foreach (Models.Shared.Emoji emoji in emojis)
            {
                string[] x = emoji.Unified.Split('-');
                foreach (string a in x)
                {
                    //char z = char.Parse(a);
                    //System.Text.Encoding.Convert(System.Text.Encoding.Unicode, System.Text.Encoding.UTF8, (byte[])byte.Parse(a));

                }
            }


            return symbols;
        }
    }
}
