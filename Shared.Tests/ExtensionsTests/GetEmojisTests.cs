using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;

namespace Shared.Tests
{
    public partial class ExtensionsTests
    {
        [TestFixture]
        public class GetEmojisTests
        {
            [TestCaseSource(typeof(TestData), nameof(TestData.TestCases))]
            public bool GetEmojis__True(string s)
            {
                return Extensions.ContainsEmoji(s, TestData.Emojis);
            }

            [TestCase("", ExpectedResult = false)]
            public bool ContainsEmoji__False(string s)
            {
                return Extensions.ContainsEmoji(s, TestData.Emojis);
            }

            [TestCase(null)]
            public void GetEmojis__NullReferenceException(string s)
            {
                Assert.Throws<System.NullReferenceException>(() => { Extensions.GetEmojis(s, TestData.Emojis); });
            }

            public class TestData
            {
                public static IReadOnlyCollection<Models.Shared.Emoji> Emojis = Shared.Emojis.GetEmjoisAsync().Result;

                public static IEnumerable TestCases
                {
                    get
                    {
                        yield return new TestCaseData("").Returns(false);
                    }
                }
            }
        }
    }
}
