using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        // Create instances of each activity
        Activity running = new Running(new DateTime(2023, 11, 3), 30, 3.0);
        Activity cycling = new Cycling(new DateTime(2023, 11, 3), 45, 15.0);
        Activity swimming = new Swimming(new DateTime(2023, 11, 3), 30, 20);

        // Add activities to a list
        List<Activity> activities = new List<Activity> { running, cycling, swimming };

        // Iterate through the list and display the summary for each activity
        foreach (var activity in activities)
        {
            Console.WriteLine(activity.GetSummary());
            Console.WriteLine();
        }
    }
}