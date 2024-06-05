using Lab5;

public class University : Enterprise
{
    private string researchField;
    private double researchFunding;

    // Default constructor
    public University() : base("Default University", "Default Location", "Education", 0.5)
    {
        this.researchField = "Default Research Field";
        this.researchFunding = 0;
    }

    // Parameterized constructor
    public University(string name, string location, string activityField, double successRating, string researchField, double researchFunding)
        : base(name, location, activityField, successRating)
    {
        this.researchField = researchField;
        this.researchFunding = researchFunding;
    }

    // Constructor for input from the keyboard
    public University(University other) : base(other.Name, other.Location, other.ActivityField, other.SuccessRating)
    {
        this.researchField = other.researchField;
        this.researchFunding = other.researchFunding;
    }

    public string ResearchField
    {
        get => researchField;
        set => researchField = value;
    }

    public double ResearchFunding
    {
        get => researchFunding;
        set => researchFunding = value;
    }

    public override double CalculateProfit(double productValuePercentage)
    {
        return researchFunding * productValuePercentage;
    }

    public override int CalculateEmployeeCount(double salaryFund, double averageSalary)
    {
        return (int)(salaryFund / averageSalary);
    }

    public override void Display()
    {
        base.Display();
        Console.WriteLine($"Research Field: {researchField}");
        Console.WriteLine($"Research Funding: {researchFunding}");
    }
    
    public static University operator +(University a, University b)
    {
        return new University(a.Name, a.Location, a.ActivityField, a.SuccessRating, a.ResearchField, a.ResearchFunding + b.ResearchFunding);
    }

    public static University operator ++(University a)
    {
        a.ResearchFunding += 10000; 
        return a;
    }
}