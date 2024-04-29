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
public abstract class Enterprise
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

    public abstract double CalculateProfit(double productValuePercentage);

    public abstract int CalculateEmployeeCount(double salaryFund, double averageSalary);

    public virtual void Display()
    {
        Console.WriteLine($"Name: {name}");
        Console.WriteLine($"Location: {location}");
        Console.WriteLine($"Activity Field: {activityField}");
        Console.WriteLine($"Success Rating: {successRating}");
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

    public override void Display()
    {
        base.Display();
        Console.WriteLine($"Insurance Type: {insuranceType}");
        Console.WriteLine($"Insurance Coverage: {insuranceCoverage}");
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

    public override double CalculateProfit(double productValuePercentage)
    {
        return productionVolume * productValuePercentage;
    }

    public override int CalculateEmployeeCount(double salaryFund, double averageSalary)
    {
        return (int)(salaryFund / averageSalary);
    }

    public override void Display()
    {
        base.Display();
        Console.WriteLine($"Production Volume: {productionVolume}");
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

    public override void Display()
    {
        base.Display();
        Console.WriteLine($"Product Type: {productType}");
        Console.WriteLine($"Production Volume: {productionVolume}");
    }
}