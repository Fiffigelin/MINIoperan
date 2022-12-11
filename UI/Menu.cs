class Menu
{
    public int PrintMenu(string[] menuChoice)
    {
        int markedLine = 0;
        while (true)
        {
            Header();
            for (int i = 0; i < menuChoice.Length; i++)
            {
                if (i == markedLine)
                {
                    Console.ForegroundColor = ConsoleColor.DarkBlue;
                }
                Console.WriteLine(menuChoice[i]);
                Console.ResetColor();
            }

            Console.CursorVisible = false;
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
            Console.Clear();
        }
    }

    public int PrintMenuObjectTitle(List<Show> showObjects)
    {
        int objectInt = 1;
        while (true)
        {
            Header();

            foreach (var item in showObjects)
            {
                if (item.Id == objectInt)
                {
                    Console.ForegroundColor = ConsoleColor.DarkBlue;
                }
                Console.WriteLine(item.Title);
                Console.ResetColor();
            }

            Console.CursorVisible = false;
            ConsoleKey key = Console.ReadKey().Key;
            switch (key)
            {
                case ConsoleKey.DownArrow:
                    objectInt++;
                    if (objectInt > showObjects.Count)
                    {
                        objectInt = 1;
                    }
                    break;
                case ConsoleKey.UpArrow:
                    objectInt--;
                    if (objectInt < 1)
                    {
                        objectInt = showObjects.Count;
                    }
                    break;
                case ConsoleKey.Enter:
                    return objectInt;
                case ConsoleKey.Q:
                    return -1;
                default:
                    break;
            }
            Console.Clear();
        }
    }

    public int PrintMenuObjectDate(List<ShowToDates> showObjects)
    {
        int objectInt = 1;
        while (true)
        {
            Header();
            Console.WriteLine(showObjects.ElementAt(1).Title + "\n");
            foreach (var item in showObjects)
            {
                if (item.DateTimeId == objectInt)
                {
                    Console.ForegroundColor = ConsoleColor.DarkBlue;
                }
                Console.WriteLine(item.Date.ToString("yyyy-MM-dd") + " " + item.Time);
                Console.ResetColor();
            }

            Console.CursorVisible = false;
            ConsoleKey key = Console.ReadKey().Key;
            switch (key)
            {
                case ConsoleKey.DownArrow:
                    objectInt++;
                    if (objectInt > showObjects.Count)
                    {
                        objectInt = 1;
                    }
                    break;
                case ConsoleKey.UpArrow:
                    objectInt--;
                    if (objectInt < 1)
                    {
                        objectInt = showObjects.Count;
                    }
                    break;
                case ConsoleKey.Enter:
                    return objectInt;
                case ConsoleKey.Q:
                    return -1;
                default:
                    break;
            }
            Console.Clear();
        }
    }

    private void Header()
    {
        Console.Clear();
        Console.WriteLine(@$"
                              ▄█▀      ▀█▄
                          ▄▀▀▓▀▄         ██▄  
                         ▓  ▄▀  █        ██▓█
                          ▀▄▓▓▄▀         ▓██▓▌
                           █▓██▌         ▓▓▓█▌
                            █▓█▌         ▐▓██        
            █▀▄▀█ █ █▄ █ █   ▀▓█         ▐▓▀
            █ ▀ █ █ █ ▀█ █     ▀█▄     ▄█▀
    ");
    }
}