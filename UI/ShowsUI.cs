class ShowsUI
{
    public Menu menu = new();
    public ShowDB ShowDB = new();
    public List<Show> showTitle = new();
    public List<ShowToDates> showDates = new();
    public SeatDB seatDB = new();
    public SeatsMapper seatMap = new();
    public int showId { get; set; }
    public int showDatesId { get; set; }
    public void ShowsMenu()
    {
        while (true)
        {
            showTitle = ShowDB.SelectShows();
            showId = menu.PrintMenuObjectTitle(showTitle);
            if (showId == -1) break;
            ShowsDateTime(showId);
            if (showDatesId > 0) SeatsPerShow(showDatesId);
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

    private void SeatsPerShow(int showDatesId)
    {
        List<Seat> seatList = new();
        List<Seat> availableSeats = new();

        seatList = seatDB.GetAllSeats();
        seatMap.GetList(seatList);

        Console.WriteLine(showDatesId);
        Console.ReadLine();
        availableSeats = seatDB.AvailableSeats(showDatesId);
        int bookSeats = seatMap.ChooseSeats(availableSeats);
        Console.WriteLine("Seat : " + bookSeats);

        // SeatDB db = new();
        // SeatsMapper print = new();
        // List<Seat> list = new();
        // print.GetList(list);
        // list = db.GetAllSeats();
        // List<Seat> available = db.AvailableSeats();
        // int bookSeats = print.ChooseSeats(available);
        // Console.WriteLine("Seat : " + bookSeats);
    }
}