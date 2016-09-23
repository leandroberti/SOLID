using System;

namespace LMB.SOLID.ISP.Solution
{
    public class RegistrationService
    {
        public static void RegistrationOperations()
        {
            while (true)
            {
                ShowMenu();

                var option = Console.ReadKey();

                try
                {
                    switch (option.KeyChar)
                    {
                        case '0':
                            return;
                        case '1':
                            Console.WriteLine();
                            Console.WriteLine();
                            var customer = new CustomerRegistration();
                            Console.WriteLine(customer.ValidateData());
                            Console.WriteLine(customer.SaveData());
                            Console.WriteLine(customer.SendEmail());
                            Console.WriteLine();
                            break;
                        case '2':
                            Console.WriteLine();
                            Console.WriteLine();
                            var product = new ProductRegistration();
                            Console.WriteLine(product.ValidateData());
                            Console.WriteLine(product.SaveData());
                            Console.WriteLine();
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
            Console.WriteLine("SOLID ISP Registration Service Sample");
            Console.WriteLine("-------------------------------------");
            Console.WriteLine();
            Console.WriteLine("0 - Exit From Registration Service");
            Console.WriteLine("1 - Add New Customer");
            Console.WriteLine("2 - Add New Product");
            Console.WriteLine();
            Console.Write("Please, choose one option: ");
        }
    }
}
