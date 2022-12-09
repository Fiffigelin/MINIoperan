class ShowsUI
{
    public void ShowsMenu()
    {
        while (true)
        {
            ShowDB showDB = new();
            List <Show> listOfShow = showDB.SelectShows();
            // string[] shows = { "Phantom of the Opera", "Cats", "Starwars : the Empire strikes back", "Peter Pan går åt helvete" };
            Menu showMenu = new();
            int showInt = showMenu.PrintMenuObject(listOfShow);
            switch (showInt)
            {
                default:
                case 0:
                    Environment.Exit(0);
                    break;
            }
        }
    }
}