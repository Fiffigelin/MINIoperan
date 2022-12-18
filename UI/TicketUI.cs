class TicketUI
{
    public void PrintTickets(Reservation reservation, Customer customer, List<Seat> seatList, ShowToDates showDates)
    {
        foreach (var seat in seatList)
        {
            PrintLine();
            PrintRow("Name", customer.FirstName + " " + customer.LastName);
            PrintLine();
            PrintRow("Show", showDates.Title);
            PrintLine();
            PrintRow("Date", showDates.Date.ToString("yyyy-MM-dd"));
            PrintLine();
            PrintRow("Time", showDates.Time.ToString());
            PrintLine();
            PrintRow("Section", seat.Section);
            PrintRow("Row", seat.Row.ToString());
            PrintRow("Seat", seat.Id.ToString());
            PrintRow("Price", seat.Price.ToString());
            PrintLine();
            Console.Write($"\n\n");
        }
        Console.ReadLine();

    }

    private void PrintLine()
    {
        Console.WriteLine(new string('-', 75));
    }

    private void PrintRow(params string[] columns)
    {
        int width = (75 - columns.Length) / columns.Length;
        string row = "|";

        foreach (string column in columns)
        {
            row += AlignCentre(column, width) + "|";
        }

        Console.WriteLine(row);
    }

    private string AlignCentre(string text, int width = 75)
    {
        text = text.Length > width ? text.Substring(0, width - 3) + "..." : text;

        if (string.IsNullOrEmpty(text))
        {
            return new string(' ', width);
        }
        else
        {
            return text.PadRight(width - (width - text.Length) / 2).PadLeft(width);
        }
    }
}