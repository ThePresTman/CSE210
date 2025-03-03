using System;
using System.Collections.Generic;
using System.Threading;

abstract class MindfulnessActivity
{
    protected string Name;
    protected string Description;
    protected int Duration;

    public MindfulnessActivity(string name, string description)
    {
        Name = name;
        Description = description;
    }

    public void DisplayStartMessage()
    {
        Console.WriteLine($"\nStarting {Name}...");
        Console.WriteLine(Description);
        Console.Write("Enter the duration (in seconds): ");
        Duration = int.Parse(Console.ReadLine());
        Console.WriteLine("Prepare to begin...");
        PauseWithAnimation(3);
    }

    public void DisplayEndMessage()
    {
        Console.WriteLine("\nGreat job!");
        Console.WriteLine($"You have completed the {Name} activity for {Duration} seconds.");
        PauseWithAnimation(3);
    }

    protected void PauseWithAnimation(int seconds)
    {
        for (int i = seconds; i > 0; i--)
        {
            Console.Write($"{i}...\r");
            Thread.Sleep(1000);
        }
        Console.WriteLine("\n");
    }
    
    public abstract void Start();
}

class BreathingActivity : MindfulnessActivity
{
    public BreathingActivity() : base("Breathing Activity", "This activity will help you relax by guiding you through slow breathing. Focus on your breath.") { }

    public override void Start()
    {
        DisplayStartMessage();
        for (int i = 0; i < Duration / 4; i++)
        {
            Console.WriteLine("Breathe in...");
            PauseWithAnimation(2);
            Console.WriteLine("Breathe out...");
            PauseWithAnimation(2);
        }
        DisplayEndMessage();
    }
}

class ReflectionActivity : MindfulnessActivity
{
    private static readonly List<string> Prompts = new List<string>
    {
        "Think of a time when you stood up for someone else.",
        "Think of a time when you did something really difficult.",
        "Think of a time when you helped someone in need.",
        "Think of a time when you did something truly selfless."
    };
    
    private static readonly List<string> Questions = new List<string>
    {
        "Why was this experience meaningful to you?",
        "Have you ever done anything like this before?",
        "How did you get started?",
        "How did you feel when it was complete?"
    };

    public ReflectionActivity() : base("Reflection Activity", "This activity will help you reflect on times you showed strength and resilience.") { }

    public override void Start()
    {
        DisplayStartMessage();
        Console.WriteLine(Prompts[new Random().Next(Prompts.Count)]);
        PauseWithAnimation(5);
        for (int i = 0; i < Duration / 5; i++)
        {
            Console.WriteLine(Questions[new Random().Next(Questions.Count)]);
            PauseWithAnimation(5);
        }
        DisplayEndMessage();
    }
}

class ListingActivity : MindfulnessActivity
{
    private static readonly List<string> Prompts = new List<string>
    {
        "Who are people that you appreciate?",
        "What are personal strengths of yours?",
        "Who are people that you have helped this week?",
        "Who are some of your personal heroes?"
    };

    public ListingActivity() : base("Listing Activity", "This activity will help you reflect on the good things in your life.") { }

    public override void Start()
    {
        DisplayStartMessage();
        Console.WriteLine(Prompts[new Random().Next(Prompts.Count)]);
        PauseWithAnimation(5);
        int count = 0;
        DateTime startTime = DateTime.Now;
        while ((DateTime.Now - startTime).TotalSeconds < Duration)
        {
            Console.Write("List an item: ");
            Console.ReadLine();
            count++;
        }
        Console.WriteLine($"You listed {count} items!");
        DisplayEndMessage();
    }
}

class Program
{
    static void Main()
    {
        while (true)
        {
            Console.WriteLine("\nMindfulness Program");
            Console.WriteLine("1. Breathing Activity");
            Console.WriteLine("2. Reflection Activity");
            Console.WriteLine("3. Listing Activity");
            Console.WriteLine("4. Quit");
            Console.Write("Choose an activity: ");
            
            string choice = Console.ReadLine();
            
            switch (choice)
            {
                case "1":
                    new BreathingActivity().Start();
                    break;
                case "2":
                    new ReflectionActivity().Start();
                    break;
                case "3":
                    new ListingActivity().Start();
                    break;
                case "4":
                    Console.WriteLine("Goodbye!");
                    return;
                default:
                    Console.WriteLine("Invalid choice, try again.");
                    break;
            }
        }
    }
}
