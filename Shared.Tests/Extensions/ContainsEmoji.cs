using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;

namespace Shared.Tests
{
    public partial class ExtensionsTests
    {
        [TestFixture]
        public class ContainsEmojiTests
        {
            [TestCase()]
            public bool ContainsEmoji__True(string s)
            {
                return Shared.Extensions.ContainsEmoji(s);
            }

            [TestCase("", ExpectedResult = false)]
            public bool ContainsEmoji__False(string s)
            {
                return Extensions.ContainsEmoji(s);
            }

            [TestCase(null)]
            public void ContainsEmoji__NullReferenceException(string s)
            {
                Assert.Throws<System.NullReferenceException>(() => { Extensions.ContainsEmoji(s); });
            }

            public class TestData
            {
                public static IEnumerable TestCases
                {
                    get
                    {
                        yield return new TestCaseData("", new string[] { "#" }).Returns(new Dictionary<string, ulong>());
                    }
                }
            }
        }
    }
}
