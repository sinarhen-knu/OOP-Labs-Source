namespace Lab3;

public class Program
{
    public static void Main()
    {
        var faculty = new Faculty();
        faculty.InputData();
        faculty.DisplayData();
        faculty.WriteToFile("faculty.txt");
        faculty.UpdateDepartmentsAndStudents();
        faculty.DisplayData();

        var startupIncubator = new Faculty.StartupIncubator(10, 100, 10000);
        startupIncubator.SelectBestStartupProject();
        startupIncubator.CalculateStudentPerformanceRating();
    }
}