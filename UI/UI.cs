class UI
{
    public Customer customer = new();
    Menu menu = new();
    public string InputCustomerEmail()
    {
        string email = string.Empty;
        while (true)
        {
            Console.CursorVisible = false;
            menu.Header();
            do
            {
                Console.Write("Please enter email : ");
                email = Console.ReadLine()!;
            } while (!email.Contains("@") || string.IsNullOrEmpty(email));

            return email;
        }
    }

    public int CustomerLogic(Customer customer)
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
                Console.WriteLine($"Welcome back {customer.FirstName} {customer.LastName}");
                int customerId = customer.Id;
                Console.ReadLine();
                return customerId;
            }
            else if (key == ConsoleKey.N)
            {
                return 0;
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
        if(key == ConsoleKey.Y)
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
}