using System;
using System.Configuration;

namespace LMB.SOLID.SRP.Solution
{
    public class CustomerService
    {
        private static readonly CustomerRepository Repository = new CustomerRepository();

        public static void CustomerOperations()
        {
            while (true)
            {
                ShowMenu();
                var option = Console.ReadKey();

                switch (option.KeyChar)
                {
                    case '0':
                        return;
                    case '1':
                        AddSampleCustomer();
                        break;
                    case '2':
                        GetById();
                        break;
                    default:
                        Console.WriteLine();
                        Console.WriteLine();
                        Console.WriteLine("This option is invalid!");
                        break;
                }
            }
        }

        private static void ShowMenu()
        {
            Console.Clear();
            Console.WriteLine("SOLID SRP Customer Service Sample");
            Console.WriteLine("---------------------------------");
            Console.WriteLine();
            Console.WriteLine("0 - Exit From Customer Service");
            Console.WriteLine("1 - Add New Customer");
            Console.WriteLine("2 - Get Customer By Id");
            Console.WriteLine();
            Console.Write("Please, choose one option: ");
        }

        private static string Add(Customer customer)
        {
            if (!customer.IsValid())
            {
                return "Customer data is invalid!";
            }

            Repository.Add(customer);

            return EmailServices.Send(customer.Email, "Welcome", "Congratulations! You are registered.")
                ? "Customer successfully registered!"
                : "Customer successfully registered, but email was not sent! Review the SMTP settings in configuration file.";
        }

        private static void AddSampleCustomer()
        {
            var id = Repository.CustomerCount() + 1;
            var customer = new Customer
            {
                Email = ConfigurationManager.AppSettings["CustomerEmail"],
                Id = id,
                InsertDate = DateTime.Now,
                Name = $"John Doe {id}",
                Ssn = $"{id}23456789"
            };

            Console.WriteLine();
            Console.WriteLine("Adding a New Customer...");
            Console.WriteLine();
            Console.WriteLine(Add(customer));
            Console.WriteLine();
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }

        private static void GetById()
        {
            Console.WriteLine();
            Console.Write("Valid Id List: ");
            Console.WriteLine(Repository.GetAllIds());
            Console.WriteLine();
            Console.Write("Choose your Id: ");

            int id;
            int.TryParse(Console.ReadKey().KeyChar.ToString(), out id);

            var customer = Repository.GetById(id);

            Console.WriteLine();

            if (customer == null)
            {
                Console.WriteLine($"Customer not found!");
            }
            else
            {
                ShowCustomerData(customer);
            }

            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }

        private static void ShowCustomerData(Customer customer)
        {
            Console.WriteLine();
            Console.WriteLine($"Id...............: {customer.Id}");
            Console.WriteLine($"Name.............: {customer.Name}");
            Console.WriteLine($"Email............: {customer.Email}");
            Console.WriteLine($"SSN..............: {customer.Ssn}");
            Console.WriteLine($"Registration Date: {customer.InsertDate.ToString("D")}");
            Console.WriteLine();
        }
    }
}