using System;
using System.Threading;

class ListingActivity : Activity
{
    private string[] prompts = {
        "Who are people that you appreciate?",
        "What are personal strengths of yours?",
        "Who are people that you have helped this week?",
        "When have you felt the Holy Ghost this month?",
        "Who are some of your personal heroes?"
    };

    public ListingActivity() : base("Listing", "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.")
    {
    }

    protected override void ExecuteActivity(int duration)
    {
        string prompt = prompts[new Random().Next(prompts.Length)];
        Console.WriteLine($"\nPrompt: {prompt}");
        Countdown(3);
        Console.WriteLine("\nStart listing items:");
        int count = 0;
        DateTime startTime = DateTime.Now;
        while ((DateTime.Now - startTime).TotalSeconds < duration)
        {
            string item = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(item))
            {
                break;
            }
            count++;
        }
        Console.WriteLine($"\nYou listed {count} items.");
        Countdown(3);
    }
}