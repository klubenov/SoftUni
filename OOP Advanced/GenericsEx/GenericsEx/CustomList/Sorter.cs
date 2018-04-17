using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


public class Sorter
{
    public static CustomList<string> Sort(CustomList<string> customList)
    {
        var listToBeSorted = new List<string>();   
        foreach (var item in customList)
        {
            if (item!=null)
            {
                listToBeSorted.Add((string)item);
            }
        }
        var sortedList = new CustomList<string>(listToBeSorted.OrderBy(i => (string)i).ToArray());
        return sortedList;
    }
}

