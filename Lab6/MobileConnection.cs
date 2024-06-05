namespace Lab6;

public class MobileConnection
{
    public static void SendSMS(string number, string message)
    {
        Console.WriteLine($"Sending SMS to {number}: {message}");
    }
}