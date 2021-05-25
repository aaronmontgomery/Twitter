using NUnit.Framework;

namespace Shared.Tests
{
    [TestFixture]
    public partial class Extensions
    {
        [TestCase("", ExpectedResult = false)]
        [TestCase("http:/", ExpectedResult = false)]
        [TestCase("http://", ExpectedResult = true)]
        [TestCase("http://test.com", ExpectedResult = true)]
        [TestCase("https:/", ExpectedResult = false)]
        [TestCase("https://", ExpectedResult = true)]
        [TestCase("https://test.com", ExpectedResult = true)]
        [TestCase("test string", ExpectedResult = false)]
        public bool ContainsUrl__Test(string s)
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
