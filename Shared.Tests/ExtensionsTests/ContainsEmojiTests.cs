using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;

namespace Shared.Tests
{
    public partial class ExtensionsTests
    {
        [TestFixture]
        public class ContainsEmojisTests
        {
            [TestCase("", ExpectedResult = true)]
            public bool ContainsEmoji__True(string s)
            {
                return Extensions.ContainsEmoji(s, TestData.Emojis);
            }

            [TestCase("", ExpectedResult = false)]
            public bool ContainsEmoji__False(string s)
            {
                return Extensions.ContainsEmoji(s, TestData.Emojis);
            }

            [TestCase(null)]
            public void ContainsEmoji__NullReferenceException(string s)
            {
                Assert.Throws<System.NullReferenceException>(() => { Extensions.ContainsEmoji(s, TestData.Emojis); });
            }

            public class TestData
            {
                public static IReadOnlyCollection<Models.Shared.Emoji> Emojis = Shared.Emojis.GetEmjoisAsync().Result;

                public static IEnumerable TestCases
                {
                    get
                    {
                        yield return new TestCaseData("").Returns(new Dictionary<string, ulong>());
                    }
                }
            }
        }
    }
}
