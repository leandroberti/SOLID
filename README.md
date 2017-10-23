# SOLID Principles

[![Donate](https://img.shields.io/badge/Donate-PayPal-green.svg)](https://www.paypal.com/cgi-bin/webscr?cmd=_donations&business=26TY9QLTDWDSE&lc=US&item_name=leandroberti&item_number=github&currency_code=USD&bn=PP%2dDonationsBF%3abtn_donate_SM%2egif%3aNonHosted)

## What is SOLID?

The SOLID principles are five programming principles which is considered to be the foundation of every well designed application.


> S - Single Responsibility Principle (SRP)
> 
> O - Open Closed Principle (OCP)
> 
> L - Liskov Substitution Principle (LSP)
> 
> I - Interface Segregation Principle (ISP)
> 
> D - Dependency Inversion Principle (DIP)


If you want to know more about S.O.L.I.D. please visit [this site.](http://blog.gauffin.org/2012/05/solid-principles-with-real-world-examples/)


## About the Project

This project is intended to demonstrate the violation of each of the principles and demonstrate how SOLID can provide you with a better code design for easy maintenance and testing.

The project is a Console Application containing 5 folders (one for each S.O.L.I.D. principle). Inside of each folder we have one folder for the principle violation example (violation folder) and other for demostrate how to use the principle (solution folder).

All the principle solutions are fully functional and can be accessed from the Console App.

### The Single Responsibility Principle (SRP)

This principle says:

> "A class should have one, and only one, reason to change."

The violation folder (LMB.SOLID\1 - SRP\SRP.Violation) has a ```Customer``` class with some properties and one ```Add()``` method.

This ```Add()``` method has a lot of funcionality, like:

* customer data validation
* data access
* send email messages

All those points above can be a reason to change the ```Customer``` class, violating the SRP.

The solution folder (LMB.SOLID\1 - SRP\SRP.Solution) has:

* a ```Customer``` class with the responsibility to assess the customer data.
* a ```CustomerInMemoryData``` class with the responsibility to store customer data (in memory to simplify the example).
* a ```CustomerRepository``` class with the responsibility to access the customer data store.
* a ```CustomerService``` class with the responsibility to provide all customer operations.
* a ```EmailServices``` class with the responsibility to send email messages.
* a ```SsnServices``` class with the responsibility to validate the Social Secutity Number.

Here (in solution) all responsibilities have been implemented in their proper classes like SRP says.

### The Open Closed Principle (OCP)

This principle says:

> "Software entities (classes, modules, functions, etc.) should be open for extension, but closed for modification."

The violation folder (LMB.SOLID\2 - OCP\OCP.Violation) has a ```Deposit``` class with a ```DepositValue()``` method. This method has an ```IF``` statement that verify the ```AccountType``` parameter to chose what kind of process will be done.

Every time that a new ```AccountType``` is created, the ```DepositValue()``` method need to be modified, violating the OCP.

The solution folder (LMB.SOLID\2 - OCP\OCP.Solution) has:

* a ```Account``` class containing account data and a method to return the transaction number.
* a ```AtmMachineService``` class to provide all customer operations.
* a ```DepositCheckingAccount``` class to handle Checking Account transactions.
* a ```DepositInvestingAccount``` class to handle Investing Account transactions.
* a ```DepositSavingsAccount``` class to handle Savings Account transactions.

Here (in OCP solution) all ATM operations will be handled by a specialized class, leaving the ATM service open for extension, but closed for modification.

### The Liskov Substitution Principle (LSP)

This principle says:

> "Derived classes must be replaced by their base classes."

The violation folder (LMB.SOLID\3 - LSP\LSP.Violation) has three classes:

* ```AreaCalculator``` class with a ```Calculate()``` and ```CalculateRectangleArea()``` methods.
* ```Rectangle``` class with ```Height``` and ```Width``` properties.
* ```Square``` class derived from ```Rectangle``` class with ```Height``` and ```Width``` properties.

The ```Calculate()``` method from ```AreaCalculator``` class instanciate a new ```Square``` class and calls the ```CalculateRectangleArea()``` method (that calculates the square area).

The ```Square``` class looks like a ```Rectangle``` class, has the same ```Height``` and ```Width``` properties, but it can't replace the ```Rectangle``` class, because the Width and the Height are been set to the same value.

The solution folder (LMB.SOLID\3 - LSP\LSP.Solution) has:

* a ```AreaCalculatorService``` class to provide all area calc operations.
* a ```GeometricForm``` class containing some properties. This class is the base class.
* a ```Parallelogram``` class (derived from  ```GeometricForm``` class ) that handle parallelogram area calc.
* a ```Rectangle``` class (derived from  ```GeometricForm``` class ) that handle rectangle area calc.
* a ```Square``` class (derived from  ```GeometricForm``` class ) that handle square area calc.

Here (in LSP solution) all derived classes can be replaced by their base class ```GeometricForm```.

### The Interface Segregation Principle (ISP)

This principle says:

> "Many specific interfaces are better than a single interface."

The violation folder (LMB.SOLID\4 - ISP\ISP.Violation) has two classes: ```CustomerRegistration``` and ```ProductRegistration```.

Those classes inherit from the ```IRegistration``` interface that implement three methods:

* ```ValidateData()``` method.
* ```SaveData()``` method.
* ```SendEmail()``` method.

The ```CustomerRegistration``` class has the implementation for all three interface methods, but for the ```ProductRegistration``` the implementation of ```SendEmail()``` method does not make any sense.

The solution folder (LMB.SOLID\4 - ISP\ISP.Solution) has the same two classes: ```CustomerRegistration``` and ```ProductRegistration```, and one more class the ```RegistrationService``` one.

But here, we have one more folder (LMB.SOLID\4 - ISP\ISP.Solution\Contratcs) that have two interfaces:

* ```ICustomer``` with ```ValidateData()```, ```SaveData()``` and ```SendEmail()``` methods.
* ```IProduct``` with ```ValidateData()```and ```SaveData()``` methods only.

Doing this way, segregating into two interfaces, we have a better implementation for the ```CustomerRegistration``` and ```ProductRegistration``` classes, having now only methods that make sense for each one.

### The Dependency Inversion Principle (DIP)

This principle says:

> "Depend on an abstraction, not an implementation."

The violation folder (LMB.SOLID\5 - DIP\DIP.Violation) has only the class ```CustomerService``` with a comment saying that the SRP implementation violates the DIP... and, for real, IT DOES!

In the SRP implementation all classes that needs some service, instanciate that service inside itself. If we need other kind of implementation of those services, the classes that instanciate they need to be changed, violating the OCP too.

The solution folder (LMB.SOLID\5 - DIP\DIP.Solution) has the same classes of the SRP solution folder, but all those classes now, implements its own interface. Those interfaces are inside the (LMB.SOLID\5 - DIP\DIP.Solution\Contratcs) folder.

What changes here (from SRP solution) is that all classes have a new constructor and in this contructor they receive (as a parameter) all services and other instances that they need.

All the service instances are created outside and injected back into the classes. This is called Inversion of Control (IoC).

Doing this way, if we need other kind of implementation for the services, it can be done without we have to change the implementation of the classes that use the services. Only we have to do here, is respect the interface implementation.

# Donations

**If you enjoy this work, please consider supporting me for developing and maintaining this (and others) templates.**

[![paypal](https://www.paypalobjects.com/en_US/i/btn/btn_donateCC_LG.gif)](https://www.paypal.com/cgi-bin/webscr?cmd=_donations&business=26TY9QLTDWDSE&lc=US&item_name=leandroberti&item_number=github&currency_code=USD&bn=PP%2dDonationsBF%3abtn_donate_SM%2egif%3aNonHosted)
