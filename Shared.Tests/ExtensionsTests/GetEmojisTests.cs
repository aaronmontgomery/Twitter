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
            public List<Models.Shared.Emoji> GetEmojis__(string s)
            {
                return Extensions.GetEmojis(s, TestData.Emojis);
            }

            [TestCase(null)]
            public void GetEmojis__ArgumentNullException(string s)
            {
                Assert.Throws<System.ArgumentNullException>(() => { Extensions.GetEmojis(s, TestData.Emojis); });
            }

            public class TestData
            {
                public static List<Models.Shared.Emoji> Emojis = Shared.Emojis.GetEmojiLibraryAsync().Result;

                public static IEnumerable TestCases
                {
                    get
                    {
                        yield return new TestCaseData("").Returns(new List<string>());

                        yield return new TestCaseData("\ud83d\udc94").Returns(new List<string>()
                        {
                            { "\ud83d\udc94" }
                        });

                        yield return new TestCaseData("\ud83d\udc94\ud83d\udc94").Returns(new List<string>()
                        {
                            { "\ud83d\udc94" }
                        });

                        yield return new TestCaseData("\ud83d\udd25\ud83d\ude00").Returns(new List<string>()
                        {
                            { "\ud83d\udd25" },
                            { "\ud83d\ude00" }
                        });

                        yield return new TestCaseData("test \ud83d\ude00 string").Returns(new List<string>()
                        {
                            { "\ud83d\ude00" }
                        });

                        yield return new TestCaseData("test\ud83d\ude00string").Returns(new List<string>()
                        {
                            { "\ud83d\udc94" }
                        });
                    }
                }
            }
        }
    }
}
