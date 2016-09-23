using System;

namespace LMB.SOLID.LSP.Solution
{
    public class AreaCalculatorService
    {
        public static void CalculatorOperations()
        {
            while (true)
            {
                ShowMenu();

                var option = Console.ReadKey();

                try
                {
                    GeometricForm form;
                    switch (option.KeyChar)
                    {
                        case '0':
                            return;
                        case '1':
                            Console.WriteLine();
                            Console.WriteLine();
                            Console.WriteLine("Calculating the Square Area...");
                            form = new Square(5, 5);
                            Console.WriteLine($"Area = ({form.Height} * {form.Width}) = {form.Area}");
                            break;
                        case '2':
                            Console.WriteLine();
                            Console.WriteLine();
                            Console.WriteLine("Calculating the Rectangle Area...");
                            form = new Rectangle(5, 10);
                            Console.WriteLine($"Area = ({form.Height} * {form.Width}) = {form.Area}");
                            break;
                        case '3':
                            Console.WriteLine();
                            Console.WriteLine();
                            Console.WriteLine("Calculating the Parallelogram Area...");
                            form = new Parallelogram(10, 20);
                            Console.WriteLine($"Area = ({form.Height} * {form.Width}) = {form.Area}");
                            break;
                        default:
                            Console.WriteLine();
                            Console.WriteLine();
                            Console.WriteLine("This option is invalid!");
                            break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

                Console.ReadKey();
            }
        }

        private static void ShowMenu()
        {
            Console.Clear();
            Console.WriteLine("SOLID LSP Geometric Form Area Calculator Sample");
            Console.WriteLine("-----------------------------------------------");
            Console.WriteLine();
            Console.WriteLine("0 - Exit From Area Calculator Service");
            Console.WriteLine("1 - Calculate Square Area");
            Console.WriteLine("2 - Calculate Rectangle Area");
            Console.WriteLine("3 - Calculate Parallelogram Area");
            Console.WriteLine();
            Console.Write("Please, choose one option: ");
        }
    }
}