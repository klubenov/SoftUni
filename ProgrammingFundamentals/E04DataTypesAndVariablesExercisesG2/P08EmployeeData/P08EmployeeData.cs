using System;

namespace P08EmployeeData
{
    class P08EmployeeData
    {
        static void Main(string[] args)
        {
            string fName = "Amanda";
            string sName = "Jonson";
            byte age = 27;
            char gender = 'f';
            ulong persID = 8306112507;
            int emplID = 27563571;
            Console.WriteLine($"First name: {fName}\nLast name: {sName}\n" +
                              $"Age: {age}\nGender: {gender}\nPersonal ID: {persID}\n" +
                              $"Unique Employee number: {emplID}");
        }
    }
}
