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
                Console.WriteLine("Här kan man logga in som användare");
                Console.ReadLine();
                    continue;

                case 1:
                    // prints out available shows titles
                    if (logic.ShowsTitle() == true) continue;
                    logic.PrintShowInfo();
                    break;
            }
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