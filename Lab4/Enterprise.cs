﻿namespace Lab4;

public class Enterprise
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
}