using NUnit.Framework;

namespace Shared.Tests
{
    [TestFixture]
    public partial class ExtensionsTests
    {
        public class ContainsUrlTests
        {
            [TestCase("http://", ExpectedResult = true)]
            [TestCase("http://test.com", ExpectedResult = true)]
            [TestCase("https://", ExpectedResult = true)]
            [TestCase("https://test.com", ExpectedResult = true)]
            [TestCase("https://test.com ", ExpectedResult = true)]
            public bool ContainsUrl__True(string s)
            {
                return Extensions.ContainsUrl(s);
            }

            [TestCase("", ExpectedResult = false)]
            [TestCase("http:/", ExpectedResult = false)]
            [TestCase("https:/", ExpectedResult = false)]
            [TestCase("test string", ExpectedResult = false)]
            public bool ContainsUrl__False(string s)
            {
                return Extensions.ContainsUrl(s);
            }

            [TestCase(null)]
            public void ContainsUrl__NullReferenceException(string s)
            {
                Assert.Throws<System.NullReferenceException>(() => { Extensions.ContainsUrl(s); });
            }
        }
    }
}
