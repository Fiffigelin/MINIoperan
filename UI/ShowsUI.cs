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
        // gets available seats from choosen show and date and holds choosen seats for user
        seatList = seatDB.GetAllSeats();
        seatMap.GetList(seatList);

        Console.WriteLine(showDatesId);
        Console.ReadLine();
        availableSeats = seatDB.AvailableSeats(showDatesId);
        bookSeats = seatMap.AvailableSeats(availableSeats);
        foreach (var item in bookSeats)
        {
            Console.WriteLine("Seat : " + item);
        }
        Console.ReadLine();
    }
}