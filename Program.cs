internal class Program
{
    private static void Main(string[] args)
    {
        SeatDB seat = new();
        List<Seat> seats = seat.GetAllSeats();
        foreach (var item in seats)
        {
            Console.WriteLine($"{item.Section} {item.Row} {item.Id} {item.Price}");
        }

    }
}