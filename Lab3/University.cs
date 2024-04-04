namespace Lab3;

public partial class University
{
    private string name;
    private string address;
    private int facultiesCount;
    private int specialtiesCount;
    private int overallStudentsCount;
    private double rating;

    public University()
    {
        this.name = "";
        this.address = "";
        this.facultiesCount = 0;
        this.specialtiesCount = 0;
        this.overallStudentsCount = 0;
        this.rating = 0;
    }

    public University(string name, string address, int facultiesCount, int specialtiesCount, int overallStudentsCount, double rating)
    {
        this.name = name;
        this.address = address;
        this.facultiesCount = facultiesCount;
        this.specialtiesCount = specialtiesCount;
        this.overallStudentsCount = overallStudentsCount;
        this.rating = rating;
    }

    public string Name
    {
        get => name;
        set => name = value;
    }

    public string Address
    {
        get => address;
        set => address = value;
    }

    public int FacultiesCount
    {
        get => facultiesCount;
        set => facultiesCount = value;
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

    public double Rating
    {
        get => rating;
        set => rating = value;
    }

    public void InputData()
    {
        Console.Write("Enter university name: ");
        name = Console.ReadLine();
        Console.Write("Enter university address: ");
        address = Console.ReadLine();
        Console.Write("Enter number of faculties: ");
        facultiesCount = int.Parse(Console.ReadLine());
        Console.Write("Enter number of specialties: ");
        specialtiesCount = int.Parse(Console.ReadLine());
        Console.Write("Enter overall number of students: ");
        overallStudentsCount = int.Parse(Console.ReadLine());
        Console.Write("Enter university rating: ");
        rating = double.Parse(Console.ReadLine());
    }

    public void DisplayData()
    {
        Console.WriteLine($"University Name: {name}");
        Console.WriteLine($"Address: {address}");
        Console.WriteLine($"Number of Faculties: {facultiesCount}");
        Console.WriteLine($"Number of Specialties: {specialtiesCount}");
        Console.WriteLine($"Overall Number of Students: {overallStudentsCount}");
        Console.WriteLine($"University Rating: {rating}");
    }

    public void WriteToFile(string fileName)
    {
        using (StreamWriter writer = new StreamWriter(fileName))
        {
            writer.WriteLine($"University Name: {name}");
            writer.WriteLine($"Address: {address}");
            writer.WriteLine($"Number of Faculties: {facultiesCount}");
            writer.WriteLine($"Number of Specialties: {specialtiesCount}");
            writer.WriteLine($"Overall Number of Students: {overallStudentsCount}");
            writer.WriteLine($"University Rating: {rating}");
        }
    }
}