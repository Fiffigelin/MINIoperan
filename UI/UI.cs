class UI
{
    public Customer customer = new();


    public void PrintTickets(Reservation reservation, Customer customer, List<Seat> seatList, ShowToDates showDates)
    {
        foreach (var seat in seatList)
        {
            PrintLine();
            PrintRow("Name", customer.FirstName + " " + customer.LastName);
            PrintLine();
            PrintRow("Show", showDates.Title);
            PrintLine();
            PrintRow("Date", showDates.Date.ToString("yyyy-MM-dd"));
            PrintLine();
            PrintRow("Time", showDates.Time.ToString());
            PrintLine();
            PrintRow("Section", seat.Section);
            PrintRow("Row", seat.Row.ToString());
            PrintRow("Seat", seat.Id.ToString());
            PrintRow("Price", seat.Price.ToString());
            PrintLine();
            Console.Write($"\n\n");
        }
        Console.ReadLine();

    }

    private void PrintLine()
    {
        Console.WriteLine(new string('-', 75));
    }

    private void PrintRow(params string[] columns)
    {
        int width = (75 - columns.Length) / columns.Length;
        string row = "|";

        foreach (string column in columns)
        {
            row += AlignCentre(column, width) + "|";
        }

        Console.WriteLine(row);
    }

    private string AlignCentre(string text, int width = 75)
    {
        text = text.Length > width ? text.Substring(0, width - 3) + "..." : text;

        if (string.IsNullOrEmpty(text))
        {
            return new string(' ', width);
        }
        else
        {
            return text.PadRight(width - (width - text.Length) / 2).PadLeft(width);
        }
    }

    public string InputCustomerEmail()
    {
        string email = string.Empty;
        while (true)
        {
            Console.CursorVisible = false;
            Header();
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
            Header();
            Console.WriteLine($"Hi {customer.FirstName} {customer.LastName}, is this you?\nAnswer Y/N");
            ConsoleKey key = Console.ReadKey(false).Key;

            if (key == ConsoleKey.Y)
            {
                Header();
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

    public Customer CreateCustomer()
    {
        bool isPhone = false;
        while (true)
        {
            Header();
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
            do
            {
                Console.Write("Please enter email            : ");
                customer.Email = Console.ReadLine()!;
            } while (!customer.Email.Contains("@") || string.IsNullOrEmpty(customer.Email));
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
    



    public void Header()
    {
        Console.Clear();
        Console.WriteLine(@$"
                              ▄█▀      ▀█▄
                          ▄▀▀▓▀▄         ██▄  
                         ▓  ▄▀  █        ██▓█
                          ▀▄▓▓▄▀         ▓██▓▌
                           █▓██▌         ▓▓▓█▌
                            █▓█▌         ▐▓██        
            █▀▄▀█ █ █▄ █ █   ▀▓█         ▐▓▀
            █ ▀ █ █ █ ▀█ █     ▀█▄     ▄█▀
    ");
    }
}