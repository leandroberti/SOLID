using System;
using System.Linq;
using LMB.SOLID.DIP.Solution;
using LMB.SOLID.ISP.Solution;
using LMB.SOLID.LSP.Solution;
using LMB.SOLID.OCP.Solution;
using SRPCustomerService = LMB.SOLID.SRP.Solution.CustomerService;
using DIPCustomerService = LMB.SOLID.DIP.Solution.CustomerService;

namespace LMB.SOLID
{
    class Program
    {
        private static readonly char[] ValidOptions = { '0', '1', '2', '3', '4', '5' };

        static void Main(string[] args)
        {
            ShowOperations();
        }

        public static void ShowOperations()
        {
            while (true)
            {
                ShowMenu();
                var option = ReadOption();

                switch (option.KeyChar)
                {
                    case '0':
                        return;
                    case '1':
                        SRPCustomerService.CustomerOperations();
                        break;
                    case '2':
                        AtmMachineService.AtmOperations();
                        break;
                    case '3':
                        AreaCalculatorService.CalculatorOperations();
                        break;
                    case '4':
                        RegistrationService.RegistrationOperations();
                        break;
                    case '5':
                        var customerRepo = new CustomerRepository();
                        var emailService = new EmailServices();
                        var ssnService = new SsnServices();
                        var customerService = new DIPCustomerService(customerRepo, emailService, ssnService);
                        customerService.CustomerOperations();
                        break;
                }
            }
        }

        private static ConsoleKeyInfo ReadOption()
        {
            var option = Console.ReadKey();

            while (!ValidOptions.Contains(option.KeyChar))
            {
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine("This option is invalid!");
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();

                ShowMenu();
                option = ReadOption();
            }

            return option;
        }

        private static void ShowMenu()
        {
            Console.Clear();
            Console.WriteLine("SOLID C# Console Application Sample");
            Console.WriteLine("-----------------------------------");
            Console.WriteLine();
            Console.WriteLine("0 - Exit");
            Console.WriteLine("1 - SRP Customer Sample");
            Console.WriteLine("2 - OCP ATM Sample");
            Console.WriteLine("3 - LSP Area Calculator Sample");
            Console.WriteLine("4 - ISP Sample");
            Console.WriteLine("5 - DIP Sample");
            Console.WriteLine();
            Console.Write("Please, choose one option: ");
        }
    }
}
