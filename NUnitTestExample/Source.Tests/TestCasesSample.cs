using System.Collections.Generic;
using NUnit.Framework;

namespace Source.Tests
{
    [TestFixture]
    public class DivideTest
    {
        [TestCase(12, 3, 4)]
        [TestCase(12, 2, 6)]
        [TestCase(12, 4, 3)]
        public void Test(int n, int d, int q)
        {
            Assert.AreEqual(q, n / d);
        }


        [TestCase(12, 3, ExpectedResult = 4)]
        [TestCase(12, 2, ExpectedResult = 6)]
        [TestCase(12, 4, ExpectedResult = 3)]
        public int Test1(int n, int d)
        {
            return n / d;
        }

        [TestCaseSource(typeof(DataClass), nameof(DataClass.TestCases))]
        public int Test2(int n, int d)
        {
            return n / d;
        }
    }

    public class DataClass
    {
        public static IEnumerable<TestCaseData> TestCases
        {
            get
            {
                yield return new TestCaseData(12, 3).Returns(4);
                yield return new TestCaseData(12, 2).Returns(6);
                yield return new TestCaseData(12, 4).Returns(3);
            }
        }
    }
}