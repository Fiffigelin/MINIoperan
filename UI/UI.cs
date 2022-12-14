class UI
{
    public Customer customer = new();

    public (Show, bool) PrintMenuObjectTitle(List<Show> showObjects)
    {
        Show show = new();
        bool quit = true;
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
        bool quit = true;
        int objectInt = showObjects.ElementAt(0).DateTimeId;
        int objectCount = objectInt + showObjects.Count - 1;
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
            Console.WriteLine("objectCount : " + objectCount);
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
    public (List<Seat>, bool) AvailableSeats(int[,] seatMatrix, List<Seat> availableSeats)
    {
        bool quit = true;
        Seat bookSeat = new();
        List<Seat> userSeat = new();
        int maxX = seatMatrix.GetLength(0);
        int maxY = seatMatrix.GetLength(1);
        int UserY = 0;
        int UserX = 0;

        Console.CursorVisible = false;

        while (true)
        {
            Header();
            Console.WriteLine("CHOOSE SEATS WITH A, UNDO CHOOSEN SEAT WITH D. MAKE RESERVATION WITH ENTER. RETURN WITH Q.");
            // Console.WriteLine($"UserY = {UserY}, UserX = {UserX}"); // debugging
            PrintMatrix(availableSeats, seatMatrix, userSeat, UserY, UserX);

            ConsoleKey key = Console.ReadKey(true).Key;
            switch (key)
            {
                case ConsoleKey.DownArrow:
                    UserY++;
                    if (UserY > maxY - 1)
                    {
                        UserY = 0;
                    }
                    break;
                case ConsoleKey.UpArrow:
                    UserY--;
                    if (UserY < 0)
                    {
                        UserY = maxY - 1;
                    }
                    break;
                case ConsoleKey.RightArrow:
                    UserX++;
                    if (UserX > maxX - 1)
                    {
                        UserX = 0;
                    }
                    break;
                case ConsoleKey.LeftArrow:
                    UserX--;
                    if (UserX < 0)
                    {
                        UserX = maxX - 1;
                    }
                    break;
                case ConsoleKey.A:
                    var addSeat = VerifySeat(availableSeats, userSeat, seatMatrix[UserY, UserX]);
                    if (addSeat.Item1 == true)
                    {
                        Console.WriteLine($"Booking seat : {addSeat.Item2.Id}");
                        Console.ReadLine();
                        userSeat.Add(addSeat.Item2);
                        break;
                    }
                    else
                    {
                        Console.WriteLine($"Unable to book seat : {addSeat.Item2.Id}");
                        Console.ReadLine();
                    }
                    break;
                case ConsoleKey.D:
                    var deleteSeat = DeleteSeat(userSeat, seatMatrix[UserY, UserX]);
                    if (deleteSeat.Item1 == true)
                    {
                        Console.WriteLine($"Deleted seat : {deleteSeat.Item2.Id}");
                        Console.ReadLine();
                        userSeat.Remove(deleteSeat.Item2);
                        break;
                    }
                    else
                    {
                        Console.WriteLine($"Nothing to delete");
                        Console.ReadLine();
                    }
                    break;
                case ConsoleKey.Enter:
                    quit = false;
                    return (userSeat, quit);
                case ConsoleKey.Q:
                    return (userSeat, quit);
                default:
                    break;
            }
            Console.Clear();
        }
    }
    public (bool, Seat) DeleteSeat(List<Seat> userSeat, int seatNumber)
    {
        Seat deleteSeat = new();
        foreach (var seat in userSeat)
        {
            if (seat.Id == seatNumber)
            {
                deleteSeat = seat;
                return (true, deleteSeat);
            }
        }
        return (false, deleteSeat);
    }

    public void PrintTickets(Reservation reservation, Customer customer, List<Seat> seatList, ShowToDates showDates)
    {
        foreach (var seat in seatList)
        {
            PrintLine();
            PrintRow("Name", customer.FirstName + " " + customer.LastName);
            PrintLine();
            PrintRow("Show", showDates.Title);
            PrintLine();
            PrintRow("Date", showDates.Date.ToString("yyyy-MM-dd"));
            PrintLine();
            PrintRow("Time", showDates.Time.ToString());
            PrintLine();
            PrintRow("Section", seat.Section);
            PrintRow("Row", seat.Row.ToString());
            PrintRow("Seat", seat.Id.ToString());
            PrintRow("Price", seat.Price.ToString());
            PrintLine();
            Console.Write($"\n\n");
        }
        Console.ReadLine();

    }

    private void PrintLine()
    {
        Console.WriteLine(new string('-', 75));
    }

    private void PrintRow(params string[] columns)
    {
        int width = (75 - columns.Length) / columns.Length;
        string row = "|";

        foreach (string column in columns)
        {
            row += AlignCentre(column, width) + "|";
        }

        Console.WriteLine(row);
    }

    private string AlignCentre(string text, int width = 75)
    {
        text = text.Length > width ? text.Substring(0, width - 3) + "..." : text;

        if (string.IsNullOrEmpty(text))
        {
            return new string(' ', width);
        }
        else
        {
            return text.PadRight(width - (width - text.Length) / 2).PadLeft(width);
        }
    }

    public string InputCustomerEmail()
    {
        string email = string.Empty;
        while (true)
        {
            Console.CursorVisible = false;
            Header();
            do
            {
                Console.Write("Please enter email : ");
                email = Console.ReadLine()!;
            } while (!email.Contains("@") || string.IsNullOrEmpty(email));

            return email;
        }
    }

    public int CustomerLogic(Customer customer)
    {
        while (true)
        {
            Console.CursorVisible = false;
            Header();
            Console.WriteLine($"Hi {customer.FirstName} {customer.LastName}, is this you?\nAnswer Y/N");
            ConsoleKey key = Console.ReadKey(false).Key;

            if (key == ConsoleKey.Y)
            {
                Header();
                Console.WriteLine($"Welcome back {customer.FirstName} {customer.LastName}");
                int customerId = customer.Id;
                Console.ReadLine();
                return customerId;
            }
            else if (key == ConsoleKey.N)
            {
                return 0;
            }
        }
    }

    public Customer CreateCustomer()
    {
        bool isPhone = false;
        while (true)
        {
            Header();
            do
            {
                Console.Write("Please enter your first name  : ");
                customer.FirstName = Console.ReadLine()!;
            } while (string.IsNullOrEmpty(customer.FirstName));
            do
            {
                Console.Write("Please enter your last name   : ");
                customer.LastName = Console.ReadLine()!;
            } while (string.IsNullOrEmpty(customer.LastName));
            do
            {
                Console.Write("Please enter email            : ");
                customer.Email = Console.ReadLine()!;
            } while (!customer.Email.Contains("@") || string.IsNullOrEmpty(customer.Email));
            return customer;
        }
    }

    public string AskForPhonenr()
    {
        string phonenr = string.Empty;
        do
        {
            Console.Write("Please enter your phonenumber : ");
            phonenr = Console.ReadLine()!;
        } while (string.IsNullOrEmpty(phonenr));
        return phonenr;
    }
    private void PrintMatrix(List<Seat> availableSeats, int[,] seatMatrix, List<Seat> userSeat, int UserY, int UserX)
    {
        bool IsSeatAvailable = false;
        bool IsSeatChoosen = false;
        int[,] matrix = seatMatrix;
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                foreach (var seat in availableSeats)
                {
                    if (matrix[i, j] == seat.Id)
                    {
                        IsSeatAvailable = true;
                        break;
                    }
                }

                foreach (var uSeat in userSeat)
                {
                    if (uSeat.Id == matrix[i, j])
                    {
                        IsSeatChoosen = true;
                        break;
                    }
                }

                // prints out green for available and red for occupied
                if (IsSeatAvailable == true)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    IsSeatAvailable = false;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                }

                // print out blue when choosen for booking
                if (IsSeatChoosen == true)
                {
                    Console.ForegroundColor = ConsoleColor.Blue;
                    IsSeatChoosen = false;
                }

                if (UserY == i && UserX == j)
                {
                    Console.BackgroundColor = ConsoleColor.DarkGray;
                }
                else
                {
                    Console.BackgroundColor = ConsoleColor.Black;
                }
                // Console makeup - arranges the seatsnumbers neatly
                Console.Write(matrix[i, j].ToString().PadRight(2) + " ".PadLeft(2));
            }
            Console.Write(Environment.NewLine);
        }
        Console.ResetColor();
    }

    private (bool, Seat) VerifySeat(List<Seat> availableSeats, List<Seat> userSeat, int seatNumber)
    {
        Seat insertSeat = new();
        foreach (var seat in userSeat)
        {
            if (seat.Id == seatNumber)
            {
                return (false, seat);
            }
        }
        foreach (var seat in availableSeats)
        {
            if (seat.Id == seatNumber)
            {
                insertSeat = seat;
                Console.WriteLine($"seat : {seat.Id} Seatnr : {seatNumber}");
                Console.ReadLine();
                return (true, insertSeat);
            }
        }
        return (false, insertSeat);
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