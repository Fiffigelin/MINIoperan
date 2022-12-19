using System.Globalization;
class Menu
{
    UI ui = new();

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
            ConsoleKey key = Console.ReadKey().Key;
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
}