class Menu
{
    private int markedLine = 0;

    private int PrintMainMenu(string[] menuChoice)
    {
        while (true)
        {
            for (int i = 0; i < menuChoice.Length; i++)
            {
                if (i == markedLine)
                {
                    Console.ForegroundColor = ConsoleColor.DarkBlue;
                }
                Console.WriteLine(menuChoice[i]);
                Console.ResetColor();
            }

            ConsoleKey key = Console.ReadKey().Key;
            switch (key)
            {
                case ConsoleKey.DownArrow:
                    markedLine++;
                    if (markedLine > menuChoice.Length - 1)
                    {
                        markedLine = 0;
                    }
                    break;
                case ConsoleKey.UpArrow:
                    markedLine--;
                    if (markedLine < 0)
                    {
                        markedLine = menuChoice.Length - 1;
                    }
                    break;
                case ConsoleKey.Enter:
                    return markedLine;
                default:
                break;
            }
        }
    }
}