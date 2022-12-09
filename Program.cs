internal class Program
{
    private static void Main(string[] args)
    {

        Menu mainMenu = new();

        //--------------------------HÄMTAR OCH SKRIVER UT SHOWERNA MED DATUM OCH TID----------------------
        // ShowDB showDB = new();
        // List<ShowToDates> showDates = new();
        // showDates = showDB.SelectShowDate();
        // foreach (var item in showDates)
        // {
        //     Console.WriteLine($@"{item.ShowId} {item.Title} {item.Type} {item.DateTimeId} {item.Date.ToString("yyyy-MM-dd")} {item.Time}");
        // }

        //--------------------------HÄMTAR LISTA MED LEDIGA/UPPTAGNA SITTPLATSER--------------------------
        // SeatDB db = new();
        // SeatsMapper print = new();
        // List<Seat> list = new();
        // print.GetList(list);
        // list = db.GetAllSeats();
        // List<Seat> available = db.AvailableSeats();
        // int bookSeats = print.ChooseSeats(available);
        // Console.WriteLine("Seat : " + bookSeats);

        string[] menuChoice = { "Shows", "Exit" };
        int menuInt = mainMenu.PrintMenu(menuChoice);
        switch (menuInt)
        {
            case 0:
                string[] shows = {"Phantom of the Opera", "Cats", "Starwars : the Empire strikes back", "Peter Pan går åt helvete"};
                Menu showMenu = new();
                int showInt = showMenu.PrintMenu(shows);
                switch(showInt)
                {
                    default:
                    case 0:
                    Environment.Exit(0);
                    break;
                }
                break;
            case 1:
                Environment.Exit(0);
                break;
            default:
                break;
        }
    }
}