class ShowDates
{
    public int Id {get; set;}
    public string Title {get; set;}
    public string Type {get; set;}
    public DateTime Date {get; set;}
    public TimeOnly Time {get; set;}

    public ShowDates(int id, string title, string type)
    {
        Id = id;
        Title = title;
        Type = type;
    }

    public void DateTime(string date, string time)
    {
        Date = Convert.ToDateTime(date);
        Time = TimeOnly.Parse(time);
    }
}