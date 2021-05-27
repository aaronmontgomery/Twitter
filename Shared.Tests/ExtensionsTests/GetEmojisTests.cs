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
            public IReadOnlyDictionary<string, ulong> GetEmojis__(string s)
            {
                return Extensions.GetEmojis(s, TestData.Emojis);
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
                        yield return new TestCaseData("").Returns(new Dictionary<string, ulong>());

                        yield return new TestCaseData("\ud83d\udc94").Returns(new Dictionary<string, ulong>()
                        {
                            { "\ud83d\udc94", 1 }
                        });

                        yield return new TestCaseData("\ud83d\udc94\ud83d\udc94").Returns(new Dictionary<string, ulong>()
                        {
                            { "\ud83d\udc94", 2 }
                        });

                        yield return new TestCaseData("\ud83d\udd25\ud83d\ude00").Returns(new Dictionary<string, ulong>()
                        {
                            { "\ud83d\udd25", 1 },
                            { "\ud83d\ude00", 1 }
                        });

                        yield return new TestCaseData("test \ud83d\ude00 string").Returns(new Dictionary<string, ulong>()
                        {
                            { "\ud83d\ude00", 1 }
                        });

                        yield return new TestCaseData("test\ud83d\ude00string").Returns(new Dictionary<string, ulong>()
                        {
                            { "\ud83d\udc94", 1 }
                        });
                    }
                }
            }
        }
    }
}
