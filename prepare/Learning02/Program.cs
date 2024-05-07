using System;

class Program
{
    static void Main(string[] args)
    {
        // Creating Job 1
        Job job1 = new Job();
        job1._nmJobTitle = "Software Engineer";
        job1._nmCompany = "Microsoft";
        job1._nmStartYear = 2019;
        job1._nmEndYear = 2022;

        // Creating Job 2
        Job job2 = new Job();
        job2._nmJobTitle = "Manager";
        job2._nmCompany = "Apple";
        job2._nmStartYear = 2022;
        job2._nmEndYear = 2023;

        // Creating resume
        Resume nmMyResume = new Resume();
        nmMyResume._nmName = "Noah Merrell";
        nmMyResume._nmJobs.Add(job1);
        nmMyResume._nmJobs.Add(job2);

        // Displays resume
        nmMyResume.Display();
    }
}