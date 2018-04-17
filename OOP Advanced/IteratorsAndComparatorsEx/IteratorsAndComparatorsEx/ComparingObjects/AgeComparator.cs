using System;
using System.Collections.Generic;
using System.Text;


public class AgeComparator:IComparer<Person>
{
    public int Compare(Person first, Person second)
    {
        if (first.Age>second.Age)
        {
            return 1;
        }
        if (first.Age<second.Age)
        {
            return -1;
        }
        return 0;
    }
}

