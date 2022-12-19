internal class Program
{
    public static Logic logic = new();
    private static void Main(string[] args)
    {
        while (true)
        {
            var menu = logic.HeadMenu();
            if (menu.Item2 == (true)) break;
            switch (menu.Item1)
            {
                case 0:
                    // User inlog here
                    break;
                case 1:
                BookShows();
                    break;
            }

        }
    }
    public static void BookShows()
    {
            if (logic.ShowsTitle() == true) return;
            if (logic.PrintShowInfo() == true) return;
            // prints out available shows by date and time
            if (logic.ShowDatesTime() == true) return;
            // choose seats
            if (logic.SeatsPerShow() == true) return;
            // check if customer exists in DB, if not new customer is created
            logic.CheckCustomer();
            // calculate cost and insert reservation to DB and prints out ticket/s
            logic.MakeReservation();
    }
}