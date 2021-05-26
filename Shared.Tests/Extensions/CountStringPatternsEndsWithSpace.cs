using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;

namespace Shared.Tests
{
    [TestFixture]
    public partial class Extensions
    {
        [TestCaseSource(typeof(TestData), nameof(TestData.TestCases))]
        public IReadOnlyDictionary<string, ulong> CountStringPatternsEndsWithSpace__CountsPatternsInStringsPassed(string s, string[] patterns)
        {
            return Extentions.CountStringPatternsEndsWithSpace(s, patterns);
        }

        [TestCase("", null)]
        [TestCase(null, new string[] { "" })]
        public void CountStringPatternsEndsWithSpace__NullReferenceException(string s, string[] patterns)
        {
            Assert.Throws<System.NullReferenceException>(() => { Extentions.CountStringPatternsEndsWithSpace(s, patterns); });
        }

        public class TestData
        {
            public static IEnumerable TestCases
            {
                get
                {
                    yield return new TestCaseData("", new string[] { "#" }).Returns(new Dictionary<string, ulong>());

                    yield return new TestCaseData("#hashtag0", new string[] { "#" }).Returns(new Dictionary<string, ulong>()
                    {
                        { "#hashtag0", 1 }
                    });

                    yield return new TestCaseData("#hashTag0#", new string[] { "#" }).Returns(new Dictionary<string, ulong>());

                    yield return new TestCaseData("#Test addition text", new string[] { "#" }).Returns(new Dictionary<string, ulong>()
                    {
                        { "#Test", 1 }
                    });

                    yield return new TestCaseData("#Test #test", new string[] { "#" }).Returns(new Dictionary<string, ulong>()
                    {
                        { "#Test", 1 },
                        { "#test", 1 }
                    });

                    yield return new TestCaseData("test string http:", new string[] { @"http://", @"https://" }).Returns(new Dictionary<string, ulong>());

                    yield return new TestCaseData("test string http://.com", new string[] { @"http://", @"https://" }).Returns(new Dictionary<string, ulong>()
                    {
                        { "http://.com", 1 }
                    });

                    yield return new TestCaseData("test string http://.com ", new string[] { @"http://", @"https://" }).Returns(new Dictionary<string, ulong>()
                    {
                        { "http://.com", 1 }
                    });

                    yield return new TestCaseData("test string http://.com additional text", new string[] { @"http://", @"https://" }).Returns(new Dictionary<string, ulong>()
                    {
                        { "http://.com", 1 }
                    });

                    yield return new TestCaseData("test string http://.com additional text http://.com", new string[] { @"http://", @"https://" }).Returns(new Dictionary<string, ulong>()
                    {
                        { "http://.com", 2 }
                    });

                    yield return new TestCaseData("test string http://.com additional text http://.com ", new string[] { @"http://", @"https://" }).Returns(new Dictionary<string, ulong>()
                    {
                        { "http://.com" , 2 }
                    });

                    yield return new TestCaseData("test string http://.com additional text https://.com", new string[] { @"http://", @"https://" }).Returns(new Dictionary<string, ulong>()
                    {
                        { "http://.com" , 1 },
                        { "https://.com", 1 }
                    });

                    yield return new TestCaseData("test string https:", new string[] { @"http://", @"https://" }).Returns(new Dictionary<string, ulong>());

                    yield return new TestCaseData("test string https://.com", new string[] { @"http://", @"https://" }).Returns(new Dictionary<string, ulong>()
                    {
                        { "https://.com", 1 }
                    });

                    yield return new TestCaseData("test string https://.com ", new string[] { @"http://", @"https://" }).Returns(new Dictionary<string, ulong>()
                    {
                        { "https://.com" , 1 }
                    });

                    yield return new TestCaseData("test string https://.com additional text", new string[] { @"http://", @"https://" }).Returns(new Dictionary<string, ulong>()
                    {
                        { "https://.com", 1 }
                    });

                    yield return new TestCaseData("test string https://.com additional text https://.com", new string[] { @"http://", @"https://" }).Returns(new Dictionary<string, ulong>()
                    {
                        { "https://.com", 2 }
                    });

                    yield return new TestCaseData("test string http://.com additional text https://.com", new string[] { @"http://", @"https://" }).Returns(new Dictionary<string, ulong>()
                    {
                        { "http://.com" , 1 },
                        { "https://.com", 1 }
                    });

                    yield return new TestCaseData("https://https://", new string[] { @"http://", @"https://" }).Returns(new Dictionary<string, ulong>());
                }
            }
        }
    }
}
