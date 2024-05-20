namespace Lab4;


class Program
{
    static void Main(string[] args)
    {
        var insuranceCompany = new InsuranceCompany("Insurance Company", "New York", "Insurance", 0.9, "Health", 1000000);
        insuranceCompany.Display();
        Console.WriteLine($"Profit: {insuranceCompany.CalculateProfit(0.1)}");
        Console.WriteLine($"Employee count: {insuranceCompany.CalculateEmployeeCount(1000000, 5000)}");

        Console.WriteLine();

        var oilGasCompany = new OilGasCompany("Oil and Gas Company", "Texas", "Oil and Gas", 0.8, 1000000);
        oilGasCompany.Display();
        Console.WriteLine($"Profit: {oilGasCompany.CalculateProfit(0.1)}");
        Console.WriteLine($"Employee count: {oilGasCompany.CalculateEmployeeCount(1000000, 5000)}");

        Console.WriteLine();

        var factory = new Factory("Factory", "China", "Manufacturing", 0.7, "Electronics", 1000000);
        factory.Display();
        Console.WriteLine($"Profit: {factory.CalculateProfit(0.1)}");
        Console.WriteLine($"Employee count: {factory.CalculateEmployeeCount(1000000, 5000)}");
    }
}