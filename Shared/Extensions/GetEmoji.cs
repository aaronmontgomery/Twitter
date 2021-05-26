using System.Collections.Generic;

namespace Shared
{
    public static partial class Extensions
    {
        public static IReadOnlyDictionary<string, ulong> GetEmoji(this string s, IReadOnlyCollection<Models.Shared.Emoji> emojis)
        {
            Dictionary<string, ulong> symbols = new Dictionary<string, ulong>();

            foreach (Models.Shared.Emoji emoji in emojis)
            {

            }


            return symbols;
        }
    }
}
