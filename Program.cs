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
        ShowDB showDB = new();
        List<ShowDates> showDates = new();
        showDates = showDB.SelectShowDate();
        foreach (var item in showDates)
        {
            Console.WriteLine($@"{item.ShowId} {item.Title} {item.Type} {item.DateTimeId} {item.Date.ToString("yyyy-MM-dd")} {item.Time}");
        }

        // string[] menuChoice = { "Seats", "Exit" };
        // int menuInt = mainMenu.PrintMenu(menuChoice);
        // switch (menuInt)
        // {
        //     case 0:
        //         List<Seat> available = db.AvailableSeats();
        //         int bookSeats = print.ChooseSeats(available);
        //         Console.WriteLine("Seat : " + bookSeats);
        //         break;
        //     case 1:
        //         Environment.Exit(0);
        //         break;
        //     default:
        //     break;
        // }
    }
}