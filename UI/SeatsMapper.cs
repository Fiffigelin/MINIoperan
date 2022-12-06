class SeatsMapper
{
    private List<Seat> seatList = new();
    int[,] seatMatrix;

    public void GetList(List<Seat> list)
    {
        seatList = list;
        ConvertToMatrix();
    }

    public int ChooseSeats(List<Seat> availableSeats)
    {
        int maxX = seatMatrix.GetLength(0);
        int maxY = seatMatrix.GetLength(1);
        int UserY = 0;
        int UserX = 0;

        Console.CursorVisible = false;

        while (true)
        {
            PrintMatrix(availableSeats);

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
                        UserX = maxX -1;
                    }
                    break;
                case ConsoleKey.Enter:
                    Console.CursorVisible = true;
                    return seatMatrix[UserY, UserX];
                default:
                break;
            }
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

    public void PrintMatrix(List<Seat> availableSeats)
    {
        bool IsSeatAvailable = false;
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
                // prints out green for available and red for occupied
                if (IsSeatAvailable == true)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write(matrix[i, j].ToString().PadRight(2) + " ".PadLeft(2));
                    Console.ForegroundColor = ConsoleColor.White;
                    IsSeatAvailable = false;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.Write(matrix[i, j].ToString().PadRight(2) + " ".PadLeft(2));
                }
            }
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write(Environment.NewLine);
        }
    }
}