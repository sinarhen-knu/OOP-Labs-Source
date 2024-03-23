using Utils;

namespace Lab2;

class Program
{
    private static void DisplayPersonalData()
    {
        Console.WriteLine("Name: Starosivets Bohdan");
        Console.WriteLine("Group: SE-12");
        Console.WriteLine("Course: 1");
        Console.WriteLine("E-mail: bohdan.starosivets@knu.ua");
    }

    private static void MakeArrayOperations(int[] array)
    {
        while (true)
        {
            Console.WriteLine("Choose an option:");
            Console.WriteLine("1. Rearrange array");
            Console.WriteLine("2. Find max and min in array");
            Console.WriteLine("3. Find elements in range");
            Console.WriteLine("4. Exit");
            Console.Write("Option: ");

            var option = Convert.ToInt32(Console.ReadLine());

            switch (option)
            {
                case 1:
                    RearrangeArray(array);
                    break;
                case 2:
                    FindMaxMinInArray(array);
                    break;
                case 3:
                    FindElementsInRange(array);
                    break;
                case 4:
                    return;
                default:
                    Console.WriteLine("Invalid option. Please try again.");
                    break;
            }
        }
    }

    private static void MakeOtherOperations()
    {
        while (true)
        {
            
            Console.WriteLine("Choose an option:");
            Console.WriteLine("1. Find characters in parentheses");
            Console.WriteLine("2. Solve non-linear equation");
            Console.WriteLine("3. Find prime numbers in array ");
            Console.WriteLine("4. Exit");
            Console.Write("Option: ");

            var option = Convert.ToInt32(Console.ReadLine());

            switch (option)
            {
                case 1:
                    FindCharactersInParentheses();
                    break;
                case 2:
                    SolveNonLinearEquation();
                    break;
                case 3:
                    FindPrimesInArray();
                    break;
                case 4:
                    return;
                default:
                    Console.WriteLine("Invalid option. Please try again.");
                    break;
            }
        }
    }

    private static void MakeMatrixOperations(int[,] matrix)
    {
        while (true)
        {
            Console.WriteLine("Choose an option:");
            Console.WriteLine("1. Find min and modify matrix");
            Console.WriteLine("2. Analyze university ratings");
            Console.WriteLine("3. Exit");
            Console.Write("Option: ");

            var option = Input.ReadAndValidateInput("Enter the option: ", Convert.ToInt32);

            switch (option)
            {
                case 1:
                    FindMinAndModifyMatrix(matrix);
                    break;
                case 2:
                    AnalyzeUniversityRatings(matrix);
                    break;
                case 3:
                    return;
                default:
                    Console.WriteLine("Invalid option. Please try again.");
                    break;
            }
        }
    }

    public static void Main(string[] args)
    {
        DisplayPersonalData();
        while (true)
        {
            Console.WriteLine("Choose an option:");
            Console.WriteLine("1. Generate and sort array");
            Console.WriteLine("2. Generate and manipulate matrix");
            Console.WriteLine("3. Other operations");
            Console.WriteLine("4. Exit");
            Console.Write("Option: ");
            
            var option = Input.ReadAndValidateInput("Enter the option: ", Convert.ToInt32);
            switch (option)
            {
                case 1:
                    var array = GenerateAndSortArray();
                    MakeArrayOperations(array);
                    break;
                case 2:
                    var matrix = GenerateAndManipulateMatrix();
                    MakeMatrixOperations(matrix);
                    break;
                case 3:
                    MakeOtherOperations();
                    break;
                case 4:
                    return;
                default:
                    Console.WriteLine("Invalid option. Please try again.");
                    break;
            }
        }
    }
    
    private static int[] GenerateAndSortArray()
    {
        var size = Input.ReadAndValidateInput("Enter the size of array", Convert.ToInt32);

        var minValue = Input.ReadAndValidateInput("Enter the minimum value of array: ", Convert.ToInt32);

        var maxValue = Input.ReadAndValidateInput("Enter the maximum value of array: ", Convert.ToInt32);

        var array = new int[size];
        var random = new Random();

        for (var i = 0; i < size; i++) array[i] = random.Next(minValue, maxValue);

        Console.WriteLine("Array before sorting:");
        foreach (var item in array) Console.Write(item + " ");

        ShellSort(array);

        Console.WriteLine("\nArray after sorting:");
        foreach (var item in array) Console.Write(item + " ");

        return array;
    }

    private static void AnalyzeUniversityRatings(int[,] matrix)
    {
        var highestRatingUniversity = -1;
        var highestRating = int.MinValue;
        var lowestRatingUniversity = -1;
        var lowestRating = int.MaxValue;
        var highestRatingYear = -1;
        var highestYearRating = int.MinValue;

        for (var i = 0; i < matrix.GetLength(0); i++)
        {
            var totalRating = 0;
            for (var j = 0; j < matrix.GetLength(1); j++)
            {
                totalRating += matrix[i, j];
            }

            if (totalRating > highestRating)
            {
                highestRating = totalRating;
                highestRatingUniversity = i;
            }

            if (totalRating < lowestRating)
            {
                lowestRating = totalRating;
                lowestRatingUniversity = i;
            }
        }

        for (var j = 0; j < matrix.GetLength(1); j++)
        {
            var totalRating = 0;
            for (var i = 0; i < matrix.GetLength(0); i++)
            {
                totalRating += matrix[i, j];
            }

            if (totalRating > highestYearRating)
            {
                highestYearRating = totalRating;
                highestRatingYear = j;
            }
        }

        Console.WriteLine($"University with the highest rating over all years: {highestRatingUniversity + 1}");
        Console.WriteLine($"Year with the highest total rating: {highestRatingYear + 1}");
        Console.WriteLine($"University with the lowest total rating over all years: {lowestRatingUniversity + 1}");
    }
    private static void FindPrimesInArray()
    {
        var lowerBounds = Input.ReadAndValidateInput("Enter non-negative number: ", Convert.ToInt32, num =>
        {
            if (num >= 0)
                return true;
            Console.WriteLine("Please enter non negative number. " + num + " is negative");
            return false;
        });

        var upperBounds = Input.ReadAndValidateInput("Enter non-negative number more than: " + lowerBounds, Convert.ToInt32, num =>
        {
            switch (num)
            {
                case >= 0 when num > lowerBounds:
                    return true;
                case <= 0 when num > lowerBounds:
                    Console.WriteLine("Please enter non negative number. " + num + " is negative");
                    return false;
                default:
                    Console.WriteLine("Lower bounds of array is " + lowerBounds + ". Please enter value more than this");
                    return true;
            }
        });

        var array = new List<int>();
        for (var i = lowerBounds; i <= upperBounds; i++)
        {
            array.Add(i);
        }

        var primes = new bool[upperBounds + 1];
        
        for (int i = 0; i <= upperBounds; i++)
        {
            primes[i] = true;
        }

        for (int i = 2; i * i < array.Count; i++)
        {
            if (!primes[i]) continue;
            for (int j = i * 2; j < array.Count; j += i)
            {
                primes[j] = false;
            }
        }
            
        Console.WriteLine("Prime numbers in array: ");
        for (int i = 0; i < array.Count; i++)
        {
            if (primes[i])
            {
                Console.Write(i + " ");
            }
        }
    }

    private static void RearrangeArray(IList<int> array)
    {
        var negativeNumbers = new List<int>();
        var positiveNumbers = new List<int>();
        var zeros = new List<int>();

        for (var i = 0; i < array.Count; i++)
            if (array[i] < 0)
                negativeNumbers.Add(array[i]);
            else if (array[i] > 0)
                positiveNumbers.Add(array[i]);
            else
                zeros.Add(array[i]);

        int index = 0, negativeIndex = 0, positiveIndex = 0, zeroIndex = 0;

        while (index < array.Count)
        {
            if (negativeIndex < negativeNumbers.Count) array[index++] = negativeNumbers[negativeIndex++];
            if (positiveIndex < positiveNumbers.Count) array[index++] = positiveNumbers[positiveIndex++];
            if (zeroIndex < zeros.Count) array[index++] = zeros[zeroIndex++];
        }

        Console.WriteLine("Array after rearranging:");
        foreach (var item in array) Console.Write(item + " ");
    }

    private static void FindMaxMinInArray(IReadOnlyList<int> array)
    {
        var maxNegative = int.MinValue;
        var minPositive = int.MaxValue;
        var maxNegativeIndex = -1;
        var minPositiveIndex = -1;

        for (var i = 0; i < array.Count; i++)
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

        Console.WriteLine(maxNegativeIndex != -1
            ? $"Max negative number: {maxNegative} at index {maxNegativeIndex}"
            : "No negative numbers in the array.");

        Console.WriteLine(minPositiveIndex != -1
            ? $"Min positive number: {minPositive} at index {minPositiveIndex}"
            : "No positive numbers in the array.");
    }

    private static void FindElementsInRange(IEnumerable<int> array)
    {
        var minValue = Input.ReadAndValidateInput("Enter the minimum value for the range", Convert.ToInt32);

        var maxValue = Input.ReadAndValidateInput("Enter the maximum value for the range", Convert.ToInt32);

        var elementsInRange = array.Where(t => t >= minValue && t <= maxValue).ToList();

        if (elementsInRange.Count == 0)
        {
            Console.WriteLine("No elements found in the array within the given range.");
        }
        else
        {
            Console.WriteLine("Elements in the array within the given range:");
            foreach (var element in elementsInRange) Console.Write(element + " ");
        }
    }

    private static int[,] GenerateAndManipulateMatrix()
    {
        var rows = Input.ReadAndValidateInput("Enter the number of rows in the matrix", Convert.ToInt32);
        var columns = Input.ReadAndValidateInput("Enter the number of columns in the matrix", Convert.ToInt32);
        var minValue = Input.ReadAndValidateInput("Enter the minimum value for the matrix elements", Convert.ToInt32);
        var maxValue = Input.ReadAndValidateInput("Enter the maximum value for the matrix elements", Convert.ToInt32);

        var matrix = new int[rows, columns];
        var random = new Random();

        for (var i = 0; i < rows; i++)
        for (var j = 0; j < columns; j++)
            matrix[i, j] = random.Next(minValue, maxValue);

        Console.WriteLine("Generated matrix:");
        PrintMatrix(matrix);


        return matrix;
    }

    private static void PrintMatrix(int[,] matrix)
    {
        for (var i = 0; i < matrix.GetLength(0); i++)
        {
            for (var j = 0; j < matrix.GetLength(1); j++) Console.Write(matrix[i, j] + " ");
            Console.WriteLine();
        }
    }

    private static void ShellSort(IList<int> array)
    {
        var n = array.Count;
        var gap = n / 2;
        int temp;

        while (gap > 0)
        {
            for (var i = 0; i + gap < n; i++)
            {
                var j = i + gap;
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

    private static void FindMinAndModifyMatrix(int[,] matrix)
    {
        var min = int.MaxValue;
        var minRow = -1;
        var minCol = -1;

        for (var i = 0; i < matrix.GetLength(0); i++)
        for (var j = 0; j < matrix.GetLength(1); j++)
            if (matrix[i, j] < min)
            {
                min = matrix[i, j];
                minRow = i;
                minCol = j;
            }

        Console.WriteLine($"Minimum element: {min} at row {minRow} and column {minCol}");

        var newMatrix = new int[matrix.GetLength(0) - 1, matrix.GetLength(1) - 1];

        var p = 0;
        for (var i = 0; i < matrix.GetLength(0); i++)
        {
            if (i == minRow)
                continue;

            var q = 0;

            for (var j = 0; j < matrix.GetLength(1); j++)
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


    private static void FindCharactersInParentheses()
    {
        var input = Input.ReadAndValidateInput("Enter a string: ", s => s, s => s.Length > 0);

        var stack = new Stack<char>();
        var result = "";

        foreach (var c in input)
            switch (c)
            {
                case '(':
                    stack.Push(c);
                    break;
                case ')':
                {
                    if (stack.Count > 0)
                    {
                        stack.Pop();
                        result += " ";
                    }

                    break;
                }
                default:
                {
                    if (stack.Count > 0) result += c;

                    break;
                }
            }

        Console.WriteLine($"Characters within parentheses: {result}");
    }

    private static void SolveNonLinearEquation()
    {
        double a = -10;
        double b = 10;
        var epsilon = 0.0001;

        if (Function(a) * Function(b) >= 0)
        {
            Console.WriteLine("You have not assumed right a and b\n");
            return;
        }

        var c = a;

        while (b - a >= epsilon)
        {
            c = (a + b) / 2;

            if (Function(c) == 0.0)
                break;

            if (Function(c) * Function(a) < 0)
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