namespace Lab5;

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
    
    public static Factory operator +(Factory a, Factory b)
    {
        return new Factory(a.Name, a.Location, a.ActivityField, a.SuccessRating, a.ProductType, a.ProductionVolume + b.ProductionVolume);
    }

    public static Factory operator ++(Factory a)
    {
        a.ProductionVolume += 10000; // Increase profits by 10000
        return a;
    }
    
}