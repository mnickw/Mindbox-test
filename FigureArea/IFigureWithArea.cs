using System;

namespace FigureArea
{
    /// <summary>
    /// IFigureWithArea is an interface for calculating area.
    /// </summary>
    public interface IFigureWithArea
    {
        /// <summary>
        /// Gets the area of the figure.
        /// </summary>
        public double Area { get; }
    }
}
