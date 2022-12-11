class Seat
{
    public int Id {get; set;}
    public string Section {get; set;}
    public int Row {get; set;}
    public int Price {get; set;}

    public Seat (int id)
    {
        Id = id;
    }

    public Seat (int id, string section, int row, int price)
    {
        Id = id;
        Section = section;
        Row = row;
        Price = price;
    }
}