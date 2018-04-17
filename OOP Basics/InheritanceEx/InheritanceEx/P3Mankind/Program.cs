using System;


public class Program
{
    static void Main(string[] args)
    {
        var studentData = Console.ReadLine().Split(' ');
        var studentFirstName = studentData[0];
        var studentLastName = studentData[1];
        var studentFacultyNumber = studentData[2];

        var workerData = Console.ReadLine().Split(' ');
        var workerFirstName = workerData[0];
        var workerLastName = workerData[1];
        var workerWeekSalary = decimal.Parse(workerData[2]);
        var workerWorkHoursPerDay = decimal.Parse(workerData[3]);

        try
        {
            var student = new Student(studentFirstName,studentLastName,studentFacultyNumber);
            var worker = new Worker(workerFirstName,workerLastName,workerWeekSalary,workerWorkHoursPerDay);
            Console.WriteLine(student);
            Console.WriteLine();
            Console.WriteLine(worker);
        }
        catch (Exception exception)
        {
            Console.WriteLine(exception.Message);
        }
    }
}

