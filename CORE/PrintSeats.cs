class PrintSeats
{
    private List<Seat> seatList = new();
    int[,] seatMatrix;

    public void GetList(List<Seat> list)
    {
        seatList = list;
        ConvertToMatrix();
    }
    private void ConvertToMatrix()
    {
        int x = 0;
        int y = 0;

        foreach (var item in seatList)
        {
            if (item.Row == 1)
            {
                x++;
                Console.WriteLine("x = " + x);
            }
            if (item.Row > y)
            {
                y++;
                Console.WriteLine("y = " + y);
            }
        }
        int[,] matrix = new int[y, x];
        x = 0;
        y = 0;
        Console.WriteLine("X = " + matrix.GetLength(1));
        Console.WriteLine("Y = " + matrix.GetLength(0));
        foreach (var item in seatList)
        {
            if (x >= matrix.GetLength(1)) x = 0;
            y = item.Row - 1;
            Console.WriteLine(x + " " + y);

            matrix[y, x] = item.Id;
            x++;
        }
        seatMatrix = matrix;
    }

    public void PrintMatrix()
    {
        int[,] matrix = seatMatrix;
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                Console.Write(matrix[i, j] + " ");
            }
            Console.WriteLine();
        }
    }
}