using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FigureArea
{
    /// <summary>
    /// Contains properties and methods that describe the triangle.
    /// </summary>
    public class Triangle : IFigureWithArea
    {
        public double Area { get; }

        /// <summary>
        /// Gets a value indicating whether the triangle is right-angled.
        /// </summary>
        private bool IsRightAngled { get; }

        /// <summary>
        /// Gets the first side of the triangle.
        /// </summary>
        public double FirstSide { get; }

        /// <summary>
        /// Gets the second side of the triangle.
        /// </summary>
        public double SecondSide { get; }

        /// <summary>
        /// Gets the third side of the triangle.
        /// </summary>
        public double ThirdSide { get; }


        /// <summary>
        /// Initialize a new instance of the Triangle class with three sides.
        /// </summary>
        /// <param name="firstSide">First side.</param>
        /// <param name="secondSide">Second side.</param>
        /// <param name="thirdSide">Third side.</param>
        /// <exception cref="ArgumentOutOfRangeException">If the side is not a positive number.</exception>
        public Triangle(double firstSide, double secondSide, double thirdSide)
        {
            ThrowIfSidesAreOutOfRange(firstSide, secondSide, thirdSide);
            FirstSide = firstSide;
            SecondSide = secondSide;
            ThirdSide = thirdSide;
            IsRightAngled = CheckIsRightAngled(FirstSide, SecondSide, ThirdSide);
            Area = CalculateAreaWithoutSidesCheck(FirstSide, SecondSide, ThirdSide);
        }

        private static void ThrowIfSidesAreOutOfRange(double firstSide, double secondSide, double thirdSide)
        {
            var argumentOutOfRangeMessage = "Side must be a positive number.";
            if (!double.IsFinite(firstSide) || firstSide <= 0)
                throw new ArgumentOutOfRangeException(nameof(firstSide), firstSide, argumentOutOfRangeMessage);
            if (!double.IsFinite(secondSide) || secondSide <= 0)
                throw new ArgumentOutOfRangeException(nameof(secondSide), secondSide, argumentOutOfRangeMessage);
            if (!double.IsFinite(thirdSide) || thirdSide <= 0)
                throw new ArgumentOutOfRangeException(nameof(thirdSide), thirdSide, argumentOutOfRangeMessage);
        }

        /// <summary>
        /// Checks if a triangle is right-angled.
        /// </summary>
        /// <param name="firstSide">First side.</param>
        /// <param name="secondSide">Second side.</param>
        /// <param name="thirdSide">Third side.</param>
        public static bool CheckIsRightAngled(double firstSide, double secondSide, double thirdSide)
        {
            var hypotenuse = new[] { firstSide, secondSide, thirdSide }.Max();
            var hypotenuseSqr = hypotenuse * hypotenuse;
            return firstSide * firstSide + secondSide * secondSide + thirdSide * thirdSide == hypotenuseSqr + hypotenuseSqr;
        }

        /// <summary>
        /// Calculates the area of a triangle. Doesn't check if side is a positive number.
        /// </summary>
        /// <param name="firstSide">First side.</param>
        /// <param name="secondSide">Second side.</param>
        /// <param name="thirdSide">Third side.</param>
        public static double CalculateAreaWithoutSidesCheck(double firstSide, double secondSide, double thirdSide)
        {
            var semiPerimeter = (firstSide + secondSide + thirdSide) / 2;
            return Math.Sqrt(semiPerimeter * (semiPerimeter - firstSide) * (semiPerimeter - secondSide) * (semiPerimeter - thirdSide));
        }

        // Additional, if the client wants to calculate the area without creating a class.
        /// <summary>
        /// Calculates the area of a triangle.
        /// </summary>
        /// <param name="firstSide">First side.</param>
        /// <param name="secondSide">Second side.</param>
        /// <param name="thirdSide">Third side.</param>
        /// <exception cref="ArgumentOutOfRangeException">If the side is less than or equal to zero.</exception>
        public static double CalculateArea(double firstSide, double secondSide, double thirdSide)
        {
            ThrowIfSidesAreOutOfRange(firstSide, secondSide, thirdSide);
            return CalculateAreaWithoutSidesCheck(firstSide, secondSide, thirdSide);
        }
    }
}
