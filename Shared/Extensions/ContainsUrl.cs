namespace Shared
{
    public static partial class Extentions
    {
        public static bool ContainsUrl(this string s)
        {
            return s.Contains(@"http://") || s.Contains(@"https://");
        }
    }
}
