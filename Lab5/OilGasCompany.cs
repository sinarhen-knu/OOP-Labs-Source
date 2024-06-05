namespace Lab5;

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
    
    public static OilGasCompany operator +(OilGasCompany a, OilGasCompany b)
    {
        return new OilGasCompany(a.Name, a.Location, a.ActivityField, a.SuccessRating, a.ProductionVolume + b.ProductionVolume);
    }

    public static OilGasCompany operator ++(OilGasCompany a)
    {
        a.ProductionVolume += 10000; 
        return a;
    }
}