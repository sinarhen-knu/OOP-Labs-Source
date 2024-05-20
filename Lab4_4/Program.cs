namespace Lab4;


class Program
{
    static void Main(string[] args)
    {
        var enterprises = new Enterprise[]
        {
            new InsuranceCompany("Insurance Company", "New York", "Insurance", 0.9, "Health", 1000000),
            new OilGasCompany("Oil and Gas Company", "Texas", "Oil and Gas", 0.8, 1000000),
            new Factory("Factory", "China", "Manufacturing", 0.7, "Electronics", 1000000)
        };

        Array.Sort(enterprises);

        foreach (var enterprise in enterprises)
        {
            enterprise.Display();
            Console.WriteLine($"Profit: {enterprise.CalculateProfit(0.1)}");
            Console.WriteLine($"Employee count: {enterprise.CalculateEmployeeCount(1000000, 5000)}");
            Console.WriteLine();
        }
    }
}