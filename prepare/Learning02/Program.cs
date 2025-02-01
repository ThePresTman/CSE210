using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello Learning02 World!");

        Job job1 = new Job();
        job1._jobTitle = "Engineer";
        job1._company = "Boeing";
        job1._startYear = 2015;
        job1._endYear = 2020;

        Job job2 = new Job();
        job2._jobTitle = "Manager";
        job2._company = "Intel";
        job2._startYear = 2020;
        job2._endYear = 2022;

        Resume myResume = new Resume();
        myResume._name = "John Smith";

        myResume._jobs.Add(job1);
        myResume._jobs.Add(job2);

        myResume.Display();
    }
}