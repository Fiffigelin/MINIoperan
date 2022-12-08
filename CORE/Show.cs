class Show
{
    public int Id {get; set;}
    public string Title {get; set;}
    public string Type {get; set;}

    public Show(string title, string type)
    {
        Title = title;
        Type = type;
    }

    public Show(int id, string title, string type)
    {
        Id = id;
        Title = title;
        Type = type;
    }
}