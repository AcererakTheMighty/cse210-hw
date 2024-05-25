using System;

[Serializable]
class ChecklistGoal : Goal
{
    public int TargetCount { get; set; }
    public int CurrentCount { get; set; }
    public int Bonus { get; set; }

    public ChecklistGoal(string name, int points, int targetCount, int bonus) : base(name, points)
    {
        TargetCount = targetCount;
        CurrentCount = 0;
        Bonus = bonus;
    }

    public override int RecordEvent()
    {
        if (CurrentCount < TargetCount)
        {
            CurrentCount++;
            if (CurrentCount == TargetCount)
            {
                IsCompleted = true;
                return Points + Bonus;
            }
            return Points;
        }
        return 0;
    }

    public override string GetStatus()
    {
        return IsCompleted ? $"[X] {Name} (Completed {CurrentCount}/{TargetCount} times)" : $"[ ] {Name} (Completed {CurrentCount}/{TargetCount} times)";
    }
}