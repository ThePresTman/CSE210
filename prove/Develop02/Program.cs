using System;
using System.Collections.Generic;
using System.IO;

class Journal
{
    private List<string> entries = new List<string>();
    private string[] prompts = 
    {
        "Who was the most interesting person I interacted with today?",
        "What was the best part of my day?",
        "How did I see the hand of the Lord in my life today?",
        "What was the strongest emotion I felt today?",
        "If I had one thing I could do over today, what would it be?"
    };

    public void AddEntry()
    {
        Random random = new Random();
        string prompt = prompts[random.Next(prompts.Length)];

        Console.WriteLine("\nPrompt: " + prompt);
        Console.Write("Your response: ");
        string response = Console.ReadLine();
        
        string entry = DateTime.Now.ToString("yyyy-MM-dd") + " | " + prompt + " | " + response;
        entries.Add(entry);
        Console.WriteLine("\n✔ Entry added!");
    }

    public void DisplayEntries()
    {
        if (entries.Count == 0)
        {
            Console.WriteLine("\n📭 No entries found.");
            return;
        }

        Console.WriteLine("\n📖 Journal Entries:\n");
        foreach (var entry in entries)
        {
            Console.WriteLine(entry);
        }
    }

    public void SaveToFile()
    {
        Console.Write("\nEnter filename to save: ");
        string filename = Console.ReadLine();
        File.WriteAllLines(filename, entries);
        Console.WriteLine("\n✔ Journal saved!");
    }

    public void LoadFromFile()
    {
        Console.Write("\nEnter filename to load: ");
        string filename = Console.ReadLine();

        if (File.Exists(filename))
        {
            entries = new List<string>(File.ReadAllLines(filename));
            Console.WriteLine("\n✔ Journal loaded!");
        }
        else
        {
            Console.WriteLine("\n⚠ File not found.");
        }
    }
}

class Program
{
    static void Main()
    {
        Journal journal = new Journal();
        while (true)
        {
            Console.WriteLine("\n JOURNAL APP");
            Console.WriteLine("1. Write a new entry");
            Console.WriteLine("2. Display the journal");
            Console.WriteLine("3. Save journal to file");
            Console.WriteLine("4. Load journal from file");
            Console.WriteLine("5. Exit");
            Console.Write("Choose an option: ");

            string choice = Console.ReadLine();
            if (choice == "1") journal.AddEntry();
            else if (choice == "2") journal.DisplayEntries();
            else if (choice == "3") journal.SaveToFile();
            else if (choice == "4") journal.LoadFromFile();
            else if (choice == "5") break;
            else Console.WriteLine("\n⚠ Invalid option. Try again.");
        }

        Console.WriteLine("\n Goodbye!");
    }
}
