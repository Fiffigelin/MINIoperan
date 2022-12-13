class UI
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
    public SeatRender seatRender = new();
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
            MakeReservation();
        }
    }

    private void PrintReceipt()
    {
        reservation = reservDB.SelectSingleReservation(reservation.Id);
        customer = customerDB.GetCustomerById(reservation);
        var classObjects = reservDB.SelectReceiptInfo(reservation);
        seatList = classObjects.Item1;
        ShowToDates showDates = classObjects.Item2;

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

    private void MakeReservation()
    {
        CheckingCustomer();
        GetSeatInfo();
        CalculateTotalPrice();
        SeatRender();
        PrintReceipt();
    }

    public void SeatRender()
    {
        reservation = reservDB.InsertReservation(reservation);

        foreach (var seat in seatList)
        {
            seatRender.SeatId = seat.Id;
            seatRender.ReservationId = reservation.Id;
            seatRender.ShowDateId = reservation.ShowDateId;
            seatDB.SeatToReservation(seatRender);
        }
    }
    public void GetSeatInfo()
    {
        seatList.Clear();
        foreach (var seat in bookSeats)
        {
            Seat bSeat = seatDB.GetSeatById(seat.Id);
            seatList.Add(bSeat);
        }
    }
    private void CalculateTotalPrice()
    {
        int totalCost = 0;
        foreach (var seat in seatList)
        {
            totalCost += seat.Price;
        }

        reservation.Price = totalCost;
    }
    private void CheckingCustomer()
    {
        Console.CursorVisible = false;
        var logicItems = IsEmailExisting();
        Quit = logicItems.Item1;
        customer = logicItems.Item2;

        if (Quit == true) reservation = CustomerLogic(customer);
        else
        {
            customer = CreateCustomer();
            customer.Id = customerDB.InsertNewCustomer(customer);
            reservation.CustomerId = customer.Id;
        }
    }
    private void ShowsTitle()
    {
        showTitle = ShowDB.SelectShows();
        var showItem = menu.PrintMenuObjectTitle(showTitle);
        ShowId = showItem.Item1;
        reservation.ShowId = showItem.Item1;
        Quit = showItem.Item2;
    }
    private void ShowsDateTime(int showId)
    {
        // choose show and prints out dates and times
        showDates = ShowDB.SelectSingleShowDate(showId);
        var showItem = menu.PrintMenuObjectDate(showDates);
        ShowDatesId = showItem.Item1;
        reservation.ShowDateId = ShowDatesId;
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
            ConsoleKey key = Console.ReadKey(false).Key;

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