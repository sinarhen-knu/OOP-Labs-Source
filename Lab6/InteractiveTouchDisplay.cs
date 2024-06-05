namespace Lab6;

public class InteractiveTouchDisplay
{
    public void Display(string message)
    {
        Console.WriteLine(message);
    }

    public string GetInput()
    {
        return Console.ReadLine();
    }
}