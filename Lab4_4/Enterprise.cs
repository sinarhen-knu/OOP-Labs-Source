using System.Collections;

namespace Lab4;

public abstract class Enterprise : IComparable<Enterprise>, IComparer<Enterprise>, IEnumerable<Enterprise>
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

    public virtual void Display()
    {
        Console.WriteLine($"Name: {name}");
        Console.WriteLine($"Location: {location}");
        Console.WriteLine($"Activity Field: {activityField}");
        Console.WriteLine($"Success Rating: {successRating}");
    }
    public int Compare(Enterprise x, Enterprise y)
    {
        int comparison = x.SuccessRating.CompareTo(y.SuccessRating);
        if (comparison == 0)
        {
            comparison = x.CalculateEmployeeCount(10000, 5000).CompareTo(y.CalculateEmployeeCount(10000, 5000));
        }
        return comparison;
    }

    public IEnumerator<Enterprise> GetEnumerator()
    {
        yield return this;
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public int CompareTo(Enterprise? other)
    {
        return CalculateEmployeeCount(10000, 5000).CompareTo(other.CalculateEmployeeCount(10000, 5000));
    }
}