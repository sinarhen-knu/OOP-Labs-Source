public interface IEnterprise
{
    string Name { get; set; }
    string Location { get; set; }
    string ActivityField { get; set; }
    double SuccessRating { get; set; }
    double CalculateProfit(double productValuePercentage);
    int CalculateEmployeeCount(double salaryFund, double averageSalary);
}