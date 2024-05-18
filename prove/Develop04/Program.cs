using System;

class Program
{
    static void Main(string[] args)
    {
        while (true)
        {
            Console.WriteLine("\nChoose an activity:");
            Console.WriteLine("1. Breathing Activity");
            Console.WriteLine("2. Reflection Activity");
            Console.WriteLine("3. Listing Activity");
            Console.WriteLine("4. Quit");
            Console.Write("Enter your choice: ");
            string choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                    StartActivity(new BreathingActivity());
                    break;
                case "2":
                    StartActivity(new ReflectionActivity());
                    break;
                case "3":
                    StartActivity(new ListingActivity());
                    break;
                case "4":
                    Console.WriteLine("Exiting program.");
                    return;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
        }
    }

    static void StartActivity(Activity activity)
    {
        Console.Write("Enter the duration (in seconds): ");
        int duration;
        while (!int.TryParse(Console.ReadLine(), out duration) || duration <= 0)
        {
            Console.WriteLine("Invalid input. Please enter a positive integer.");
            Console.Write("Enter the duration (in seconds): ");
        }
        activity.Start(duration);
    }
}