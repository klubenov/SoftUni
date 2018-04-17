using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P04AverageGrades
{
    public class Student
    {
        public string Name { get; set; }
        public List<double> Grades { get; set; }
    }

    class P04AverageGrades
    {
        static void Main(string[] args)
        {
            int studentsAmount = int.Parse(Console.ReadLine());
            List<Student> students = new List<Student>();
            for (int i = 0; i < studentsAmount; i++)
            {
                string[] input = Console.ReadLine().Split(' ');
                Student currentStudent = new Student();
                currentStudent.Grades = new List<double>();
                currentStudent.Name = input[0];
                for (int j = 1; j < input.Length; j++)
                {
                    currentStudent.Grades.Add(double.Parse(input[j]));
                }
                students.Add(currentStudent);
            }
            foreach (var student in students.OrderBy(x => x.Name).ThenByDescending(x => x.Grades.Average()))
            {
                if (student.Grades.Average()>=5.00)
                {
                    Console.WriteLine($"{student.Name} -> {student.Grades.Average():f2}");
                }
            }
        }
    }
}
