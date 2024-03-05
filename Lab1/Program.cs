using Utils;

namespace Labs;

public static class Program
{
    public static void Main(string[] args)
    {
        DisplayPersonalData();
        var _continue = true;
        while (_continue)
        {
            Console.WriteLine("Choose an option:");
            Console.WriteLine("1. Calculate Rectangle Area");
            Console.WriteLine("2. Calculate Expression");
            Console.WriteLine("3. Display Color");
            Console.WriteLine("4. Calculate Average Score");
            Console.WriteLine("5. Exit");
            Console.Write("Option: ");

            var option = Convert.ToInt32(Console.ReadLine());

            switch (option)
            {
                case 1:
                    CalculateRectangleArea();
                    break;
                case 2:
                    CalculateExpression();
                    break;
                case 3:
                    DisplayColor();
                    break;
                case 4:
                    CalculateAverageScore();
                    break;
                case 5:
                    return;
                default:
                    Console.WriteLine("Invalid option. Please try again.");
                    break;
            }
            _continue = Input.ReadAndValidateInput("Do you want to continue? (yes/no): ", 
                s => s.Equals("yes", StringComparison.CurrentCultureIgnoreCase) 
                     || s.Equals("no", StringComparison.CurrentCultureIgnoreCase));
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
    private static void CalculateRectangleArea()
    {
        Console.WriteLine("Enter the length of the rectangle:");
        var length = Convert.ToDouble(Console.ReadLine());

        Console.WriteLine("Enter the width of the rectangle:");
        var width = Convert.ToDouble(Console.ReadLine());

        var area = length * width;

        Console.WriteLine($"The area of the rectangle is: {area}");
    }

    private static void CalculateExpression()
    {
        Console.WriteLine("Enter the value of a:");
        var a = Convert.ToDouble(Console.ReadLine());

        Console.WriteLine("Enter the value of b:");
        var b = Convert.ToDouble(Console.ReadLine());

        var result = (1 - a) * (a + b) / (a - b) + Math.Cbrt(Math.Pow(a, 2));

        Console.WriteLine($"The result of the expression is: {result}");
    }
    
    private static void DisplayColor()
    {
        Console.WriteLine("Enter the color number (1-7):");
        int colorNumber = Convert.ToInt32(Console.ReadLine());

        switch (colorNumber)
        {
            case 1:
                Console.WriteLine("Color: Red, RGB: (255, 0, 0)");
                break;
            case 2:
                Console.WriteLine("Color: Orange, RGB: (255, 165, 0)");
                break;
            case 3:
                Console.WriteLine("Color: Yellow, RGB: (255, 255, 0)");
                break;
            case 4:
                Console.WriteLine("Color: Green, RGB: (0, 128, 0)");
                break;
            case 5:
                Console.WriteLine("Color: Cyan, RGB: (0, 255, 255)");
                break;
            case 6:
                Console.WriteLine("Color: Blue, RGB: (0, 0, 255)");
                break;
            case 7:
                Console.WriteLine("Color: Violet, RGB: (238, 130, 238)");
                break;
            default:
                Console.WriteLine("Invalid color number.");
                break;
        }
    }

    private static void CalculateAverageScore()
    {
        Console.WriteLine("Enter the number of judges:");
        var numberOfJudges = Convert.ToInt32(Console.ReadLine());

        double sumOfScores = 0;
        var minScore = double.MaxValue;
        var maxScore = double.MinValue;

        for (var i = 1; i <= numberOfJudges; i++)
        {
            var score = Input.ReadAndValidateInput($"Enter the score given by judge {i}: ", double.Parse, s =>
            {
                if (s is >= 0 and <= 10) return true;
                Console.WriteLine("Invalid input. Please enter a valid value. (0-10)");
                return false;
            });

            sumOfScores += score;

            if (score < minScore)
            {
                minScore = score;
            }

            if (score > maxScore)
            {
                maxScore = score;
            }
        }

        var averageScore = (sumOfScores - minScore - maxScore) / (numberOfJudges - 2);

        Console.WriteLine($"The average score of the athlete is: {averageScore}");
    }
}
