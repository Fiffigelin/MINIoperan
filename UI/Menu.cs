class Menu
{
    private string[] menuLines {get; set;}
    private int markedLine = 0;
    private void PrintMainMenu()
    {
        Console.WriteLine($@"
        WELCOME TO GÖTEBORGS MINI-OPERAN\n
        Use 'up/down' arrows to navigate.
        Choose with 'enter'.\n");

        menuLines = {"\t- "}
    }
}