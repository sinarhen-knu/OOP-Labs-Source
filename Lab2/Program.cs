using Utils;

namespace Lab2;

public class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Hello world");
    }
    public static void GenerateAndSortArray()
    {
        Console.WriteLine("Enter the size of the array:");
        int size = Input.ReadAndValidateInput("Enter the size of array", Convert.ToInt32);

        Console.WriteLine("Enter the minimum value:");
        int minValue = Input.ReadAndValidateInput("Enter the size of array", Convert.ToInt32);

        Console.WriteLine("Enter the maximum value:");
        int maxValue = Input.ReadAndValidateInput("Enter the size of array", Convert.ToInt32);

        int[] array = new int[size];
        Random random = new Random();

        for (int i = 0; i < size; i++)
        {
            array[i] = random.Next(minValue, maxValue);
        }

        Console.WriteLine("Array before sorting:");
        foreach (var item in array)
        {
            Console.Write(item + " ");
        }

        ShellSort(array);

        Console.WriteLine("\nArray after sorting:");
        foreach (var item in array)
        {
            Console.Write(item + " ");
        }
    }
    
    public static void FindPrimesInArray(int[] array)
    {
        Console.WriteLine("Enter the minimum value for the prime range:");
        int minValue = Input.ReadAndValidateInput("Enter the minimum value for the prime range", Convert.ToInt32);

        Console.WriteLine("Enter the maximum value for the prime range:");
        int maxValue = Input.ReadAndValidateInput("Enter the maximum value for the prime range", Convert.ToInt32);

        List<int> primes = new List<int>();

        for (int i = 0; i < array.Length; i++)
        {
            if (array[i] >= minValue && array[i] <= maxValue && IsPrime(array[i]))
            {
                primes.Add(array[i]);
            }
        }

        if (primes.Count == 0)
        {
            Console.WriteLine("No prime numbers found in the array within the given range.");
        }
        else
        {
            Console.WriteLine("Prime numbers in the array within the given range:");
            foreach (var prime in primes)
            {
                Console.Write(prime + " ");
            }
        }
    }

    private static bool IsPrime(int number)
    {
        if (number <= 1) return false;
        if (number == 2) return true;
        if (number % 2 == 0) return false;

        var boundary = (int)Math.Floor(Math.Sqrt(number));

        for (int i = 3; i <= boundary; i += 2)
        {
            if (number % i == 0)
                return false;
        }

        return true;
    }

    public static void RearrangeArray(int[] array)
    {
        List<int> negativeNumbers = new List<int>();
        List<int> positiveNumbers = new List<int>();
        List<int> zeros = new List<int>();

        for (int i = 0; i < array.Length; i++)
        {
            if (array[i] < 0)
            {
                negativeNumbers.Add(array[i]);
            }
            else if (array[i] > 0)
            {
                positiveNumbers.Add(array[i]);
            }
            else
            {
                zeros.Add(array[i]);
            }
        }

        int index = 0, negativeIndex = 0, positiveIndex = 0, zeroIndex = 0;

        while (index < array.Length)
        {
            if (negativeIndex < negativeNumbers.Count)
            {
                array[index++] = negativeNumbers[negativeIndex++];
            }
            if (positiveIndex < positiveNumbers.Count)
            {
                array[index++] = positiveNumbers[positiveIndex++];
            }
            if (zeroIndex < zeros.Count)
            {
                array[index++] = zeros[zeroIndex++];
            }
        }

        Console.WriteLine("Array after rearranging:");
        foreach (var item in array)
        {
            Console.Write(item + " ");
        }
    }

    public static void FindMaxMinInArray(int[] array)
    {
        int maxNegative = int.MinValue;
        int minPositive = int.MaxValue;
        int maxNegativeIndex = -1;
        int minPositiveIndex = -1;

        for (int i = 0; i < array.Length; i++)
        {
            if (array[i] < 0 && array[i] > maxNegative)
            {
                maxNegative = array[i];
                maxNegativeIndex = i;
            }
            else if (array[i] > 0 && array[i] < minPositive)
            {
                minPositive = array[i];
                minPositiveIndex = i;
            }
        }

        Console.WriteLine($"Max negative number: {maxNegative} at index {maxNegativeIndex}");
        Console.WriteLine($"Min positive number: {minPositive} at index {minPositiveIndex}");
    }

    public static void FindElementsInRange(int[] array)
    {
        Console.WriteLine("Enter the minimum value for the range:");
        int minValue = Input.ReadAndValidateInput("Enter the minimum value for the range", Convert.ToInt32);

        Console.WriteLine("Enter the maximum value for the range:");
        int maxValue = Input.ReadAndValidateInput("Enter the maximum value for the range", Convert.ToInt32);

        List<int> elementsInRange = new List<int>();

        for (int i = 0; i < array.Length; i++)
        {
            if (array[i] >= minValue && array[i] <= maxValue)
            {
                elementsInRange.Add(array[i]);
            }
        }

        if (elementsInRange.Count == 0)
        {
            Console.WriteLine("No elements found in the array within the given range.");
        }
        else
        {
            Console.WriteLine("Elements in the array within the given range:");
            foreach (var element in elementsInRange)
            {
                Console.Write(element + " ");
            }
        }
    }

    public static void GenerateAndManipulateMatrix()
    {
        Console.WriteLine("Enter the number of rows in the matrix:");
        int rows = Input.ReadAndValidateInput("Enter the number of rows in the matrix", Convert.ToInt32);

        Console.WriteLine("Enter the number of columns in the matrix:");
        int columns = Input.ReadAndValidateInput("Enter the number of columns in the matrix", Convert.ToInt32);

        Console.WriteLine("Enter the minimum value for the matrix elements:");
        int minValue = Input.ReadAndValidateInput("Enter the minimum value for the matrix elements", Convert.ToInt32);

        Console.WriteLine("Enter the maximum value for the matrix elements:");
        int maxValue = Input.ReadAndValidateInput("Enter the maximum value for the matrix elements", Convert.ToInt32);

        int[,] matrix = new int[rows, columns];
        Random random = new Random();

        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < columns; j++)
            {
                matrix[i, j] = random.Next(minValue, maxValue);
            }
        }

        Console.WriteLine("Generated matrix:");
        PrintMatrix(matrix);

        // Further matrix manipulations go here...
    }

    private static void PrintMatrix(int[,] matrix)
    {
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                Console.Write(matrix[i, j] + " ");
            }
            Console.WriteLine();
        }
    }

    private static void ShellSort(int[] array)
    {
        int n = array.Length;
        int gap = n / 2;
        int temp;

        while (gap > 0)
        {
            for (int i = 0; i + gap < n; i++)
            {
                int j = i + gap;
                temp = array[j];

                while (j - gap >= 0 && temp < array[j - gap])
                {
                    array[j] = array[j - gap];
                    j = j - gap;
                }

                array[j] = temp;
            }

            gap = gap / 2;
        }
    }
    
    public static void FindMinAndModifyMatrix(int[,] matrix)
    {
        int min = int.MaxValue;
        int minRow = -1;
        int minCol = -1;

        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                if (matrix[i, j] < min)
                {
                    min = matrix[i, j];
                    minRow = i;
                    minCol = j;
                }
            }
        }

        Console.WriteLine($"Minimum element: {min} at row {minRow} and column {minCol}");

        int[,] newMatrix = new int[matrix.GetLength(0) - 1, matrix.GetLength(1) - 1];

        int p = 0;
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            if (i == minRow)
                continue;

            int q = 0;

            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                if (j == minCol)
                    continue;

                newMatrix[p, q] = matrix[i, j];
                q++;
            }

            p++;
        }

        Console.WriteLine("Matrix after removing row and column of minimum element:");
        PrintMatrix(newMatrix);
    }
    
    public static void FindCharactersInParentheses()
    {
        Console.WriteLine("Enter a string:");
        string input = Console.ReadLine();

        Stack<char> stack = new Stack<char>();
        string result = "";

        foreach (char c in input)
        {
            if (c == '(')
            {
                stack.Push(c);
            }
            else if (c == ')')
            {
                if (stack.Count > 0)
                {
                    stack.Pop();
                    result += " ";
                }
            }
            else if (stack.Count > 0)
            {
                result += c;
            }
        }

        Console.WriteLine($"Characters within parentheses: {result}");
    }
}