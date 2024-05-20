

public class Program
{
    public static void Main()
    {
        Enterprise[] enterprises = new Enterprise[3];
        enterprises[0] = new InsuranceCompany("Insurance Company", "New York", "Insurance", 0.8, "Health", 1000000);
        enterprises[1] = new OilGasCompany("Oil & Gas Company", "Texas", "Oil & Gas", 0.9, 1000000);
        enterprises[2] = new Factory("Factory", "California", "Production", 0.7, "Electronics", 1000000);

        foreach (Enterprise enterprise in enterprises)
        {
            Console.WriteLine($"Enterprise: {enterprise.Name}");
            Console.WriteLine($"Location: {enterprise.Location}");
            Console.WriteLine($"Activity Field: {enterprise.ActivityField}");
            Console.WriteLine($"Success Rating: {enterprise.SuccessRating}");
            Console.WriteLine($"Profit: {enterprise.CalculateProfit(0.1)}");
            Console.WriteLine($"Employee Count: {enterprise.CalculateEmployeeCount(1000000, 500)}");
            Console.WriteLine();
        }
    }
}