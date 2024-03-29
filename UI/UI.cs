class UI
{
    public Customer customer = new();
    Menu menu = new();
    public Customer InputCustomerEmail()
    {
        customer = new();
        while (true)
        {
            Console.CursorVisible = false;
            menu.Header();
            do
            {
                Console.Write("Please enter email : ");
                customer.Email = Console.ReadLine()!;
            } while (!customer.Email.Contains("@") || string.IsNullOrEmpty(customer.Email));

            return customer;
        }
    }

    public (bool, Customer) VerifyPassword(Customer customer)
    {
        int count = 0;
        string password = string.Empty;
        if (customer.Id == 0)
        {
            Console.WriteLine("\nNo inlog with that email found!");
            Console.ReadKey(true);
            return (false, customer);
        }
        do
        {
            menu.Header();
            Console.WriteLine($"Hi {customer.FirstName} {customer.LastName}!");
            Console.Write("Please enter your password : ");
            password = Console.ReadLine()!;
            count++;

        } while (password.Length < 5 || count == 3);

        if (password == customer.Password)
        {
            return (true, customer);
        }
        else if (count == 3) return (false, customer);
        return (false, customer);
    }

    public (int, bool) RemoveShowsID()
    {
        Console.WriteLine("If you accidentally came here, you can return by pressing Q.");
        Console.Write("Please enter BookingId you want to cancel : ");
        string input = Console.ReadLine();
        if (input.ToUpper() == "Q" || input == 0.ToString())
        {
            return (0, true);
        }

        int id = Convert.ToInt32(input);
        return (id, false);
    }

    public Customer CustomerLogic(Customer customer)
    {
        while (true)
        {
            Console.CursorVisible = false;
            menu.Header();
            Console.WriteLine($"Hi {customer.FirstName} {customer.LastName}, is this you?\nAnswer Y/N");
            ConsoleKey key = Console.ReadKey(true).Key;

            if (key == ConsoleKey.Y)
            {
                menu.Header();
                Console.WriteLine($"Welcome back {customer.FirstName} {customer.LastName}");;
                Console.ReadLine();
                return customer;
            }
            else if (key == ConsoleKey.N)
            {
                return customer;
            }
        }
    }

    public Customer CreateCustomer(Customer customer)
    {
        while (true)
        {
            menu.Header();
            do
            {
                Console.Write("Please enter your first name  : ");
                customer.FirstName = Console.ReadLine()!;
            } while (string.IsNullOrEmpty(customer.FirstName));
            do
            {
                Console.Write("Please enter your last name   : ");
                customer.LastName = Console.ReadLine()!;
            } while (string.IsNullOrEmpty(customer.LastName));
            return customer;
        }
    }

    public string AskForPhonenr()
    {
        string phonenr = string.Empty;
        do
        {
            Console.Write("Please enter your phonenumber : ");
            phonenr = Console.ReadLine()!;
        } while (string.IsNullOrEmpty(phonenr));
        return phonenr;
    }

    public string CreatePassword()
    {
        Console.WriteLine("Would you like to create a inlog?");
        Console.WriteLine("Answer with Y/N");
        ConsoleKey key = Console.ReadKey(true).Key;

        string password = string.Empty;
        if (key == ConsoleKey.Y)
        {
            do
            {
                Console.WriteLine("Make a password thats minimum 6 chars long");
                Console.Write("Please enter your password : ");
                password = Console.ReadLine();

            } while (password.Length < 6);
        }
        return password;
    }

    public void PrintCountSum(List<int> intList)
    {
        Console.WriteLine($"Total amount of shows booked : {intList.ElementAt(0)}");
        Console.WriteLine($"Total price                  : {intList.ElementAt(1)}");
        Console.WriteLine(Environment.NewLine);
    }
}