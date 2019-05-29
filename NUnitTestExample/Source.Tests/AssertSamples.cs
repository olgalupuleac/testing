using System.Collections.Generic;
using NUnit.Framework;

namespace Source.Tests
{
    public class ArrayTest
    {
        [Test]
        public void Test()
        {
            int[] array = { 1, 2, 3 };
            Assert.That(array, Has.Exactly(1).EqualTo(3));
            Assert.That(array, Has.Exactly(2).GreaterThan(1));
            Assert.That(array, Has.Exactly(3).LessThan(100));
        }
    }

    [TestFixture]
    public class DictionaryTest
    {
        private Dictionary<string, int> _dictionary;
        //[OneTimeSetUp] -- executed before all tests
        //[OneTimeTearDown] -- executed after all tests
        [SetUp]
        public void Setup()
        {
            _dictionary = new Dictionary<string, int>();
        }

        [Test, Combinatorial]
        public void Add([Values(1, 2, 3)] int x,
            [Values("A", "B")] string s)
        {
            _dictionary.Add(s, x);
            Assert.Multiple(() =>
            {
                Assert.That(_dictionary, Contains.Value(x));
                Assert.That(_dictionary, Contains.Key(s));
            });
        }
    }
}