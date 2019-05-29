using System.Collections;
using NUnit.Framework;

namespace Source.Tests
{
    /// <summary>
    /// This test fixture attempts to exercise all the syntactic
    /// variations of Assert without getting into failures, errors
    /// or corner cases. Thus, some of the tests may be duplicated
    /// in other fixtures.
    ///
    /// Each test performs the same operations using the classic
    /// syntax (if available) and the new syntax in both the
    /// helper-based and inherited forms.
    ///
    /// This Fixture will eventually be duplicated in other
    /// supported languages.
    /// </summary>
    [TestFixture]
    public class AssertSyntaxTests
    {
        [Test]
        public void IsNull()
        {
            object nada = null;

            // Classic syntax
            Assert.IsNull(nada);

            // Constraint Syntax
            Assert.That(nada, Is.Null);
        }

        [Test]
        public void IsTrue()
        {
            // Classic syntax
            Assert.IsTrue(2 + 2 == 4);

            // Constraint Syntax
            Assert.That(2 + 2 == 4, Is.True);
            Assert.That(2 + 2 == 4);
        }

        [Test]
        public void IsNaN()
        {
            double d = double.NaN;
            float f = float.NaN;

            // Classic syntax
            Assert.IsNaN(d);
            Assert.IsNaN(f);

            // Constraint Syntax
            Assert.That(d, Is.NaN);
            Assert.That(f, Is.NaN);
        }

        [Test]
        public void EmptyStringTests()
        {
            // Classic syntax
            Assert.IsEmpty("");
            Assert.IsNotEmpty("Hello!");

            // Constraint Syntax
            Assert.That("", Is.Empty);
            Assert.That("Hello!", Is.Not.Empty);
        }

        [Test]
        public void EmptyCollectionTests()
        {
            // Classic syntax
            Assert.IsEmpty(new bool[0]);
            Assert.IsNotEmpty(new int[] { 1, 2, 3 });

            // Constraint Syntax
            Assert.That(new bool[0], Is.Empty);
            Assert.That(new int[] { 1, 2, 3 }, Is.Not.Empty);
        }
      
        [Test]
        public void ExactTypeTests()
        {
            // Classic syntax workarounds
            Assert.AreEqual(typeof(string), "Hello".GetType());
            Assert.AreEqual("System.String", "Hello".GetType().FullName);
            Assert.AreNotEqual(typeof(int), "Hello".GetType());
            Assert.AreNotEqual("System.Int32", "Hello".GetType().FullName);

            // Constraint Syntax
            Assert.That("Hello", Is.TypeOf(typeof(string)));
            Assert.That("Hello", Is.Not.TypeOf(typeof(int)));
        }
    }

}
