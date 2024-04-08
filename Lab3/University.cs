using System.Text.RegularExpressions;
using Microsoft.VisualBasic.CompilerServices;
using Utils;

namespace Lab3;


public enum City
{
    LosAngeles,
    Kyiv,
    SanFrancisco,
    NewYork,
    London,
    Paris,
    Tokyo,
    Sydney,
    Berlin,
    Madrid
}

public partial class University
{
    private static University[]? _universities;
    
    private string name;
    private City city;
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

        _universities ??= new University[10];
    }
    
    public City City
    {
        get => city;
        set => city = value;
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
    
    public bool ValidateName(string input)
    {
        // Regular expression pattern for letters, whitespaces, and hyphens
        const string pattern = @"^[a-zA-Z\s\-]+$";
        if (Regex.IsMatch(input, pattern))
        {
            return true;
        }
        else
        {
            Console.WriteLine("University name can only contain letters, whitespaces, and hyphens.");
            return false;
        }
    }
    public void InputData()
    {
        name = Input.ReadAndValidateInput<string>("Enter University name:", null, ValidateName);

        const string citiesChoice = "Available cities: LosAngeles, Kyiv, SanFrancisco, NewYork, London, Paris, Tokyo, Sydney, Berlin, Madrid"; 
        city = Input.ReadAndValidateInput<City>("Enter City" + citiesChoice, EnumHelper.Parse<City>, null);
        address = Input.ReadAndValidateInput<string>("Enter Address:", null, null);
        facultiesCount = Input.ReadAndValidateInput<int>("Enter number of faculties:", int.Parse, null);
        specialtiesCount = Input.ReadAndValidateInput<int>("Enter number of specialties:", int.Parse, null);
        overallStudentsCount = Input.ReadAndValidateInput<int>("Enter overall number of students:", int.Parse, null);
        rating = Input.ReadAndValidateInput<double>("Enter university rating:", double.Parse, null);
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
        using var writer = new StreamWriter(fileName);
        writer.WriteLine($"University Name: {name}");
        writer.WriteLine($"Address: {address}");
        writer.WriteLine($"Number of Faculties: {facultiesCount}");
        writer.WriteLine($"Number of Specialties: {specialtiesCount}");
        writer.WriteLine($"Overall Number of Students: {overallStudentsCount}");
        writer.WriteLine($"University Rating: {rating}");
    }

    public void CalculateRating()
    {
        Random random = new Random();
        int scopusScore = random.Next(0, 201);
        int top200UkraineScore = random.Next(0, 201);
        int contractZnoScore = random.Next(0, 201);

        int totalScore = scopusScore + top200UkraineScore + contractZnoScore;

        rating = totalScore;
    }

    }