using System;
using System.Threading;

abstract class Activity
{
    protected string name;
    protected string description;

    public Activity(string name, string description)
    {
        this.name = name;
        this.description = description;
    }

    public void Start(int duration)
    {
        Console.WriteLine($"\nStarting {name} Activity:");
        Console.WriteLine(description);
        Console.WriteLine($"Activity Duration: {duration} seconds");
        Countdown(3);
        ExecuteActivity(duration);
        Finish();
    }

    protected void Countdown(int seconds)
    {
        for (int i = seconds; i > 0; i--)
        {
            Console.WriteLine($"Starting in {i}...");
            Thread.Sleep(1000);
        }
    }

    protected abstract void ExecuteActivity(int duration);

    protected void Finish()
    {
        Console.WriteLine("\nGreat job! You've completed the activity.");
        Console.WriteLine($"You've finished the {name} activity.");
    }
}
