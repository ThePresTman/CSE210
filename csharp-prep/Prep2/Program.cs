using System;

class Program
{
    static void Main()
    {
        Console.Write("Enter your grade percentage: ");
        int grade = int.Parse(Console.ReadLine());

        string letter = "";

        if (grade >= 90)
        {
            letter = "A";
        }
        else if (grade >= 80)
        {
            letter = "B";
        }
        else if (grade >= 70)
        {
            letter = "C";
        }
        else if (grade >= 60)
        {
            letter = "D";
        }
        else
        {
            letter = "F";
        }

        Console.WriteLine("Your grade is: " + letter);

        if (grade >= 70)
        {
            Console.WriteLine("Congratulations, you passed the course!");
        }
        else
        {
            Console.WriteLine("Sorry, you didn't pass. Keep trying!");
        }
    }
}
