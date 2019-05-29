using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;

namespace Source.Tests
{
    public class SqrtTests
    {
        [DatapointSource]
        public double[] values = new double[] { 0.0, 1.0, -1.0, 42.0 };

        [Theory]
        public void SquareRootDefinition(double num)
        {
            Assume.That(num >= 0.0);

            double sqrt = Math.Sqrt(num);

            Assert.That(sqrt >= 0.0);
            Assert.That(sqrt * sqrt, Is.EqualTo(num).Within(0.000001));
        }
    }

    public class WaringSample
    {
        [Test]
        public void TestIf()
        {
            Warn.If(2 + 2 != 5);
           
        }

        [Test]
        public void TestUnless()
        {
            Warn.Unless(2 + 2 == 5);
        }

        [TearDown]
        public void TearDown()
        {
            Assert.Warn("Warning");
        }
    }


    public class TestContextSample
    {
        [Test]
        public void Write()
        {
            string greeting = "Hello world!";
            TestContext.Out.WriteLine($"Greeting: {greeting}");
            Assert.That(greeting, Is.Not.Null.And.EqualTo("Hello world!"));
        }

        [Test]
        public void Error()
        {
            for (int i = 0; i < 5; i++)
            {
                try
                {
                    Assert.That(5 / i, Is.LessThanOrEqualTo(5));
                }
                catch (System.Exception exception)
                {
                    TestContext.Error.WriteLine($"Error: {exception.ToString()}");
                }
            }
        }
    }


}
