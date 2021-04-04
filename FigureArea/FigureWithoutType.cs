using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FigureArea
{
    /// <summary>
    /// Represents figure without type that can be created "on the fly".
    /// </summary>
    /// <typeparam name="TFigureProperties">The type of figure properties for calculating the area.</typeparam>
    public class FigureWithoutType<TFigureProperties> : IFigureWithArea
    {
        public double Area { get; }

        /// <summary>
        /// Gets the properties of the figure.
        /// </summary>
        public TFigureProperties FigureProperties { get; }

        /// <summary>
        /// Gets an encapsulated method that validates the figure's properties and throws an exception if validation fails.
        /// </summary>
        public Action<TFigureProperties> ThrowIfArgsAreWrongAction { get; }

        /// <summary>
        /// Gets an encapsulated method that calculates the area of the figure with figure properties.
        /// </summary>
        public Func<TFigureProperties, double> CalculateAreaFunc { get; }

        /// <summary>
        /// Initialize a new instance of the FigureWithoutType class with an encapsulated method that calculates the area and properties of the figure.
        /// </summary>
        /// <param name="calculateAreaFunc">An encapsulated method that calculates the area of the figure with figure properties.</param>
        /// <param name="args">The properties of the figure.</param>
        public FigureWithoutType(Func<TFigureProperties, double> calculateAreaFunc, TFigureProperties args)
            : this(null, calculateAreaFunc, args) { }

        /// <summary>
        /// Initialize a new instance of the FigureWithoutType class with an encapsulated method that calculates the area, properties of the figure and with an encapsulated method for properties validation.
        /// </summary>
        /// <param name="throwIfArgsAreWrongAction">An encapsulated method that validates the figure's properties and throws an exception if validation fails.</param>
        /// <param name="calculateAreaFunc">An encapsulated method that calculates the area of the figure with figure properties.</param>
        /// <param name="args">The properties of the figure.</param>
        public FigureWithoutType(Action<TFigureProperties> throwIfArgsAreWrongAction, Func<TFigureProperties, double> calculateAreaFunc, TFigureProperties args)
        {
            ThrowIfArgsAreWrongAction = throwIfArgsAreWrongAction;
            CalculateAreaFunc = calculateAreaFunc;
            ThrowIfArgsAreWrongAction?.Invoke(args);
            Area = calculateAreaFunc(args);
        }
    }
}
