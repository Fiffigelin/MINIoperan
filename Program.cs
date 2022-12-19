internal class Program
{
    public static Logic logic = new();
    private static void Main(string[] args)
    {
        while (true)
        {
            var menu = logic.HeadMenu();
            if (menu.Item2 == (true)) break;
            if (logic.ShowsTitle() == true) continue;
            if (logic.PrintShowInfo() == true) continue;


            // prints out available shows by date and time
            if (logic.ShowDatesTime() == true) continue;
            // choose seats
            if (logic.SeatsPerShow() == true) continue;
            // check if customer exists in DB, if not new customer is created
            logic.CheckCustomer();
            // calculate cost and insert reservation to DB and prints out ticket/s
            logic.MakeReservation();
        }
    }
}