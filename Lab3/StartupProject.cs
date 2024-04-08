using Utils;

namespace Lab3;
using Lab2;

public static class StartupProject
{
    // 3 Functions from lab 2
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