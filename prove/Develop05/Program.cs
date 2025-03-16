using System;
using System.Collections.Generic;
using System.IO;

abstract class Goal
{
    public string Name { get; set; }
    public int Points { get; set; }
    public int Score { get; private set; }

    public Goal(string name, int points)
    {
        Name = name;
        Points = points;
    }

    public virtual void Complete()
    {
        Score += Points;
        Console.WriteLine($"Goal completed! You earned {Points} points.");
    }

    public abstract void Display();
}

class SimpleGoal : Goal
{
    private bool _isCompleted = false;

    public SimpleGoal(string name, int points) : base(name, points) {}

    public override void Complete()
    {
        if (!_isCompleted)
        {
            base.Complete();
            _isCompleted = true;
        }
        else
        {
            Console.WriteLine("Goal already completed.");
        }
    }

    public override void Display()
    {
        Console.WriteLine($"[ {( _isCompleted ? "X" : " ")} ] {Name}");
    }
}

class EternalGoal : Goal
{
    public EternalGoal(string name, int points) : base(name, points) {}

    public override void Complete()
    {
        base.Complete();
    }

    public override void Display()
    {
        Console.WriteLine($"[∞] {Name}");
    }
}

class ChecklistGoal : Goal
{
    private int _currentCount;
    private int _targetCount;
    private int _bonusPoints;

    public ChecklistGoal(string name, int points, int targetCount, int bonusPoints) 
        : base(name, points)
    {
        _targetCount = targetCount;
        _bonusPoints = bonusPoints;
    }

    public override void Complete()
    {
        _currentCount++;
        base.Complete();

        if (_currentCount == _targetCount)
        {
            Console.WriteLine($"Bonus achieved! You earned an extra {_bonusPoints} points.");
        }
    }

    public override void Display()
    {
        Console.WriteLine($"[{_currentCount}/{_targetCount}] {Name}");
    }
}

class Program
{
    static List<Goal> goals = new List<Goal>();

    static void Main()
    {
        while (true)
        {
            Console.WriteLine("\n1. Create Goal\n2. List Goals\n3. Complete Goal\n4. Exit");
            Console.Write("Choose an option: ");
            string choice = Console.ReadLine();

            if (choice == "1") CreateGoal();
            else if (choice == "2") ListGoals();
            else if (choice == "3") CompleteGoal();
            else if (choice == "4") break;
        }
    }

    static void CreateGoal()
    {
        Console.WriteLine("1. Simple Goal\n2. Eternal Goal\n3. Checklist Goal");
        Console.Write("Select type: ");
        string type = Console.ReadLine();

        Console.Write("Enter goal name: ");
        string name = Console.ReadLine();
        Console.Write("Enter points: ");
        int points = int.Parse(Console.ReadLine());

        if (type == "1") goals.Add(new SimpleGoal(name, points));
        else if (type == "2") goals.Add(new EternalGoal(name, points));
        else if (type == "3")
        {
            Console.Write("Enter target count: ");
            int target = int.Parse(Console.ReadLine());
            Console.Write("Enter bonus points: ");
            int bonus = int.Parse(Console.ReadLine());
            goals.Add(new ChecklistGoal(name, points, target, bonus));
        }
    }

    static void ListGoals()
    {
        for (int i = 0; i < goals.Count; i++)
        {
            Console.Write($"{i + 1}. ");
            goals[i].Display();
        }
    }

    static void CompleteGoal()
    {
        ListGoals();
        Console.Write("Enter goal number to complete: ");
        int index = int.Parse(Console.ReadLine()) - 1;
        if (index >= 0 && index < goals.Count)
            goals[index].Complete();
    }
}
