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
            [TestCaseSource(typeof(TestData), nameof(TestData.TestCases))]
            public bool ContainsEmoji__True(string s)
            {
                return Extensions.ContainsEmoji(s, TestData.Emojis);
            }

            [TestCase(null, ExpectedResult = false)]
            public bool ContainsEmoji_NullArgument_False(string s)
            {
                return Extensions.ContainsEmoji(s, TestData.Emojis);
            }

            public class TestData
            {
                public static IReadOnlyCollection<Models.Shared.Emoji> Emojis = Shared.Emojis.GetEmjoisAsync().Result;

                public static IEnumerable TestCases
                {
                    get
                    {
                        yield return new TestCaseData("").Returns(false);

                        yield return new TestCaseData("\ud83d\ude2d").Returns(true);

                        yield return new TestCaseData("\ud83d\ude2d\ud83d\ude00").Returns(true);

                        yield return new TestCaseData("test \ud83d\udc94 string").Returns(true);

                        yield return new TestCaseData("test\ud83d\udc94string").Returns(true);

                        yield return new TestCaseData("test\ud83d\udc94string").Returns(true);

                        yield return new TestCaseData("test string").Returns(false);
                    }
                }
            }
        }
    }
}
