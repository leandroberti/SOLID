using System;

namespace LMB.SOLID.LSP.Violation
{
    /// <summary>
    /// Sample AreaCalculator class showing the LSP violation.
    /// The LSP (Liskov substitution principle) says:
    ///     "Derived classes must be replaced by their base classes."
    /// </summary>
    /// <remarks>
    ///     In this sample class the Calculate method is instantiating a new Square class.
    ///     This Square class looks like a Rectangle class, has the same Width and Height properties,
    ///     but it is not a Rectangle class, because the Width and the Height are been set to the same.
    /// </remarks>
    public class AreaCalculator
    {
        private static void CalculateRectangleArea(Rectangle rec)
        {
            Console.Clear();
            Console.WriteLine("Calculo da área do Retangulo");
            Console.WriteLine();
            Console.WriteLine($"{rec.Height} * {rec.Width}");
            Console.WriteLine();
            Console.WriteLine(rec.Area);
            Console.ReadKey();
        }

        public static void Calculate()
        {
            var square = new Square
            {
                Height = 10,
                Width = 5
            };

            CalculateRectangleArea(square);
        }
    }
}
