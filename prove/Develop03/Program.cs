using System;
using System.Collections.Generic;

class Word
{
    public string Text { get; private set; }
    public bool IsHidden { get; private set; }

    public Word(string text)
    {
        Text = text;
        IsHidden = false;
    }

    public void Hide()
    {
        IsHidden = true;
    }

    public override string ToString()
    {
        return IsHidden ? "____" : Text;
    }
}

class Reference
{
    public string ReferenceText { get; private set; }

    public Reference(string reference)
    {
        ReferenceText = reference;
    }

    public override string ToString()
    {
        return ReferenceText;
    }
}

class Scripture
{
    public Reference ScriptureReference { get; private set; }
    private List<Word> words;

    public Scripture(string reference, string text)
    {
        ScriptureReference = new Reference(reference);
        words = new List<Word>();
        foreach (var word in text.Split(' '))
        {
            words.Add(new Word(word));
        }
    }

    public void HideRandomWord()
    {
        var visibleWords = words.FindAll(word => !word.IsHidden);
        if (visibleWords.Count > 0)
        {
            var random = new Random();
            var wordToHide = visibleWords[random.Next(visibleWords.Count)];
            wordToHide.Hide();
        }
    }

    public string Display()
    {
        string displayText = ScriptureReference.ToString() + "\n";
        foreach (var word in words)
        {
            displayText += word.ToString() + " ";
        }
        return displayText.Trim();
    }
}

class Program
{
    static void Main(string[] args)
    {
        string reference = "John 3:16";
        string text = "For God so loved the world that he gave his one and only Son that whoever believes in him shall not perish but have eternal life.";

        Scripture scripture = new Scripture(reference, text);
        ProgramRunner runner = new ProgramRunner(scripture);
        runner.Run();
    }
}

class ProgramRunner
{
    private Scripture scripture;

    public ProgramRunner(Scripture scripture)
    {
        this.scripture = scripture;
    }

    public void Run()
    {
        while (true)
        {
            Console.Clear();  // Clear the console screen
            Console.WriteLine(scripture.Display());
            Console.WriteLine("\nPress Enter to hide a word, or type 'quit' to exit: ");
            string userInput = Console.ReadLine().Trim();

            if (userInput.ToLower() == "quit")
            {
                break;
            }
            else if (string.IsNullOrEmpty(userInput))
            {
                scripture.HideRandomWord();
            }
            else
            {
                Console.WriteLine("Invalid input. Please press Enter or type 'quit'.");
            }
        }
    }
}
