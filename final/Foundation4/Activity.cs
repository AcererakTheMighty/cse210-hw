using System;

public abstract class Activity
{
    private DateTime date;
    private int length; // Length of the activity in minutes

    public Activity(DateTime date, int length)
    {
        this.date = date;
        this.length = length;
    }

    public DateTime Date => date;
    public int Length => length;

    public abstract double GetDistance(); // Distance in miles or kilometers
    public abstract double GetSpeed();    // Speed in mph or kph
    public abstract double GetPace();     // Pace in minutes per mile or km

    public virtual string GetSummary()
    {
        return $"{date.ToShortDateString()} {this.GetType().Name} ({length} min) - " +
               $"Distance: {GetDistance():0.0} miles, Speed: {GetSpeed():0.0} mph, Pace: {GetPace():0.0} min per mile";
    }
}