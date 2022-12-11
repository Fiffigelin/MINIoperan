class ShowsUI
{
    public ShowDB db = new();
    public Menu menu = new();
    public List<Show> showTitle = new();
    public List<ShowToDates> showDates = new();
    public int showId {get; set;}
    public void ShowsMenu()
    {
        while (true)
        {
            showTitle = db.SelectShows();
            showId = menu.PrintMenuObjectTitle(showTitle);

            switch(showId)
            {
                case 1:
                    showDates = db.SelectSingleShowDate(showId);
                    showId = menu.PrintMenuObjectDate(showDates);
                    // Environment.Exit(0);
                break;

                case 2:
                // cats
                break;

                case 3:
                // star wars
                break;

                case 4:
                // peter pan
                break;

                case 5:
                return;
            }
        }
    }
}