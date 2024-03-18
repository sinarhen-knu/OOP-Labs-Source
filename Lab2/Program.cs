using Utils;

namespace Lab2;

public class Program
{
    private const int MinValue = -10;
    private const int MaxValue = 10;
    private const double Epsilon = 0.0001;

    public static void Main(string[] args)
    {
        Console.WriteLine("Hello world");
        int[,]? matrix = null;
        var array = GenerateAndSortArray();


        while (true)
        {
            var option = GetOptionFromUser();
            switch (option)
            {
                case 1:
                    FindPrimesInArray(array);
                    break;
                case 2:
                    RearrangeArray(array);
                    break;
                case 3:
                    FindMaxMinInArray(array);
                    break;
                case 4:
                    FindElementsInRange(array);
                    break;
                case 5:
                    matrix = GenerateAndManipulateMatrix();
                    break;
                case 6:
                    if (matrix == null)
                    {
                        Console.WriteLine("Matrix is not initialized. use method 5.");
                        break;
                    }
                    FindMinAndModifyMatrix(matrix);
                    break;
                case 7:
                    FindCharactersInParentheses();
                    break;
                case 9:
                    SolveNonLinearEquation();
                    break;
                case 10:
                    return;
                default:
                    Console.WriteLine("Invalid option. Please try again.");
                    break;
            }
        }
    }
    
    private static int GetOptionFromUser()
    {
        Console.WriteLine("Choose an option:");
        Console.WriteLine("1. Generate and sort array");
        Console.WriteLine("2. Find primes in array");
        Console.WriteLine("3. Rearrange array");
        Console.WriteLine("4. Find max and min in array");
        Console.WriteLine("5. Find elements in range");
        Console.WriteLine("6. Generate and manipulate matrix");
        Console.WriteLine("7. Find min and modify matrix");
        Console.WriteLine("8. Find characters in parentheses");
        Console.WriteLine("9. Solve non-linear equation");
        Console.WriteLine("10. Exit");
        Console.Write("Option: ");

        return Convert.ToInt32(Console.ReadLine());
    }
    public static int[] GenerateAndSortArray()
    {
        int size = Input.ReadAndValidateInput("Enter the size of array", Convert.ToInt32);

        int minValue = Input.ReadAndValidateInput("Enter the minimum value of array: ", Convert.ToInt32);

        int maxValue = Input.ReadAndValidateInput("Enter the maximum value of array: ", Convert.ToInt32);

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

        return array;
    }
    
    public static void FindPrimesInArray(int[] array)
    {
        int minValue = Input.ReadAndValidateInput("Enter the minimum value for the prime range", Convert.ToInt32);

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

        if (maxNegativeIndex != -1)
        {
            Console.WriteLine($"Max negative number: {maxNegative} at index {maxNegativeIndex}");
        }
        else
        {
            Console.WriteLine("No negative numbers in the array.");
        }

        if (minPositiveIndex != -1)
        {
            Console.WriteLine($"Min positive number: {minPositive} at index {minPositiveIndex}");
        }
        else
        {
            Console.WriteLine("No positive numbers in the array.");
        }
    }

    public static void FindElementsInRange(int[] array)
    {
        int minValue = Input.ReadAndValidateInput("Enter the minimum value for the range", Convert.ToInt32);

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

    public static int[,]? GenerateAndManipulateMatrix()
    {
        int rows = Input.ReadAndValidateInput("Enter the number of rows in the matrix", Convert.ToInt32);

        int columns = Input.ReadAndValidateInput("Enter the number of columns in the matrix", Convert.ToInt32);

        int minValue = Input.ReadAndValidateInput("Enter the minimum value for the matrix elements", Convert.ToInt32);

        int maxValue = Input.ReadAndValidateInput("Enter the maximum value for the matrix elements", Convert.ToInt32);

        int[,]? matrix = new int[rows, columns];
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
        return matrix;
    }

    private static void PrintMatrix(int[,]? matrix)
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
    
    public static void FindMinAndModifyMatrix(int[,]? matrix)
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

        int[,]? newMatrix = new int[matrix.GetLength(0) - 1, matrix.GetLength(1) - 1];

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
    
    public static void SolveNonLinearEquation()
    {
        double a = -10;
        double b = 10;
        double epsilon = 0.0001;

        if (Function(a) * Function(b) >= 0)
        {
            Console.WriteLine("You have not assumed right a and b\n");
            return;
        }

        double c = a;

        while ((b - a) >= epsilon)
        {
            c = (a + b) / 2;

            if (Function(c) == 0.0)
                break;

            else if (Function(c) * Function(a) < 0)
                b = c;
            else
                a = c;
        }

        Console.WriteLine($"The value of root is : {c}");
    }

    private static double Function(double x)
    {
        return 5 * Math.Pow(x, 4) + 4 * Math.Pow(x, 3) - 6 * Math.Pow(x, 2) + 5;
    }
}