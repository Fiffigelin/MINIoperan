class TableUI
{
    private int TableWidth;
    public void PrintEmployees(List<Show> show, params string[] columns)
    {
        TableWidth = 75;
        PrintLine();
        PrintRow(columns);
        PrintLine();
        foreach (var item in show)
        {
            PrintRow(item.Id.ToString(), item.Title);
        }
        PrintLine();
    }

    private void PrintLine()
    {
        Console.WriteLine(new string('-', TableWidth));
    }

    private void PrintRow(params string[] columns)
    {
        int width = (TableWidth - columns.Length) / columns.Length;
        string row = "|";

        foreach (string column in columns)
        {
            row += AlignCentre(column, width) + "|";
        }

        Console.WriteLine(row);
    }

    private string AlignCentre(string text, int width)
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