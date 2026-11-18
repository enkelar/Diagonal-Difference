using System;

class Solution
{
    public static int diagonalDifference(int[,] arr)
    {
        int sumLeft = 0;
        int sumRight = 0;
        int length = arr.GetLength(0);

        for (int i = 0; i < length; i++)
        {
            sumLeft += arr[i, i];
            sumRight += arr[i, length - i - 1];
        }

        return Math.Abs(sumLeft - sumRight);
    }

    static string ReadLineOrExit()
    {
        string? line = Console.ReadLine();

        if (line == null)
        {
            Console.WriteLine("Input ended. Exiting.");
            Environment.Exit(1);
        }

        return line;
    }

    static int ReadSize()
    {
        while (true)
        {
            Console.WriteLine("Enter the size of the matrix:");

            if (int.TryParse(ReadLineOrExit(), out int n) && n >= 1 && n <= 100)
            {
                return n;
            }

            Console.WriteLine("Error: Matrix size must be between 1 and 100. Try again.");
        }
    }

    static int[] ReadRow(int rowNumber, int n)
    {
        while (true)
        {
            Console.WriteLine($"Enter row {rowNumber} elements separated by space:");

            string[] input = ReadLineOrExit().Split(' ', StringSplitOptions.RemoveEmptyEntries);

            if (input.Length != n)
            {
                Console.WriteLine($"Error: Row {rowNumber} must contain exactly {n} numbers. Try again.");
                continue;
            }

            int[] row = new int[n];
            bool isValid = true;

            for (int j = 0; j < n; j++)
            {
                if (!int.TryParse(input[j], out int rowsValue))
                {
                    Console.WriteLine("Error: Only whole numbers are allowed. Try again.");
                    isValid = false;
                    break;
                }

                if (rowsValue < -100 || rowsValue > 100)
                {
                    Console.WriteLine("Error: Numbers must be between -100 and 100. Try again.");
                    isValid = false;
                    break;
                }

                row[j] = rowsValue;
            }

            if (isValid)
            {
                return row;
            }
        }
    }

    static void Main(string[] args)
    {
        int n = ReadSize();

        int[,] matrix = new int[n, n];

        for (int i = 0; i < n; i++)
        {
            int[] row = ReadRow(i + 1, n);

            for (int j = 0; j < n; j++)
            {
                matrix[i, j] = row[j];
            }
        }

        Console.WriteLine("The matrix is:");
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                Console.Write(matrix[i, j].ToString().PadLeft(5));
            }
            Console.WriteLine();
        }

        int result = diagonalDifference(matrix);
        Console.WriteLine(result);
    }
}