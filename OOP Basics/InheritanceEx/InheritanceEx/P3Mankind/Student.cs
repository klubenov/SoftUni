using System;
using System.Collections.Generic;
using System.Text;


class Student : Human
{
    private string facultyNumber;

    public string FacultyNumber
    {
        get { return this.facultyNumber; }
        set
        {
            if (value.Length<5 || value.Length>10)
            {
                throw new ArgumentException("Invalid faculty number!");
            }

            bool isNotDigitOrLetter = false;

            foreach (var character in value)
            {
                if (!char.IsLetterOrDigit(character))
                {
                    isNotDigitOrLetter = true;
                    break;
                }
            }

            if (isNotDigitOrLetter)
            {
                throw new ArgumentException("Invalid faculty number!");
            }

            this.facultyNumber = value;
        }
    }

    public Student(string firstName, string lastName, string facultyNumber):base(firstName,lastName)
    {
        this.FacultyNumber = facultyNumber;
    }

    public override string ToString()
    {
        return $"{base.ToString()}\r\nFaculty number: {FacultyNumber}";
    }
}

