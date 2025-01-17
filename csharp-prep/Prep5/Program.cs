using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello Prep5 World!");

        {
        DisplayWelcomeMessage();

        string userName = PromptUserName();
        int userNumber = PromptUserNumber();

        int squaredNumber = SquareNumber(userNumber);

        DisplayResult(userName, squaredNumber);
    }

        // Making Functions
        static void DisplayWelcomeMessage()
        {
            Console.WriteLine("Welcome to the Program!");
        }

        static string PromptUserName()
        {
            Console.Write("Please enter your name:  ");
            string name = Console.ReadLine();

            return name;
        }

        static int PromptUserNumber()
        {
            Console.Write("Please enter your favorite number: ");
            int number = int.Parse(Console.ReadLine());

            return number;
        }

        static int SquareNumber(int number)
        {
            int squared = number * number;

            return squared;
        }

        static void DisplayResult(string name, int squared)
        {
            Console.WriteLine($"{name}, the square of your favorite number is {squared}");
        }
    }
}