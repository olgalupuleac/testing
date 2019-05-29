using NUnit.Framework;

namespace Source.Tests
{
    [TestFixture]
    public class Simple
    {
        [Test]
        public void Test()
        {
            Assert.Pass();
        }

        [Test(ExpectedResult = 4)]
        public int TestExpected()
        {
            return 2 + 2;
        }
    }


    [TestFixture("match")]
    public class Parametrized
    {
        private readonly string _string;

        public Parametrized(string s)
        {
            _string = s;
        }

        [Test]
        public void Test()
        {
            Assert.AreEqual("match", _string);
        }
    }

    [TestFixture("a", 1)]
    [TestFixture("b")]
    public class MultipleConstructors
    {
        private readonly string _s;
        private readonly int _t;
        public MultipleConstructors(string s)
        {
            _s = s;
        }

        public MultipleConstructors(string s, int t)
        {
            _s = s;
            _t = t;
        }

        [Test]
        public void Test()
        {
            Assert.IsTrue(_s == "a" && _t == 1 || _s == "b" && _t == 0);
        }
    }



}