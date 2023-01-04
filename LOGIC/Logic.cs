class Logic
{
    List<Show> showTitle = new();
    List<ShowToDates> showDatesList = new();
    List<Seat> seatList = new();
    List<Seat> bookSeats = new();
    List<PerformerRole> perfRoleList = new();
    ShowDB showDB = new();
    SeatDB seatDB = new();
    SeatRender seatRender = new();
    Reservation reservation = new();
    ReservationDB reservationDB = new();
    Menu menu = new();
    Customer customer = new();
    CustomerDB customerDB = new();
    UI ui = new();
    SeatUI seatUI = new();
    TableUI tableUI = new();

    public (int, bool) HeadMenu()
    {
        string[] array = { "Login", "Show info" };
        var menuItem = menu.PrintMenuArray(array);
        return (menuItem.Item1, menuItem.Item2);
    }
    public bool LogIn()
    {
        customer = customerDB.SelectCustomerByEmail(ui.InputCustomerEmail());
        var password = ui.VerifyPassword(customer);
        return password.Item1;
    }
    public bool UsersMenu()
    {
        string[] array = { "Print booked shows" };
        var menuItem = menu.PrintMenuArray(array);
        return menuItem.Item2;
    }
    public void PrintBookedShows()
    {
        seatList.Clear();
        ShowToDates showDates = new();
        List<int> intList = reservationDB.SelectReservationsByCustomer(customer);

        foreach (var item in intList)
        {
            reservation = reservationDB.SelectSingleReservation(item);
            var classObjects = reservationDB.SelectReceiptInfo(reservation);
            seatList = classObjects.Item1;
            showDates = classObjects.Item2;
            tableUI.PrintBooked(customer, reservation, seatList, showDates);
        }
        Console.ReadKey(true);
    }

    public bool RemoveBooking()
    {
        string[] array = { "Remove booking" };
        var menuItem = menu.PrintArray(array);
        return menuItem.Item2;
    }
    public bool ExecuteRemoving()
    {
        var remove = ui.RemoveShowsID();
        if (remove.Item2 == true) return true;
        reservationDB.DeleteReservation(remove.Item1);
        return false;
    }
    public bool ShowsTitle()
    {
        showTitle = showDB.SelectShows();
        var showItem = menu.PrintMenuObjectTitle(showTitle);
        reservation.ShowId = showItem.Item1.Id;
        return showItem.Item2;
    }
    public bool PrintShowInfo()
    {
        menu.PrintLogo(reservation.ShowId);
        perfRoleList = showDB.SelectPerformerPerShow(reservation);
        tableUI.PrintRolesToShow(perfRoleList);
        string[] array = { "Make a booking" };
        var menuItem = menu.PrintArray(array);
        return menuItem.Item2;
    }
    public bool ShowDatesTime()
    {
        showDatesList = showDB.SelectSingleShowDate(reservation.ShowId);
        var showItem = menu.PrintMenuObjectDate(showDatesList);
        reservation.ShowDateId = showItem.Item1;
        return showItem.Item2;
    }

    public void CheckCustomer()
    {
        customer = customerDB.SelectCustomerByEmail(ui.InputCustomerEmail());
        bool found = SearchForEmail(customer);
        if (found == true) 
        {
            ui.CustomerLogic(customer);
            reservation.CustomerId = customer.Id;
        }
        if (reservation.CustomerId == 0)
        {
            customer = ui.CreateCustomer(customer);
            customer.Phonenumber = GetPhonenr();
            customer = customerDB.InserCustomer(customer);
            reservation.CustomerId = customer.Id;
        }
        customer = customerDB.SelectCustomerById(reservation);
    }

    public void MakeReservation()
    {
        GetSeatInfo();
        CalculateTotalPrice();
        SeatRender();
        tableUI.PrintTickets(reservation, customer, seatList, GetInfoForTickets());
    }

    public void CreateInlog()
    {
        if (string.IsNullOrEmpty(customer.Password))
        {
            customer.Password = ui.CreatePassword();
            customerDB.InsertPassword(customer);
        }
    }

    // check if input of email already exists in db
    private bool SearchForEmail(Customer customer)
    {
        while (true)
        {
            customer = customerDB.SelectCustomerByEmail(customer);
            if (customer.Id == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }

    // verify right amount of numbers
    private string GetPhonenr()
    {
        string verifyPhonenr = string.Empty;
        while (true)
        {
            verifyPhonenr = ui.AskForPhonenr();
            if (IsStringNumeric(verifyPhonenr) == true) return verifyPhonenr;
        }
    }

    // verify however phonenumber contains only digits
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

    // assign choosen seats to reservation
    private void SeatRender()
    {
        reservation = reservationDB.InsertReservation(reservation);

        foreach (var seat in seatList)
        {
            seatRender.SeatId = seat.Id;
            seatRender.ReservationId = reservation.Id;
            seatRender.ShowDateId = reservation.ShowDateId;
            seatDB.InsertSeatToReservation(seatRender);
        }
    }
    private void GetSeatInfo()
    {
        seatList.Clear();
        foreach (var seat in bookSeats)
        {
            Seat bSeat = seatDB.SelectSeatById(seat.Id);
            seatList.Add(bSeat);
        }
    }
    public bool SeatsPerShow()
    {
        // gets available seats from choosen show and date and holds choosen seats for user
        seatList = seatDB.SelectAllSeats();
        int[,] matrix = seatUI.ConvertToMatrix(seatList);

        seatList = seatDB.SelectAvailableSeats(reservation.ShowDateId);
        var seatsItem = seatUI.AvailableSeats(matrix, seatList);
        bookSeats = seatsItem.Item1;
        return seatsItem.Item2;
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

    // gets info for outprint from db
    private ShowToDates GetInfoForTickets()
    {
        reservation = reservationDB.SelectSingleReservation(reservation.Id);
        customer = customerDB.SelectCustomerById(reservation);
        var classObjects = reservationDB.SelectReceiptInfo(reservation);
        seatList = classObjects.Item1;
        return classObjects.Item2;
    }
}