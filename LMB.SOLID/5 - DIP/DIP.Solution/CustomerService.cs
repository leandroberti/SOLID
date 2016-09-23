using System;
using System.Configuration;
using LMB.SOLID.DIP.Solution.Contracts;

namespace LMB.SOLID.DIP.Solution
{
    public class CustomerService
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IEmailServices _emailServices;
        private readonly ISsnServices _ssnServices;

        public CustomerService(ICustomerRepository customerRepository, IEmailServices emailServices,
            ISsnServices ssnServices)
        {
            _customerRepository = customerRepository;
            _emailServices = emailServices;
            _ssnServices = ssnServices;
        }

        public void CustomerOperations()
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

        private void ShowMenu()
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

        private string Add(ICustomer customer)
        {
            if (!customer.IsValid())
            {
                return "Customer data is invalid!";
            }

            _customerRepository.Add(customer);

            return _emailServices.Send(customer.Email, "Welcome", "Congratulations! You are registered.")
                ? "Customer successfully registered!"
                : "Customer successfully registered, but email was not sent! Review the SMTP settings in configuration file.";
        }

        private void AddSampleCustomer()
        {
            var id = _customerRepository.CustomerCount() + 1;

            // Here the customer class is been instanciated because we are creating a sample one.
            var customer = new Customer(_ssnServices, _emailServices)
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

        private void GetById()
        {
            Console.WriteLine();
            Console.Write("Valid Id List: ");
            Console.WriteLine(_customerRepository.GetAllIds());
            Console.WriteLine();
            Console.Write("Choose your Id: ");

            int id;
            int.TryParse(Console.ReadKey().KeyChar.ToString(), out id);

            var customer = _customerRepository.GetById(id);

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

        private void ShowCustomerData(ICustomer customer)
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