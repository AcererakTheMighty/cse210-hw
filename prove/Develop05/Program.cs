using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

class Program
{
    private static List<Goal> goals = new List<Goal>();
    private static int totalScore = 0;

    static void Main()
    {
        LoadGoals();

        bool running = true;
        while (running)
        {
            Console.Clear();
            Console.WriteLine("Eternal Quest Program");
            Console.WriteLine("1. Create new goal");
            Console.WriteLine("2. Record event");
            Console.WriteLine("3. Show goals");
            Console.WriteLine("4. Show score");
            Console.WriteLine("5. Save and exit");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    CreateGoal();
                    break;
                case "2":
                    RecordEvent();
                    break;
                case "3":
                    ShowGoals();
                    break;
                case "4":
                    ShowScore();
                    break;
                case "5":
                    SaveGoals();
                    running = false;
                    break;
                default:
                    Console.WriteLine("Invalid choice. Try again.");
                    break;
            }
        }
    }

    static void CreateGoal()
    {
        Console.WriteLine("Choose goal type:");
        Console.WriteLine("1. Simple Goal");
        Console.WriteLine("2. Eternal Goal");
        Console.WriteLine("3. Checklist Goal");

        string choice = Console.ReadLine();
        Console.Write("Enter goal name: ");
        string name = Console.ReadLine();

        switch (choice)
        {
            case "1":
                Console.Write("Enter points for completing the goal: ");
                int simplePoints = int.Parse(Console.ReadLine());
                goals.Add(new SimpleGoal(name, simplePoints));
                break;
            case "2":
                Console.Write("Enter points for each completion: ");
                int eternalPoints = int.Parse(Console.ReadLine());
                goals.Add(new EternalGoal(name, eternalPoints));
                break;
            case "3":
                Console.Write("Enter points for each completion: ");
                int checklistPoints = int.Parse(Console.ReadLine());
                Console.Write("Enter number of times to complete the goal: ");
                int targetCount = int.Parse(Console.ReadLine());
                Console.Write("Enter bonus points upon completion: ");
                int bonus = int.Parse(Console.ReadLine());
                goals.Add(new ChecklistGoal(name, checklistPoints, targetCount, bonus));
                break;
            default:
                Console.WriteLine("Invalid choice. Returning to main menu.");
                break;
        }
    }

    static void RecordEvent()
    {
        ShowGoals();
        Console.Write("Enter the number of the goal to record an event: ");
        int goalIndex = int.Parse(Console.ReadLine()) - 1;

        if (goalIndex >= 0 && goalIndex < goals.Count)
        {
            int points = goals[goalIndex].RecordEvent();
            totalScore += points;
            Console.WriteLine($"Event recorded. You gained {points} points.");
        }
        else
        {
            Console.WriteLine("Invalid goal number.");
        }
        Console.WriteLine("Press any key to continue...");
        Console.ReadKey();
    }

    static void ShowGoals()
    {
        Console.WriteLine("Your Goals:");
        for (int i = 0; i < goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {goals[i].GetStatus()}");
        }
        Console.WriteLine("Press any key to continue...");
        Console.ReadKey();
    }

    static void ShowScore()
    {
        Console.WriteLine($"Your total score is: {totalScore}");
        Console.WriteLine("Press any key to continue...");
        Console.ReadKey();
    }

    static void SaveGoals()
    {
        string jsonString = JsonSerializer.Serialize(new { goals, totalScore }, new JsonSerializerOptions { WriteIndented = true });
        File.WriteAllText("goals.json", jsonString);
    }

    static void LoadGoals()
    {
        if (File.Exists("goals.json"))
        {
            string jsonString = File.ReadAllText("goals.json");
            var data = JsonSerializer.Deserialize<DataWrapper>(jsonString);
            goals = data.goals;
            totalScore = data.totalScore;
        }
    }
}

class DataWrapper
{
    public List<Goal> goals { get; set; }
    public int totalScore { get; set; }
}