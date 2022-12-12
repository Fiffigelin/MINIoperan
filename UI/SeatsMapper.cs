class SeatsMapper
{
    private Menu menu = new();
    private List<Seat> seatList = new();
    int[,] seatMatrix;

    public void GetList(List<Seat> list)
    {
        seatList = list;
        ConvertToMatrix();
    }

    public (List<int>, bool) AvailableSeats(List<Seat> availableSeats)
    {
        bool quite = false;
        List<int> userSeat = new();
        int maxX = seatMatrix.GetLength(0);
        int maxY = seatMatrix.GetLength(1);
        int UserY = 0;
        int UserX = 0;

        Console.CursorVisible = false;

        while (true)
        {
            menu.Header();
            Console.WriteLine("CHOOSE SEATS WITH A, UNDO CHOOSEN SEAT WITH D. MAKE RESERVATION WITH ENTER. RETURN WITH Q.");
            // Console.WriteLine($"UserY = {UserY}, UserX = {UserX}"); // debugging
            PrintMatrix(availableSeats, userSeat, UserY, UserX);

            ConsoleKey key = Console.ReadKey().Key;
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
                    userSeat.Add(seatMatrix[UserY, UserX]);
                    break;
                case ConsoleKey.D:
                    userSeat.Remove(seatMatrix[UserY, UserX]);
                    break;
                case ConsoleKey.Enter:
                    quite = true;
                    return (userSeat, quite);
                case ConsoleKey.Q:
                    return (userSeat, quite);
                default:
                    break;
            }
            Console.Clear();
        }
    }
    // convert objects from list to elements in a dynamic array
    private void ConvertToMatrix()
    {
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
        seatMatrix = matrix;
    }

    private void PrintMatrix(List<Seat> availableSeats, List<int> userSeat, int UserY, int UserX)
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

                        if ((userSeat.Contains(seat.Id)))
                        {
                            IsSeatChoosen = true;
                            break;
                        }
                        break;
                    }
                }

                // prints out green for available and red for occupied
                if (IsSeatAvailable == true)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    IsSeatAvailable = false;

                    // print out blue when choosen for booking
                    if (IsSeatChoosen == true)
                    {
                        Console.ForegroundColor = ConsoleColor.Blue;
                        IsSeatChoosen = false;
                    }
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
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
}