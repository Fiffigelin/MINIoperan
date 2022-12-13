internal class Program
{
    private static void Main(string[] args)
    {
        ShowDB db = new();
        List<Show> show = new();
        show = db.SelectShows();
        
        UI showUI = new();
        showUI.ShowsMenu();

        //----------------------------------Skriver ut showerna med id-----------------------------------
        // TableUI table = new();
        // string[] stringarray = {"Id", "Title"};
        // table.PrintEmployees(show, stringarray);
        // Console.ReadKey();

        //-----------------------------------Skriver ut huvudmenyn---------------------------------------
        // Menu mainMenu = new();
        // string[] menuChoice = { "Shows", "Exit" };
        // int menuInt = mainMenu.PrintMenu(menuChoice);
        // switch (menuInt)
        // {
        //     case 0:
        //         ShowsUI showUI = new();
        //         showUI.ShowsMenu();
        //         break;
        //     case 1:
        //         Environment.Exit(0);
        //         break;
        //     default:
        //         break;
        // }

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
    }
}