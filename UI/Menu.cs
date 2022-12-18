using System.Globalization;
using System.Collections;
class Menu
{
    UI ui = new();
    public (Show, bool) PrintMenuObjectTitle(List<Show> showObjects)
    {
        Show show = new();
        bool quit = true;
        int objectInt = showObjects.ElementAt(0).Id;
        while (true)
        {
            ui.Header();
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
                    quit = false;
                    foreach (var item in showObjects)
                    {
                        if (item.Id == objectInt) show = item;
                    }
                    return (show, quit);
                case ConsoleKey.Q:
                    return (show, quit);
                default:
                    break;
            }
            Console.Clear();
        }
    }

    public (int, bool) PrintMenuObjectDate(List<ShowToDates> showObjects)
    {
        CultureInfo eng = new("en-EN");
        bool quit = true;
        int objectInt = showObjects.ElementAt(0).DateTimeId;
        int objectCount = objectInt + showObjects.Count - 1;
        while (true)
        {
            ui.Header();
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
                    quit = false;
                    return (objectInt, quit);
                case ConsoleKey.Q:
                    return (0, quit);
                default:
                    break;
            }
            Console.Clear();
        }
    }
}