namespace Lab5;

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
    
    public static InsuranceCompany operator +(InsuranceCompany a, InsuranceCompany b)
    {
        return new InsuranceCompany(a.Name, a.Location, a.ActivityField, a.SuccessRating, a.InsuranceType, a.InsuranceCoverage + b.InsuranceCoverage);
    }

    public static InsuranceCompany operator ++(InsuranceCompany a)
    {
        a.InsuranceCoverage += 10000; // Increase profits by 10000
        return a;
    }
}