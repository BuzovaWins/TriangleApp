using System.Drawing;
using TriangleMain;

namespace TestTriangle
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void TestZeroValuedSide()
        {
            
            var ex = Assert.Throws<ArgumentException>(
            () => new Triangle(0, 1, 2));

            Assert.That(ex.Message, Is.EqualTo($"Value of a side is not correct: side = [0]"));
        }

        [Test]
        public void TestNegativeValuedSide()
        {

            var ex = Assert.Throws<ArgumentException>(
            () => new Triangle(3, 1, -5));

            Assert.That(ex.Message, Is.EqualTo($"Value of a side is not correct: side = [-5]"));
        }

        [Test]
        public void TestNanValuedSide()
        {

            var ex = Assert.Throws<ArgumentException>(
            () => new Triangle(3, double.NaN, 5));

            Assert.That(ex.Message, Does.StartWith("Value of a side is not correct:"));
        }

        [Test]
        public void TestNegativeInfinityValuedSide()
        {

            var ex = Assert.Throws<ArgumentException>(
            () => new Triangle(3, 1, double.NegativeInfinity));

            Assert.That(ex.Message, Does.StartWith("Value of a side is not correct:"));
        }

        [Test]
        public void TestPositiveInfinityValuedSide()
        {

            var ex = Assert.Throws<ArgumentException>(
            () => new Triangle(3, 1, double.PositiveInfinity));

            Assert.That(ex.Message, Does.StartWith("Value of a side is not correct:"));
        }
    }
}