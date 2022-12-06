internal class Program
{
    private static void Main(string[] args)
    {
        SeatDB db = new();
        SeatsMapper print = new();
        List<Seat> list = new();
        list = db.GetAllSeats();
        Menu mainMenu = new();
        print.GetList(list);

        string[] menuChoice = { "Show seats", "Exit" };
        int menuInt = mainMenu.PrintMenu(menuChoice);
        switch (menuInt)
        {
            case 0:
                List<Seat> available = db.AvailableSeats();
                print.ChooseSeats(available);
                break;
            case 1:
                Environment.Exit(0);
                break;
            default:
            break;
        }
    }
}