using System;

class MatrixSorter
{
    static void Main()
    {
        // 1. Get matrix dimensions
        Console.Write("Enter number of rows: ");
        int rows = int.Parse(Console.ReadLine());

        Console.Write("Enter number of cols: ");
        int cols = int.Parse(Console.ReadLine());

        int[,] matrix = new int[rows, cols];

        // 2. Fill matrix with shuffled values
        FillMatrixWithShuffledValues(matrix, rows, cols);

        Console.WriteLine("\nOriginal (shuffled) matrix:");
        PrintMatrix(matrix, rows, cols);

        // 3. Sort rows based on first column
        SortMatrixByFirstColumn(matrix, rows, cols);

        Console.WriteLine("\nSorted matrix (by first column):");
        PrintMatrix(matrix, rows, cols);
    }

    static void FillMatrixWithShuffledValues(int[,] matrix, int rows, int cols)
    {
        int[] values = new int[rows * cols];
        for (int i = 0; i < values.Length; i++)
            values[i] = i;

        Shuffle(values);

        int index = 0;
        for (int i = 0; i < rows; i++)
            for (int j = 0; j < cols; j++)
                matrix[i, j] = values[index++];
    }

    static void Shuffle(int[] array)
    {
        Random rand = new Random();
        for (int i = array.Length - 1; i > 0; i--)
        {
            int j = rand.Next(i + 1);
            // Swap
            int temp = array[i];
            array[i] = array[j];
            array[j] = temp;
        }
    }

    static void SortMatrixByFirstColumn(int[,] matrix, int rows, int cols)
    {
        for (int i = 0; i < rows - 1; i++)
        {
            for (int j = i + 1; j < rows; j++)
            {
                if (matrix[i, 0] > matrix[j, 0])
                    SwapRows(matrix, i, j, cols);
            }
        }
    }

    static void SwapRows(int[,] matrix, int row1, int row2, int cols)
    {
        for (int i = 0; i < cols; i++)
        {
            int temp = matrix[row1, i];
            matrix[row1, i] = matrix[row2, i];
            matrix[row2, i] = temp;
        }
    }

    static void PrintMatrix(int[,] matrix, int rows, int cols)
    {
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
                Console.Write(matrix[i, j] + "\t");
            Console.WriteLine();
        }
    }
}
