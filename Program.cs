internal class Program
{
    private static void Main(string[] args)
    {
        SeatDB db = new();
        PrintSeats print = new();
        List <Seat> list = new();
        list = db.GetAllSeats();

        print.GetList(list);
        print.PrintMatrix();

        Console.ReadLine();
    }
}