using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FigureArea.Tests
{
    public class TriangleTests
    {
        [Test]
        [TestCase(-1, 1, 1)]
        [TestCase(0, 1, 1)]
        [TestCase(double.NaN, 1, 1)]
        [TestCase(double.NegativeInfinity, 1, 1)]
        [TestCase(double.PositiveInfinity, 1, 1)]
        [TestCase(1, -1, 1)]
        [TestCase(1, 0, 1)]
        [TestCase(1, double.NaN, 1)]
        [TestCase(1, double.NegativeInfinity, 1)]
        [TestCase(1, double.PositiveInfinity, 1)]
        [TestCase(1, 1, -1)]
        [TestCase(1, 1, 0)]
        [TestCase(1, 1, double.NaN)]
        [TestCase(1, 1, double.NegativeInfinity)]
        [TestCase(1, 1, double.PositiveInfinity)]
        public void Triangle_Ctor_WhenSidesOutOfRangeOrNan_ThrowsArgumentOutOfRangeException(double firstSide, double secondSide, double thirdSide)
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => new Triangle(firstSide, secondSide, thirdSide));
        }

        [Test]
        [TestCase(1, 1, 1, 0.4330127018922193)]
        public void Triangle_Area_WhenGoodSides_ReturnsGoodArea(double firstSide, double secondSide, double thirdSide, double expectedArea)
        {
            var triangle = new Triangle(firstSide, secondSide, thirdSide);

            var triangleArea = triangle.Area;

            Assert.AreEqual(expectedArea, triangleArea);
        }

        [Test]
        [TestCase(1, 2, 3.5)]
        [TestCase(1, 1, 2)]
        public void Triangle_Ctor_WhenTriangleCannotExist_ThrowsArgumentException(double firstSide, double secondSide, double thirdSide)
        {
            Assert.Throws<ArgumentException>(() => new Triangle(firstSide, secondSide, thirdSide));
        }

        [Test]
        public void Triangle_IsRightAngled_WhenItIsRightAngled_ReturnsTrue()
        {
            var triangle = new Triangle(3, 4, 5);

            var isRightAngled = triangle.IsRightAngled;

            Assert.AreEqual(true, isRightAngled);
        }

        [Test]
        public void Triangle_IsRightAngled_WhenItIsNotRightAngled_ReturnsFalse()
        {
            var triangle = new Triangle(3, 4, 6);

            var isRightAngled = triangle.IsRightAngled;

            Assert.AreEqual(false, isRightAngled);
        }
    }
}
