

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


public interface IEnterprise
{
    string Name { get; set; }
    string Location { get; set; }
    string ActivityField { get; set; }
    double SuccessRating { get; set; }
    double CalculateProfit(double productValuePercentage);
    int CalculateEmployeeCount(double salaryFund, double averageSalary);
}

public class Enterprise : IEnterprise
{
    private string name;
    private string location;
    private string activityField;
    private double successRating;

    protected Enterprise(string name, string location, string activityField, double successRating)
    {
        this.name = name;
        this.location = location;
        this.activityField = activityField;
        this.successRating = successRating;
    }

    public string Name
    {
        get => name;
        set => name = value;
    }

    public string Location
    {
        get => location;
        set => location = value;
    }

    public string ActivityField
    {
        get => activityField;
        set => activityField = value;
    }

    public double SuccessRating
    {
        get => successRating;
        set => successRating = value;
    }

    public virtual double CalculateProfit(double productValuePercentage)
    {
        throw new NotImplementedException();
    }

    public virtual int CalculateEmployeeCount(double salaryFund, double averageSalary)
    {
        throw new NotImplementedException();
    }
}

public class InsuranceCompany : Enterprise
{
    private string insuranceType;
    private double insuranceCoverage;
    
    public InsuranceCompany(string name, string location, string activityField, double successRating, string insuranceType, double insuranceCoverage)
        : base(name, location, activityField, successRating)
    {
        this.insuranceType = insuranceType;
        this.insuranceCoverage = insuranceCoverage;
    }

    public string InsuranceType
    {
        get => insuranceType;
        set => insuranceType = value;
    }

    public double InsuranceCoverage
    {
        get => insuranceCoverage;
        set => insuranceCoverage = value;
    }
    public override double CalculateProfit(double productValuePercentage)
    {
        return insuranceCoverage * productValuePercentage;
    }

    public override int CalculateEmployeeCount(double salaryFund, double averageSalary)
    {
        return (int)(salaryFund / averageSalary);
    }

}

public class OilGasCompany : Enterprise
{
    private double productionVolume;

    public OilGasCompany(string name, string location, string activityField, double successRating, double productionVolume)
        : base(name, location, activityField, successRating)
    {
        this.productionVolume = productionVolume;
    }

    public double ProductionVolume
    {
        get => productionVolume;
        set => productionVolume = value;
    }
    public override int CalculateEmployeeCount(double salaryFund, double averageSalary)
    {
        return (int)(salaryFund / averageSalary);
    }
}

public class Factory : Enterprise
{
    private string productType;
    private double productionVolume;

    public Factory(string name, string location, string activityField, double successRating, string productType, double productionVolume)
        : base(name, location, activityField, successRating)
    {
        this.productType = productType;
        this.productionVolume = productionVolume;
    }

    public string ProductType
    {
        get => productType;
        set => productType = value;
    }

    public double ProductionVolume
    {
        get => productionVolume;
        set => productionVolume = value;
    }

    public override double CalculateProfit(double productValuePercentage)
    {
        return productionVolume * productValuePercentage;
    }

    public override int CalculateEmployeeCount(double salaryFund, double averageSalary)
    {
        return (int)(salaryFund / averageSalary);
    }
}