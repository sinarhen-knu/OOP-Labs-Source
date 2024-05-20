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