using System;
using Lab6;

namespace Lab6;

// File: Program.cs
class Program
{
    static void Main(string[] args)
    {
        var smartDoor = new SmartDoor();
        smartDoor.OnDoorOpened += SmartDoor_OnDoorOpened;

        var people = new List<string> { "John Doe", "Jane Doe", "Alice", "Bob", "Charlie" };
        var random = new Random();

        foreach (var person in people)
        {
            Console.WriteLine($"\nPerson approaching: {person}");

            // Simulate the door recognizing the person or not based on a random condition
            if (random.Next(2) == 0)
            {
                Console.WriteLine($"{person} is recognized by the door.");
                smartDoor.OpenDoor();
            }
            else
            {
                Console.WriteLine($"{person} is not recognized by the door.");
                smartDoor.Alert();
            }
        }
    }

    static void SmartDoor_OnDoorOpened(object source, EventArgs args)
    {
        Console.WriteLine("The door was opened.");
    }
}