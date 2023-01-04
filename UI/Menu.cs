using System.Globalization;
class Menu
{
    // class responsibility is to write out the menu and return the result of users choice
    public (int, bool) PrintMenuArray(string[] array)
    {
        int markedLine = 0;
        while (true)
        {
            Header();
            Console.WriteLine("WELCOME TO MINI OPERAN! SELECT WITH ENTER AND QUITE WITH Q\n");
            for (int i = 0; i < array.Length; i++)
            {
                if (i == markedLine)
                {
                    Console.ForegroundColor = ConsoleColor.DarkBlue;
                }
                Console.WriteLine(array[i]);
                Console.ResetColor();
            }

            Console.CursorVisible = false;
            ConsoleKey key = Console.ReadKey(true).Key;
            switch (key)
            {
                case ConsoleKey.DownArrow:
                    markedLine++;
                    if (markedLine > array.Length - 1)
                    {
                        markedLine = 0;
                    }
                    break;
                case ConsoleKey.UpArrow:
                    markedLine--;
                    if (markedLine < 0)
                    {
                        markedLine = array.Length - 1;
                    }
                    break;
                case ConsoleKey.Enter:
                    return (markedLine, false);
                case ConsoleKey.Q:
                    return (-1, true);
                default:
                    break;
            }
        }
    }

    public (int, bool) PrintArray(string[] array)
    {
        int markedLine = 0;
        Console.WriteLine("WELCOME TO MINI OPERAN! SELECT WITH ENTER AND QUITE WITH Q\n");
        for (int i = 0; i < array.Length; i++)
        {
            if (i == markedLine)
            {
                Console.ForegroundColor = ConsoleColor.DarkBlue;
            }
            Console.WriteLine(array[i]);
            Console.ResetColor();
        }

        while (true)
        {
            Console.CursorVisible = false;
            ConsoleKey key = Console.ReadKey(true).Key;
            switch (key)
            {
                case ConsoleKey.Enter:
                    return (markedLine, false);
                case ConsoleKey.Q:
                    return (-1, true);
            }
        }
    }

    public (Show, bool) PrintMenuObjectTitle(List<Show> showObjects)
    {
        Show show = new();
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
            ConsoleKey key = Console.ReadKey(true).Key;
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
                    foreach (var item in showObjects)
                    {
                        if (item.Id == objectInt) show = item;
                    }
                    return (show, false);
                case ConsoleKey.Q:
                    return (show, true);
                default:
                    break;
            }
            Console.Clear();
        }
    }

    public (int, bool) PrintMenuObjectDate(List<ShowToDates> showObjects)
    {
        CultureInfo eng = new("en-EN");
        int objectInt = showObjects.ElementAt(0).DateTimeId;
        int objectCount = objectInt + showObjects.Count - 1;
        while (true)
        {
            Header();
            Console.WriteLine($@"
WELCOME TO MINI OPERAN! SELECT WITH ENTER AND RETURN WITH Q.

{showObjects.ElementAt(1).Title}");

            foreach (var item in showObjects)
            {
                DateTime day = item.Date;
                // https://learn.microsoft.com/en-us/dotnet/standard/base-types/how-to-extract-the-day-of-the-week-from-a-specific-date
                Console.Write(item.Date.ToString("ddd", eng));
                if (item.DateTimeId == objectInt)
                {
                    Console.ForegroundColor = ConsoleColor.DarkBlue;
                }
                Console.Write(" : " + item.Date.ToString("yyyy-MM-dd") + " " + item.Time + "\n");
                Console.ResetColor();
            }

            Console.CursorVisible = false;
            ConsoleKey key = Console.ReadKey(true).Key;
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
                    return (objectInt, false);
                case ConsoleKey.Q:
                    return (0, true);
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

    public void PrintLogo(int showId)
    {
        Console.Clear();
        switch (showId)
        {
            case 1:
                Console.WriteLine($@"
                                                               _,,
                                                            _''▀█████▄
                                                            _▄▄╥@░ _╙▓▓
                                                            ╟▀_▐███▄▄▓▒
                                                                ▀█▓▓▀╜");
                break;

            case 2:
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine($@"
     _ , ,_                     __      
     ╘░╔  m[               _. `▀░░[     
       _╖, ╓▒                ▒@¬`╦╜");
                Console.ResetColor();
                Console.Write($@"      
                _       _ _ _▄▀`        
          ▀ⁿ▄   ██ `'▀▀█▀▀  ██          
         █  _   █ █    █     _█         
        ]       ▌ ▄▌   █   _-▄▀         
        ╘      _▌  ▐▄                   
         █  _,      ▀                   
          `▀▀                     
        ");
                Console.ResetColor();
                break;

            case 3:
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine($@"      
                                    ▒▀▀▀▀▀▀▀▀▀▀▀▀▌█▀▀▀█   ▌▀▀▒▒▀▀▌
                                    ▀▌ ▀▌▐▐▌ ▀▐▐▐█▀ ▀▌ █  ▌ ▀▀▀░▒▌
                               ▐▌▀▀▀▀▀  ▐▌ ▌ ▀  ▄▀ ▒▒▒▄ ▌ ▌ █▌  ▀▀▀▀▌
                                ███▀███▀▌▒▒▀██▌▌█▀▀░▒▒███▒▀▀▀ ██████▌
                                ▀▄ █░  █▀ ▀ ▌ █ ▀▄  ▌ ▒▒▒ ▀▌ █  ▒▌▌▒▌
                                 ▀   █   █ █ ▀▌▌ ▀  ▌ ▒▀▀▄█▌▒▒█  █▄
                                  ▌▄█ █▄█▀█▒▒▀▀▀▌▄█ ▌▄█▀▌▄▄▄▄▄▄▄▄█▀");
                Console.ResetColor();
                break;

            case 4:
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine($@"
▐▌▀█ ▐▌ ▀▀▀ █ ▀ █▀ ▀ █▀▀█     ▐▌ █  ▐▌   █▄   ▐
▐▄ ▀ ▐▌▄▄   ▌   ▐▄▄  ▐▄ █     ▐▄ ▀ ▄▀▐▄  ▌▐█▄ ▐       ▄  ▀▄▐  ▐
▐▌   ▐▌     ▌   ▐    ▐  ▀▄    ▐▌   ▌  █▄ ▌  ▐█▄  ▐   ▌█   ▌▐   ▀▌
▀     ▀ ▀   ▀   ▀▀ ▀ ▀    ▀       ▀    ▀ ▀");
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.Write($@"
                   ▀█  ▄█  ▐▌ ▀█▀▀█  █▀▀▐▀██ ▀█▌   █    ▄▄
                    █▌▐▀▀█ █  ▐█▄█▀ ▐█     █▌▀▌▀█▌ █  ██▀ ▐▀█
                     ██  ██   ▐█ ▀█▌ ██   ▄█ ▒▌  ▀██ ██   ▄ ░
                     ▐    ▀   ▀▀▀  ▀▀ ░▀▀▀▐  ▀▀    ▀  █▌  ██░
                                                        ▀▀▀");
                Console.ResetColor();
                break;
        }
        Console.WriteLine(Environment.NewLine);
    }
}