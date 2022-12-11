class ShowsUI
{
    public Menu menu = new();
    public ShowDB ShowDB = new();
    public List<Show> showTitle = new();
    public List<ShowToDates> showDates = new();
    public SeatDB seatDB = new();
    public SeatsMapper seatMap = new();
    public List<Seat> seatList = new();
    public List<Seat> availableSeats = new();
    public List<int> bookSeats = new();
    public Customer customer;
    public CustomerDB customerDB = new();
    public List<Customer> custList = new();
    public Reservation reservation = new();
    public ReservationDB reservDB = new();

    public int showId { get; set; }
    public int showDatesId { get; set; }
    public void ShowsMenu()
    {
        while (true)
        {
            // prints out available shows titles
            showTitle = ShowDB.SelectShows();
            showId = menu.PrintMenuObjectTitle(showTitle);
            if (showId == -1) break;

            // prints out available shows by date and time
            ShowsDateTime(showId);
            if (showDatesId > 0) SeatsPerShow(showDatesId);

            // customer
            var logicItems = IsEmailExisting();
            CustomerLogic(logicItems.Item1, logicItems.Item2);
            customer = logicItems.Item2;
            if (IsEmailExisting().Item1 == false)
            {
                customer = CreateCustomer();
                customer.Id = customerDB.InsertNewCustomer(customer);
            }

            Console.WriteLine(customer.Id);
            Console.ReadLine();
        }
    }

    private int ShowsDateTime(int showId)
    {
        while (true)
        {
            // choose show and prints out dates and times
            showDates = ShowDB.SelectSingleShowDate(showId);
            showDatesId = menu.PrintMenuObjectDate(showDates);
            return showDatesId;
        }
    }

    // ska returnera en lista med int
    private void SeatsPerShow(int showDatesId)
    {
        // gets available seats from choosen show and date and holds choosen seats for user
        seatList = seatDB.GetAllSeats();
        seatMap.GetList(seatList);

        Console.WriteLine(showDatesId);
        Console.ReadLine();
        availableSeats = seatDB.AvailableSeats(showDatesId);
        bookSeats = seatMap.AvailableSeats(availableSeats);
    }

    private (bool, Customer) IsEmailExisting()
    {
        customer = new();
        bool IsCustomerEmail = false;
        while (true)
        {
            Console.CursorVisible = false;
            menu.Header();
            do
            {
                Console.Write("Please enter email : ");
                customer.Email = Console.ReadLine();
            } while (!customer.Email.Contains("@") || string.IsNullOrEmpty(customer.Email));

            customer = customerDB.GetCustomerByEmail(customer);
            if (customer.Id == 0)
            {
                Console.WriteLine("false");
                Console.ReadLine();
                return (IsCustomerEmail, customer);
            }
            else
            {
                IsCustomerEmail = true;
                Console.WriteLine("true");
                Console.ReadLine();
                return (IsCustomerEmail, customer);
            }
        }
    }

    private Reservation CustomerLogic(bool IsCustomerEmail, Customer customer)
    {
        while (true)
        {
            Console.CursorVisible = false;
            if (IsCustomerEmail == true)
            {
                Console.WriteLine($"Hi {customer.FirstName} {customer.LastName}, is this you?\nAnswer Y/N");
                ConsoleKey key = Console.ReadKey(true).Key;
                if (key == ConsoleKey.Y)
                {
                    menu.Header();
                    Console.WriteLine($"Welcome back {customer.FirstName} {customer.LastName}");
                    reservation.CustomerId = customer.Id;
                    Console.ReadLine();
                    return reservation;
                }
                else if (key == ConsoleKey.N)
                {
                    return reservation;
                }
            }
        }
    }

    private Customer CreateCustomer()
    {
        bool isPhone = false;
        while (true)
        {
            menu.Header();
            do
            {
                Console.Write("Please enter your first name  : ");
                customer.FirstName = Console.ReadLine();
            } while (string.IsNullOrEmpty(customer.FirstName));
            do
            {
                Console.WriteLine($"Please enter your first name  : {customer.FirstName}");
                Console.Write("Please enter your last name   : ");
                customer.LastName = Console.ReadLine();
            } while (string.IsNullOrEmpty(customer.LastName));
            do
            {
                Console.WriteLine($"Please enter your first name  : {customer.FirstName}");
                Console.WriteLine($"Please enter your last name   : {customer.LastName}");
                Console.Write("Please enter email            : ");
                customer.Email = Console.ReadLine();
            } while (!customer.Email.Contains("@") || string.IsNullOrEmpty(customer.Email));
            do
            {
                Console.WriteLine($"Please enter your first name  : {customer.FirstName}");
                Console.WriteLine($"Please enter your last name   : {customer.LastName}");
                Console.WriteLine($"Please enter your email       : {customer.LastName}");
                Console.Write("Please enter your phonenumber : ");
                customer.Phonenumber = Console.ReadLine();
                isPhone = IsStringNumeric(customer.Phonenumber);
            } while (string.IsNullOrEmpty(customer.Phonenumber) && isPhone == false);

            return customer;
        }
    }

    private bool IsStringNumeric(string s)
    {
        foreach (char c in s)
        {
            if (c < '0' || c > '9')
            {
                if (s.Length != 10)
                {
                    return false;
                }
            }
        }
        return true;
    }
}