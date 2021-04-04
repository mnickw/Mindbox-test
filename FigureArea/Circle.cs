using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FigureArea
{
    /// <summary>
    /// Contains properties and methods that describe the circle.
    /// </summary>
    public class Circle : IFigureWithArea
    {
        public double Area { get; }

        /// <summary>
        /// Gets the radius of the circle.
        /// </summary>
        public double Radius { get; }

        /// <summary>
        /// Initialize a new instance of the Circle class with the radius of the circle.
        /// </summary>
        /// <param name="radius">The radius of the circle.</param>
        /// <exception cref="ArgumentOutOfRangeException">If the radius is not a positive number.</exception>
        public Circle(double radius)
        {
            ThrowIfRadiusIsWrong(radius);
            Radius = radius;
            Area = CalculateAreaWithoutRadiusCheck(Radius);
        }

        private static void ThrowIfRadiusIsWrong(double radius)
        {
            if (!double.IsFinite(radius) || radius <= 0)
                throw new ArgumentOutOfRangeException(nameof(radius), radius,
                    "The radius must be a positive number.");
        }

        /// <summary>
        /// Calculates the area of a circle. Doesn't check if radius is a positive number.
        /// </summary>
        /// <param name="radius">The radius of the circle.</param>
        public static double CalculateAreaWithoutRadiusCheck(double radius) =>
            Math.PI * radius * radius;

        // Additional, if the client wants to calculate the area without creating a class.
        /// <summary>
        /// Calculates the area of a circle.
        /// </summary>
        /// <param name="radius">The radius of the circle.</param>
        /// <exception cref="ArgumentOutOfRangeException">If the radius is not a positive number.</exception>
        public static double CalculateArea(double radius)
        {
            ThrowIfRadiusIsWrong(radius);
            return CalculateAreaWithoutRadiusCheck(radius);
        }
    }
}
