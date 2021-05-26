using NUnit.Framework;

namespace Shared.Tests
{
    [TestFixture]
    public partial class Extensions
    {
        [TestCase()]
        public bool ContainsEmoji__True(string s)
        {
            return Shared.Extensions.ContainsEmoji(s);
        }

        [TestCase("", ExpectedResult = false)]
        public bool ContainsEmoji__False(string s)
        {
            return Shared.Extensions.ContainsEmoji(s);
        }

        [TestCase(null)]
        public void ContainsEmoji__NullReferenceException(string s)
        {
            Assert.Throws<System.NullReferenceException>(() => { Shared.Extensions.ContainsEmoji(s); });
        }
    }
}
