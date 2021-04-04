using NUnit.Framework;
using System;

namespace FigureArea.Tests
{
    public class CircleTests
    {
        [Test]
        [TestCase(-1)]
        [TestCase(0)]
        [TestCase(double.NaN)]
        [TestCase(double.NegativeInfinity)]
        [TestCase(double.PositiveInfinity)]
        public void Circle_Ctor_WhenWrongRadius_ThrowsArgumentOutOfRangeException(double radius)
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => new Circle(radius));
        }

        [Test]
        [TestCase(10, 314.15926535897931)]
        [TestCase(1, Math.PI)]
        public void Circle_Area_WhenGoodRadius_ReturnsGoodArea(double radius, double expectedArea)
        {
            var circle = new Circle(radius);

            var circleArea = circle.Area;

            Assert.AreEqual(expectedArea, circleArea);
        }
    }
}