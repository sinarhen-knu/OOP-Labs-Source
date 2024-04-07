using Utils;

namespace Lab3;

public class Faculty
{
    private string name;
    private int departmentsCount;
    private int specialtiesCount;
    private int overallStudentsCount;

    public Faculty()
    {
        this.name = "";
        this.departmentsCount = 0;
        this.specialtiesCount = 0;
        this.overallStudentsCount = 0;
    }

    public Faculty(string name, int departmentsCount, int specialtiesCount, int overallStudentsCount)
    {
        this.name = name;
        this.departmentsCount = departmentsCount;
        this.specialtiesCount = specialtiesCount;
        this.overallStudentsCount = overallStudentsCount;
    }

    public string Name
    {
        get => name;
        set => name = value;
    }

    public int DepartmentsCount
    {
        get => departmentsCount;
        set
        {
            departmentsCount = value;
            specialtiesCount = value; 
            overallStudentsCount = value * 200;
        }
    }

    public int SpecialtiesCount
    {
        get => specialtiesCount;
        set => specialtiesCount = value;
    }

    public int OverallStudentsCount
    {
        get => overallStudentsCount;
        set => overallStudentsCount = value;
    }

    public void InputData()
    {
        name = Input.ReadAndValidateInput<string>("Enter faculty name: ");
        departmentsCount = Input.ReadAndValidateInput<int>("Enter number of departments: ");
        specialtiesCount = Input.ReadAndValidateInput<int>("Enter number of specialties: ");
        overallStudentsCount = Input.ReadAndValidateInput<int>("Enter overall number of students: ");
    }

    public void DisplayData()
    {
        Console.WriteLine($"Faculty Name: {name}");
        Console.WriteLine($"Number of Departments: {departmentsCount}");
        Console.WriteLine($"Number of Specialties: {specialtiesCount}");
        Console.WriteLine($"Overall Number of Students: {overallStudentsCount}");
    }

    public void WriteToFile(string fileName)
    {
        using var writer = new StreamWriter(fileName);
        writer.WriteLine($"Faculty Name: {name}");
        writer.WriteLine($"Number of Departments: {departmentsCount}");
        writer.WriteLine($"Number of Specialties: {specialtiesCount}");
        writer.WriteLine($"Overall Number of Students: {overallStudentsCount}");
    }
    public class StartupIncubator
    {
        private int startupProjectsCount;
        private int studentsCount;
        private double investmentAmount;

        public StartupIncubator(int startupProjectsCount, int studentsCount, double investmentAmount)
        {
            this.startupProjectsCount = startupProjectsCount;
            this.studentsCount = studentsCount;
            this.investmentAmount = investmentAmount;
        }

        public int StartupProjectsCount
        {
            get => startupProjectsCount;
            set => startupProjectsCount = value;
        }

        public int StudentsCount
        {
            get => studentsCount;
            set => studentsCount = value;
        }

        public double InvestmentAmount
        {
            get => investmentAmount;
            set => investmentAmount = value;
        }

        public void SelectBestStartupProject()
        {
            int expertsCount = 5;
            int projectsCount = 10;
            
            int[,] scores = new int[expertsCount, projectsCount];
            Random random = new Random();

            // Fill the scores array with random scores from 1 to 10
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    scores[i, j] = random.Next(1, 11);
                }
            }

            double[] averages = new double[10];
            for (int j = 0; j < projectsCount; j++)
            {
                int sum = 0;
                for (int i = 0; i < expertsCount; i++)
                {
                    sum += scores[i, j];
                }
                averages[j] = (double)sum / expertsCount;
            }

            // Find the project with the lowest average score
            var minAverage = 0;
            var bestProject = 0;
            for (var j = 1; j < 10; j++)
            {
                if (averages[j] >= averages[minAverage]) continue;
                minAverage = j;
                bestProject = j;
            }

            Console.WriteLine($"The best startup project is project {bestProject + 1} with an average score of {averages[minAverage]}.");
        }

        public void CalculateStudentPerformanceRating()
        {
            // Initialize an array to store the performance rating of each student
            double[] performanceRatings = new double[studentsCount];
            Random random = new Random();

            // Calculate the performance rating for each student
            for (int i = 0; i < studentsCount; i++)
            {
                double participation = random.NextDouble();
                performanceRatings[i] = participation * investmentAmount;
            }

            // Find the student with the highest performance rating
            double maxPerformanceRating = performanceRatings[0];
            int bestStudent = 0;
            for (int i = 1; i < studentsCount; i++)
            {
                if (performanceRatings[i] > maxPerformanceRating)
                {
                    maxPerformanceRating = performanceRatings[i];
                    bestStudent = i;
                }
            }

            Console.WriteLine($"The most effective student is student {bestStudent + 1} with a performance rating of {maxPerformanceRating}.");
        }
    }
}