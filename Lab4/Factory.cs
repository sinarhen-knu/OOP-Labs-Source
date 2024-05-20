namespace Lab4;

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
        => productionVolume * productValuePercentage;

    public override int CalculateEmployeeCount(double salaryFund, double averageSalary)
        => (int)(salaryFund / averageSalary);

    public override void Display()
    {
        base.Display();
        Console.WriteLine($"Product Type: {productType}");
        Console.WriteLine($"Production Volume: {productionVolume}");
    }
}