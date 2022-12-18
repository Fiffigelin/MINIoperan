class SeatUI
{
    UI ui = new();
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
            ui.Header();
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

    // convert objects from list to elements in a dynamic array
    public int[,] ConvertToMatrix(List<Seat> seatList)
    {
        int[,] seatMatrix;
        int x = 0;
        int y = 0;

        foreach (var item in seatList)
        {
            if (item.Row == 1)
            {
                x++;
            }
            if (item.Row > y)
            {
                y++;
            }
        }
        int[,] matrix = new int[y, x];
        x = 0;
        y = 0;

        foreach (var item in seatList)
        {
            if (x >= matrix.GetLength(1)) x = 0;
            y = item.Row - 1;

            matrix[y, x] = item.Id;
            x++;
        }
        return seatMatrix = matrix;
    }
}