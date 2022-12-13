internal class Program
{
    private static void Main(string[] args)
    {
        ShowDB db = new();
        List<Show> show = new();
        show = db.SelectShows();
        
        UI showUI = new();
        showUI.ShowsMenu();
    }
}