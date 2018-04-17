using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P08AverageGrades
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
            string inputFilePath = "../../input.txt";
            string outputFilePath = "../../output.txt";
            File.WriteAllText(outputFilePath, String.Empty);
            List<string> inputLines = File.ReadAllLines(inputFilePath).ToList();
            inputLines.RemoveAt(0);
            List<Student> students = new List<Student>();
            for (int i = 0; i < inputLines.Count; i++)
            {
                string[] input = inputLines[i].Split(' ');
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
                if (student.Grades.Average() >= 5.00)
                {
                    File.AppendAllText(outputFilePath, $"{student.Name} -> {student.Grades.Average():f2}");
                    File.AppendAllText(outputFilePath, Environment.NewLine);
                }
            }
        }
    }
}
