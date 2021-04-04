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
        public void Triangle_Ctor_WhenWrongSides_ThrowsArgumentOutOfRangeException(double firstSide, double secondSide, double thirdSide)
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

        //Проверить, что треугольник существует
    }
}
