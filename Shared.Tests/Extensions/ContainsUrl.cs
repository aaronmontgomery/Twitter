using NUnit.Framework;

namespace Shared.Tests
{
    [TestFixture]
    public partial class Extensions
    {
        [TestCase("http://", ExpectedResult = true)]
        [TestCase("http://test.com", ExpectedResult = true)]
        [TestCase("https://", ExpectedResult = true)]
        [TestCase("https://test.com", ExpectedResult = true)]
        [TestCase("https://test.com ", ExpectedResult = true)]
        public bool ContainsUrl__True(string s)
        {
            return Extentions.ContainsUrl(s);
        }

        [TestCase("", ExpectedResult = false)]
        [TestCase("http:/", ExpectedResult = false)]
        [TestCase("https:/", ExpectedResult = false)]
        [TestCase("test string", ExpectedResult = false)]
        public bool ContainsUrl__False(string s)
        {
            return Extentions.ContainsUrl(s);
        }

        [TestCase(null)]
        public void ContainsUrl__NullReferenceException(string s)
        {
            Assert.Throws<System.NullReferenceException>(() => { Extentions.ContainsUrl(s); });
        }
    }
}
