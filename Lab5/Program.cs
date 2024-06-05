using Lab5;

var enterprises = new EnterpriseArray(3);
enterprises[0] = new InsuranceCompany("Insurance Company", "New York", "Insurance", 0.9, "Health", 1000000);
enterprises[1] = new OilGasCompany("Oil and Gas Company", "Texas", "Oil and Gas", 0.8, 1000000);
enterprises[2] = new Factory("Factory", "China", "Manufacturing", 0.7, "Electronics", 1000000);

for (int i = 0; i < 3; i++)
{
    enterprises[i].Display();
    Console.WriteLine($"Profit: {enterprises[i].CalculateProfit(0.1)}");
    Console.WriteLine($"Employee count: {enterprises[i].CalculateEmployeeCount(1000000, 5000)}");
    Console.WriteLine();
}