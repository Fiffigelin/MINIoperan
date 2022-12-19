class Logic
{
    List<Show> showTitle = new();
    List<ShowToDates> showDatesList = new();
    List<Seat> seatList = new();
    List<Seat> bookSeats = new();
    List <PerformerRole> perfRoleList = new();
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
       string [] array = {"Show info"};
       var menuItem = menu.PrintMenuArray(array);
       return (menuItem.Item1, menuItem.Item2);
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
        string[] array = {"Make a booking"};
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
        var customerItem = SearchForEmail(ui.InputCustomerEmail());
        if (customerItem.Item1 == true) reservation.CustomerId = ui.CustomerLogic(customerItem.Item2);
        if (reservation.CustomerId == 0)
        {
            customer = ui.CreateCustomer();
            customer.Phonenumber = GetPhonenr();
            reservation.CustomerId = customer.Id;
        }
    }

    public void MakeReservation()
    {
        GetSeatInfo();
        CalculateTotalPrice();
        SeatRender();
        tableUI.PrintTickets(reservation, customer, seatList, GetInfoForTickets());
    }

    private (bool, Customer) SearchForEmail(string email)
    {
        customer = new();
        customer.Email = email;
        while (true)
        {
            customer = customerDB.GetCustomerByEmail(customer);
            if (customer.Id == 0)
            {
                return (false, customer);
            }
            else
            {
                return (true, customer);
            }
        }
    }

    private string GetPhonenr()
    {
        string verifyPhonenr = string.Empty;
        while (true)
        {
            verifyPhonenr = ui.AskForPhonenr();
            if (IsStringNumeric(verifyPhonenr) == true) return verifyPhonenr;
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
    private void SeatRender()
    {
        reservation = reservationDB.InsertReservation(reservation);

        foreach (var seat in seatList)
        {
            seatRender.SeatId = seat.Id;
            seatRender.ReservationId = reservation.Id;
            seatRender.ShowDateId = reservation.ShowDateId;
            seatDB.SeatToReservation(seatRender);
        }
    }
    private void GetSeatInfo()
    {
        seatList.Clear();
        foreach (var seat in bookSeats)
        {
            Seat bSeat = seatDB.GetSeatById(seat.Id);
            seatList.Add(bSeat);
        }
    }
    public bool SeatsPerShow()
    {
        // gets available seats from choosen show and date and holds choosen seats for user
        seatList = seatDB.GetAllSeats();
        int[,] matrix = seatUI.ConvertToMatrix(seatList);

        seatList = seatDB.AvailableSeats(reservation.ShowDateId);
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

    private ShowToDates GetInfoForTickets()
    {
        reservation = reservationDB.SelectSingleReservation(reservation.Id);
        customer = customerDB.GetCustomerById(reservation);
        var classObjects = reservationDB.SelectReceiptInfo(reservation);
        seatList = classObjects.Item1;
        return classObjects.Item2;
    }
}