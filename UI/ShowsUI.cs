class ShowsUI
{
    public void ShowsMenu()
    {
        while (true)
        {
            ShowDB db = new();
            List<Show> show = new();
            show = db.SelectShows();
            Menu menu = new();
            int showId = menu.PrintMenuObject(show);

            switch(showId)
            {
                case 1:
                    // Phantomen på operan
                    Environment.Exit(0);
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