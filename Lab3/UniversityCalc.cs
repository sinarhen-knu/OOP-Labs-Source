namespace Lab3;

public partial class University
{
    public double CalculateAnnualFunding()
    {
        // Switch case for Address
        double locationFactor = City switch
        {
            City.LosAngeles => 1.2,
            City.Kyiv => 1.1,
            City.SanFrancisco => 1.3,
            City.NewYork => 1.4,
            City.London => 1.5,
            City.Paris => 1.6,
            City.Tokyo => 1.7,
            City.Sydney => 1.8,
            City.Berlin => 1.9,
            City.Madrid => 2.0,
            _ => 1.0
        };

        // Switch case for overallStudentsCount
        var sizeFactor = overallStudentsCount switch
        {
            < 1000 => 0.8,
            < 5000 and >= 1000 => 1.0,
            >= 5000 => 1.2,
        };

        // Switch case for rating
        var ratingFactor = rating switch
        {
            < 100 => 0.5,
            < 200 and >= 100 => 0.7,
            < 300 and >= 200 => 1,
            < 400 and >= 300 => 1.2,
            < 500 and >= 400 => 1.5,
            < 600 and >= 500 => 2,
            _ => throw new ArgumentOutOfRangeException()
        };
        
        var fundingPerStudent = (rating / 100.0) * (2000 + 4000) + 2000;
        var annualFunding = fundingPerStudent * overallStudentsCount * sizeFactor * locationFactor * ratingFactor;

        return annualFunding;
    }
}