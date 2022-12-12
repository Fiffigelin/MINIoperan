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
    public List<Seat> bookSeats = new();
    public Customer customer;
    public CustomerDB customerDB = new();
    public List<Customer> custList = new();
    public Reservation reservation = new();
    public ReservationDB reservDB = new();
    public bool Quit { get; set; }
    public int ShowId { get; set; }
    public int ShowDatesId { get; set; }
    public void ShowsMenu()
    {
        while (true)
        {
            // prints out available shows titles
            ShowsTitle();
            if (Quit == true) break;

            // prints out available shows by date and time
            ShowsDateTime(ShowId);
            if (Quit == true) continue;

            // choose seats
            SeatsPerShow(ShowDatesId);
            if (Quit == true) continue;

            // customer
            IsEmailInDatabase();

            // debugging
            Console.WriteLine(customer.Id);
            Console.ReadLine();

            // kom ihåg : ska göra reservationsbokning med säten och customers.id


        }
    }

    private void MakeReservation()
    {

    }
    private void IsEmailInDatabase()
    {
        var logicItems = IsEmailExisting();
        Quit = logicItems.Item1;
        customer = logicItems.Item2;
        
        if (Quit == true) CustomerLogic(customer);
        else
        {
            customer = CreateCustomer();
            customer.Id = customerDB.InsertNewCustomer(customer);
        }
    }
    private void ShowsTitle()
    {
        showTitle = ShowDB.SelectShows();
        var showItem = menu.PrintMenuObjectTitle(showTitle);
        ShowId = showItem.Item1;
        Quit = showItem.Item2;
    }
    private void ShowsDateTime(int showId)
    {
            // choose show and prints out dates and times
            showDates = ShowDB.SelectSingleShowDate(showId);
            var showItem = menu.PrintMenuObjectDate(showDates);
            ShowDatesId = showItem.Item1;
            Quit = showItem.Item2;
    }

    // ska returnera en lista med int
    private void SeatsPerShow(int showDatesId)
    {
        // gets available seats from choosen show and date and holds choosen seats for user
        seatList = seatDB.GetAllSeats();
        seatMap.GetList(seatList);

        availableSeats = seatDB.AvailableSeats(showDatesId);
        var seatsItem = seatMap.AvailableSeats(availableSeats);
        bookSeats = seatsItem.Item1;
        Quit = seatsItem.Item2;
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
                customer.Email = Console.ReadLine()!;
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

    private Reservation CustomerLogic(Customer customer)
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

    private Customer CreateCustomer()
    {
        bool isPhone = false;
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
            do
            {
                Console.Write("Please enter email            : ");
                customer.Email = Console.ReadLine()!;
            } while (!customer.Email.Contains("@") || string.IsNullOrEmpty(customer.Email));
            do
            {
                Console.Write("Please enter your phonenumber : ");
                customer.Phonenumber = Console.ReadLine()!;
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