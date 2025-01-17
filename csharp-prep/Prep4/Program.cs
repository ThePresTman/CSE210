using System;
using System.Globalization;
using System.Net;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello Prep4 World!");

        // Creating list for int
        List<int> numbers = new List<int>();

        int user_number = -1;
        // Getting numbers for list
        while (user_number != 0)
        {
            Console.Write("Enter a number you would like to store (enter 0 to end program): ");

            string userResponse = Console.ReadLine();
            user_number = int.Parse(userResponse);

            if (user_number != 0 )
            {
                numbers.Add(user_number);
            }
        }

        // Creating sum of the list
        int sum = 0;
        foreach (int number in numbers)
        {
            sum += number;
        }

        Console.WriteLine($"The sum is {sum}.");

        // Creating the average of numbers in the list
        float average = ((float)sum) / numbers.Count;
        Console.WriteLine($"The average of your lsit is {average}.");

        //Finding the largest number in the lsit
        int max = numbers[0];
        foreach (int number in numbers)
        {
            if (number > max)
            {
                max = number;
            }
        }

        Console.WriteLine($"The largest number in the list is {max}.");
    }
}