class Menu
{
    public int PrintMenu(string[] menuChoice)
    {
        int markedLine = 0;
        while (true)
        {
            Header();
            Console.WriteLine("WELCOME TO MINI OPERAN! SELECT WITH ENTER AND QUITE WITH Q\n");
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

    public (int, bool) PrintMenuObjectTitle(List<Show> showObjects)
    {
        bool quite = false;
        int objectInt = showObjects.ElementAt(0).Id;
        while (true)
        {
            Header();
            Console.WriteLine("WELCOME TO MINI OPERAN! SELECT WITH ENTER AND QUITE WITH Q\n");
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
                    quite = true;
                    return (objectInt, quite);
                case ConsoleKey.Q:
                    return (0, quite);
                default:
                    break;
            }
            Console.Clear();
        }
    }

    public (int, bool) PrintMenuObjectDate(List<ShowToDates> showObjects)
    {
        bool quite = false;
        int objectInt = showObjects.ElementAt(0).DateTimeId;
        int objectCount = objectInt + showObjects.Count -1;
        while (true)
        {
            Header();
            Console.WriteLine($@"
WELCOME TO MINI OPERAN! SELECT WITH ENTER AND RETURN WITH Q.

{showObjects.ElementAt(1).Title}");
Console.WriteLine("objectInt : " + objectInt);

            foreach (var item in showObjects)
            {
                if (item.DateTimeId == objectInt)
                {
                    Console.ForegroundColor = ConsoleColor.DarkBlue;
                }
                Console.WriteLine(item.Date.ToString("yyyy-MM-dd") + " " + item.Time);
                Console.ResetColor();
            }

            Console.WriteLine("objectInt : " + objectInt);
            Console.WriteLine("objectCount : " +objectCount);
            Console.CursorVisible = false;
            ConsoleKey key = Console.ReadKey().Key;
            switch (key)
            {
                case ConsoleKey.DownArrow:
                    objectInt++;
                    if (objectInt > objectCount)
                    {
                        objectInt = showObjects.ElementAt(0).DateTimeId;
                    }
                    break;
                case ConsoleKey.UpArrow:
                    objectInt--;
                    if (objectInt < showObjects.ElementAt(0).DateTimeId)
                    {
                        objectInt = objectCount;
                    }
                    break;
                case ConsoleKey.Enter:
                    quite = true;
                    return (objectInt, quite);
                case ConsoleKey.Q:
                    return (0, quite);
                default:
                    break;
            }
            Console.Clear();
        }
    }

    public void Header()
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