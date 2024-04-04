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
        set => departmentsCount = value;
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
        Console.Write("Enter faculty name: ");
        name = Console.ReadLine();
        Console.Write("Enter number of departments: ");
        departmentsCount = int.Parse(Console.ReadLine());
        Console.Write("Enter number of specialties: ");
        specialtiesCount = int.Parse(Console.ReadLine());
        Console.Write("Enter overall number of students: ");
        overallStudentsCount = int.Parse(Console.ReadLine());
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
        using (StreamWriter writer = new StreamWriter(fileName))
        {
            writer.WriteLine($"Faculty Name: {name}");
            writer.WriteLine($"Number of Departments: {departmentsCount}");
            writer.WriteLine($"Number of Specialties: {specialtiesCount}");
            writer.WriteLine($"Overall Number of Students: {overallStudentsCount}");
        }
    }

    public void UpdateDepartmentsAndStudents()
    {
        departmentsCount = specialtiesCount;
        overallStudentsCount = specialtiesCount * 200;
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
            // Initialize a 2D array to store the scores of each project by each expert
            int[,] scores = new int[5, 10];
            Random random = new Random();

            // Fill the scores array with random scores from 1 to 10
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    scores[i, j] = random.Next(1, 11);
                }
            }

            // Calculate the average score for each project
            double[] averages = new double[10];
            for (int j = 0; j < 10; j++)
            {
                int sum = 0;
                for (int i = 0; i < 5; i++)
                {
                    sum += scores[i, j];
                }
                averages[j] = sum / 5.0;
            }

            // Find the project with the lowest average score
            double minAverage = averages[0];
            int bestProject = 0;
            for (int j = 1; j < 10; j++)
            {
                if (averages[j] < minAverage)
                {
                    minAverage = averages[j];
                    bestProject = j;
                }
            }

            Console.WriteLine($"The best startup project is project {bestProject + 1} with an average score of {minAverage}.");
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