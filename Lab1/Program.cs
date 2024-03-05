using System;

namespace Labs;

public static class Program
{
    public static void Main(string[] args)
    {
        DisplayPersonalData();
        while (true)
        {
            Console.WriteLine("Choose an option:");
            Console.WriteLine("1. Calculate Triangle Properties");
            Console.WriteLine("2. Calculate Expression");
            Console.WriteLine("3. Calculate Function Value");
            Console.WriteLine("4. Calculate Sum");
            Console.WriteLine("5. Exit");
            Console.Write("Option: ");

            var option = Convert.ToInt32(Console.ReadLine());

            switch (option)
            {
                case 1:
                    CalculateTriangleProperties();
                    break;
                case 2:
                    CalculateExpression();
                    break;
                case 3:
                    CalculateFunctionValue();
                    break;
                case 4:
                    CalculateSum();
                    break;
                case 5:
                    return;
                default:
                    Console.WriteLine("Invalid option. Please try again.");
                    break;
            }
        }
    }

    private static void DisplayPersonalData()
    {
        Console.WriteLine("Surname: Starosivets");
        Console.WriteLine("Name: Bohdan");
        Console.WriteLine("Age: 17");
        Console.WriteLine("Group: SE-12");
        Console.WriteLine("Course: 1");
        Console.WriteLine("E-mail: bohdan.starosivets@knu.ua");
    }

    private static void CalculateTriangleProperties()
    {
        var a = Utils.Input.ReadAndValidateInput("Enter side a: ", Convert.ToDouble);
        var b = Utils.Input.ReadAndValidateInput("Enter side b: ", Convert.ToDouble);
        var c = Utils.Input.ReadAndValidateInput("Enter side c: ", Convert.ToDouble);

        var medianA = 0.5 * Math.Sqrt(2*b*b + 2*c*c - a*a);
        var medianB = 0.5 * Math.Sqrt(2*a*a + 2*c*c - b*b);
        var medianC = 0.5 * Math.Sqrt(2*a*a + 2*b*b - c*c);

        var bisectorA = 2 * Math.Sqrt(b*c*(a*a + b*c)) / (b + c);
        var bisectorB = 2 * Math.Sqrt(a*c*(b*b + a*c)) / (a + c);
        var bisectorC = 2 * Math.Sqrt(a*b*(c*c + a*b)) / (a + b);

        Console.WriteLine($"Medians: {medianA}, {medianB}, {medianC}");
        Console.WriteLine($"Bisectors: {bisectorA}, {bisectorB}, {bisectorC}");
    }

    private static void CalculateExpression()
    {
        Console.Write("Enter a: ");
        var a = Convert.ToDouble(Console.ReadLine());
        Console.Write("Enter b: ");
        var b = Convert.ToDouble(Console.ReadLine());
        Console.Write("Enter n: ");
        var n = Convert.ToDouble(Console.ReadLine());

        var x = (Math.Pow(a, 2) - Math.Pow(b, 2)) / (a * b) + n * (a + b) / b;
        Console.WriteLine($"x = {x}");
    }

    private static void CalculateFunctionValue()
    {
        Console.Write("Enter x: ");
        var x = Convert.ToDouble(Console.ReadLine());

        var f = x switch
        {
            >= -5 and <= 1 => Math.Pow(x, 2),
            < -5 => 10 * x,
            > 5 => 5 * Math.Sqrt(x),
            _ => 1 / x
        };

        Console.WriteLine($"f(x) = {f}");
    }

    private static void CalculateSum()
    {
        Console.Write("Enter n: ");
        var n = Convert.ToInt32(Console.ReadLine());
        Console.Write("Enter x: ");
        var x = Convert.ToDouble(Console.ReadLine());

        double s = 0;
        for (var i = 1; i <= n; i++)
        {
            s += (i + 1) * Math.Pow(x + 1, i + 1);
        }

        Console.WriteLine($"S = {s}");
    }
}
