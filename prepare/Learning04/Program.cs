namespace Learning04{

    using System;

    class Program
    {
        static void Main()
        {
            // Testing the base Assignment class
            Assignment assignment = new Assignment("Samuel Bennett", "Multiplication");
            Console.WriteLine(assignment.GetSummary());

            // Testing the MathAssignment class
            MathAssignment mathAssignment = new MathAssignment("Roberto Rodriguez", "Fractions", "7.3", "8-19");
            Console.WriteLine(mathAssignment.GetSummary());
            Console.WriteLine(mathAssignment.GetHomeworkList());

            // Testing the WritingAssignment class
            WritingAssignment writingAssignment = new WritingAssignment("Mary Waters", "European History", "The Causes of World War II");
            Console.WriteLine(writingAssignment.GetSummary());
            Console.WriteLine(writingAssignment.GetWritingInformation());
        }
    }
}