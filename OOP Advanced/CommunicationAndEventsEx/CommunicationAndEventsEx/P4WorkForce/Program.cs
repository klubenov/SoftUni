using System;
using System.Collections.Generic;
using P4WorkForce.Contracts;
using P4WorkForce.Employees;

namespace P4WorkForce
{
    class Program
    {
        static void Main(string[] args)
        {
            var jobList = new JobList<Job>();

            var employeeList = new List<IEmployable>();

            string input;

            while ((input=Console.ReadLine())!="End")
            {
                var inputData = input.Split(' ');

                switch (inputData[0])
                {
                    case "Job":
                        var employee = employeeList.Find(e => e.Name == inputData[3]);
                        var newJob = new Job(inputData[1], int.Parse(inputData[2]), employee);
                        jobList.Add(newJob);
                        newJob.JobDone += jobList.OnJobUpdate;
                        break;
                    case "StandardEmployee":
                        employeeList.Add(new StandardEmployee(inputData[1]));
                        break;
                    case "PartTimeEmployee":
                        employeeList.Add(new PartTimeEmployee(inputData[1]));
                        break;
                    case "Pass":
                        var jobListCountBeforeUpdate = jobList.Count;

                        for (int i = 0; i < jobListCountBeforeUpdate; i++)
                        {
                            if (i==jobList.Count)
                            {
                                break;
                            }
                            bool isCompleted = jobList[i].Update(new EventArgs());
                            if (isCompleted)
                            {
                                i--;
                            }
                        }
                        break;
                    case "Status":
                        foreach (var job in jobList)
                        {
                            Console.WriteLine(job);
                        }
                        break;
                }
            }

            Environment.Exit(0);
        }
    }
}
