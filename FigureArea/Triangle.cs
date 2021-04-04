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
        public bool IsRightAngled { get; }

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
        /// <exception cref="ArgumentException">If a triangle with such sides cannot exist.</exception>
        public Triangle(double firstSide, double secondSide, double thirdSide)
        {
            ThrowIfSidesAreWrong(firstSide, secondSide, thirdSide);
            FirstSide = firstSide;
            SecondSide = secondSide;
            ThirdSide = thirdSide;
            IsRightAngled = CheckIsRightAngled(FirstSide, SecondSide, ThirdSide);
            Area = CalculateAreaWithoutSidesCheck(FirstSide, SecondSide, ThirdSide);
        }

        private static void ThrowIfSidesAreWrong(double firstSide, double secondSide, double thirdSide)
        {
            var argumentOutOfRangeMessage = "The side must be a finite positive number.";
            if (!double.IsFinite(firstSide) || firstSide <= 0)
                throw new ArgumentOutOfRangeException(nameof(firstSide), firstSide, argumentOutOfRangeMessage);
            if (!double.IsFinite(secondSide) || secondSide <= 0)
                throw new ArgumentOutOfRangeException(nameof(secondSide), secondSide, argumentOutOfRangeMessage);
            if (!double.IsFinite(thirdSide) || thirdSide <= 0)
                throw new ArgumentOutOfRangeException(nameof(thirdSide), thirdSide, argumentOutOfRangeMessage);

            if (firstSide + secondSide <= thirdSide ||
                firstSide + thirdSide <= secondSide ||
                secondSide + thirdSide <= firstSide)
                throw new ArgumentException("A triangle cannot exist with such sides.");
        }

        /// <summary>
        /// Checks if a triangle is right-angled. Doesn't check if the sides are wrong.
        /// </summary>
        /// <param name="firstSide">First side.</param>
        /// <param name="secondSide">Second side.</param>
        /// <param name="thirdSide">Third side.</param>
        public static bool CheckIsRightAngledWithoutSidesCheck(double firstSide, double secondSide, double thirdSide)
        {
            var hypotenuse = new[] { firstSide, secondSide, thirdSide }.Max();
            var hypotenuseSqr = hypotenuse * hypotenuse;
            return firstSide * firstSide + secondSide * secondSide + thirdSide * thirdSide == hypotenuseSqr + hypotenuseSqr;
        }

        // Additional, if the client wants to check if a triangle is right-angled without creating an instance.
        /// <summary>
        /// Checks if a triangle is right-angled.
        /// </summary>
        /// <param name="firstSide">First side.</param>
        /// <param name="secondSide">Second side.</param>
        /// <param name="thirdSide">Third side.</param>
        /// <exception cref="ArgumentOutOfRangeException">If the side is not a positive number.</exception>
        /// <exception cref="ArgumentException">If a triangle with such sides cannot exist.</exception>
        public static bool CheckIsRightAngled(double firstSide, double secondSide, double thirdSide)
        {
            ThrowIfSidesAreWrong(firstSide, secondSide, thirdSide);
            return CheckIsRightAngledWithoutSidesCheck(firstSide, secondSide, thirdSide);
        }

        /// <summary>
        /// Calculates the area of a triangle. Doesn't check if the sides are wrong.
        /// </summary>
        /// <param name="firstSide">First side.</param>
        /// <param name="secondSide">Second side.</param>
        /// <param name="thirdSide">Third side.</param>
        public static double CalculateAreaWithoutSidesCheck(double firstSide, double secondSide, double thirdSide)
        {
            var semiPerimeter = (firstSide + secondSide + thirdSide) / 2;
            return Math.Sqrt(semiPerimeter * (semiPerimeter - firstSide) * (semiPerimeter - secondSide) * (semiPerimeter - thirdSide));
        }

        // Additional, if the client wants to calculate the area without creating an instance.
        /// <summary>
        /// Calculates the area of a triangle.
        /// </summary>
        /// <param name="firstSide">First side.</param>
        /// <param name="secondSide">Second side.</param>
        /// <param name="thirdSide">Third side.</param>
        /// <exception cref="ArgumentOutOfRangeException">If the side is not a positive number.</exception>
        /// <exception cref="ArgumentException">If a triangle with such sides cannot exist.</exception>
        public static double CalculateArea(double firstSide, double secondSide, double thirdSide)
        {
            ThrowIfSidesAreWrong(firstSide, secondSide, thirdSide);
            return CalculateAreaWithoutSidesCheck(firstSide, secondSide, thirdSide);
        }
    }
}
