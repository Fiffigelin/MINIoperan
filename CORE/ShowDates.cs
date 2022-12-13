class ShowToDates
{
    public int ShowId {get; set;}
    public int DateTimeId {get; set;}
    public string Title {get; set;}
    public string Type {get; set;}
    public DateTime Date {get; set;}
    public TimeOnly Time {get; set;}

    public ShowToDates(int id, int dateId, string title, string type)
    {
        ShowId = id;
        DateTimeId = dateId;
        Title = title;
        Type = type;
    }

    public void DateTime(string date, string time)
    {
        Date = Convert.ToDateTime(date);
        Time = TimeOnly.Parse(time);
    }

    public ShowToDates(){}
}