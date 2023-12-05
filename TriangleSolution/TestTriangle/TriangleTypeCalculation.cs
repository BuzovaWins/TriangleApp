using System.Drawing;
using TriangleMain;

namespace TestTriangle
{
    public class TriangleTypeCalculation
    {

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void TestRightAngledTriangle()
        {
            Assert.That(new Triangle(3, 4, 5).GetTriangleType(), Is.EqualTo(TriangleType.RightAngled));
        }

        [Test]
        public void TestObtuseTriangle()
        {
            Assert.That(new Triangle(3, 4, 5.5).GetTriangleType(), Is.EqualTo(TriangleType.Obtuse));
        }

        [Test]
        public void TestAcuteTriangle()
        {
            Assert.That(new Triangle(3, 4, 4.5).GetTriangleType(), Is.EqualTo(TriangleType.Acute));
        }

        [Test]
        public void TestBigSidedRightAngledTriangle()
        {
            Assert.That(new Triangle(3000000, 4000000, 5000000).GetTriangleType(), Is.EqualTo(TriangleType.RightAngled));
        }

        [Test]
        public void TestObtuseTriangleCloseToRightAngled()
        {
            // the biggest angle is 90.1 degrees
            Assert.That(new Triangle(3, 4, 5.004187).GetTriangleType(), Is.EqualTo(TriangleType.Obtuse));
        }

        [Test]
        public void TestAcuteTriangleCloseToRightAngled()
        {
            // the biggest angle is 88.9 degrees
            Assert.That(new Triangle(3, 4, 4.995809).GetTriangleType(), Is.EqualTo(TriangleType.Acute));
        }
    }
}
