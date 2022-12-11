class ShowsUI
{
    public ShowDB db = new();
    public Menu menu = new();
    public List<Show> showTitle = new();
    public List<ShowToDates> showDates = new();
    public int showId { get; set; }
    public int showDatesId { get; set; }
    public void ShowsMenu()
    {
        while (true)
        {
            showTitle = db.SelectShows();
            showId = menu.PrintMenuObjectTitle(showTitle);
            if (showId == -1) break;
            ShowsDateTime(showId);
        }
    }

    private int ShowsDateTime(int showId)
    {
        while (true)
        {
            // choose show and prints out dates and times
            showDates = db.SelectSingleShowDate(showId);
            showDatesId = menu.PrintMenuObjectDate(showDates);
            return showDatesId;
        }
    }
}