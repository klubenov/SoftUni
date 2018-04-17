using System;
using System.Collections.Generic;
using System.Text;


public class NameLengthComparator:IComparer<Person>
{
    public int Compare(Person first, Person second)
    {
        if (first.Name.Length > second.Name.Length)
        {
            return 1;
        }
        if (first.Name.Length < second.Name.Length)
        {
            return -1;
        }
        if (first.Name.Length == second.Name.Length)
        {
            string lowerCaseFirstPesonName = first.Name.ToLower();
            char lowerCaseFirstPesonLetter = lowerCaseFirstPesonName[0];
            string lowerCaseSecondPesonName = second.Name.ToLower();
            char lowerCaseSecondPersonLetter = lowerCaseSecondPesonName[0];
            if (lowerCaseFirstPesonLetter < lowerCaseSecondPersonLetter)
            {
                return -1;
            }
            if (lowerCaseFirstPesonLetter > lowerCaseSecondPersonLetter)
            {
                return 1;
            }
        }
        return 0;
    }
}

