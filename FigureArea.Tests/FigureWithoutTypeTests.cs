using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FigureArea.Tests
{
    public class Rectangle : FigureWithoutType<(double FirstSide, double SecondSide)>
    {
        public Rectangle(double firstSide, double secondSide)
            : base(t => { if (t.FirstSide <= 0 || t.SecondSide <= 0) throw new ArgumentOutOfRangeException(); },
            t => t.FirstSide * t.SecondSide, (firstSide, secondSide))
        { }
    }
    public class FigureWithoutTypeTests
    {
        [Test]
        public void FigureWithoutType_CustomRectangle_Ctor_WhenWrongSides_ThrowsArgumentOutOfRangeException()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => new Rectangle(-1, -1));
        }
        [Test]
        public void FigureWithoutType_CustomRectangle_Area_WhenGoodSides_ReturnsGoodArea()
        {
            var rect = new Rectangle(2, 5);

            var rectArea = rect.Area;

            Assert.AreEqual(10, rectArea);
        }
    }
}
