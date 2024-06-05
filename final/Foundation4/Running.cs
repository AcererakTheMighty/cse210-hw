public class Running : Activity
{
    private double distance; // Distance in miles

    public Running(DateTime date, int length, double distance)
        : base(date, length)
    {
        this.distance = distance;
    }

    public override double GetDistance()
    {
        return distance;
    }

    public override double GetSpeed()
    {
        return (distance / Length) * 60;
    }

    public override double GetPace()
    {
        return Length / distance;
    }
}