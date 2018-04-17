using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P01CountWorkingDays
{
    class P01CountWorkingDays
    {
        static void Main(string[] args)
        {
            DateTime startDate = DateTime.ParseExact(Console.ReadLine(), "dd-MM-yyyy", CultureInfo.InvariantCulture);
            DateTime endDate = DateTime.ParseExact(Console.ReadLine(), "dd-MM-yyyy", CultureInfo.InvariantCulture);
            Dictionary<int,List<int>> holidays= new Dictionary<int,List<int>>();
            holidays.Add(1,new List<int>() {1});
            holidays.Add(3, new List<int>(){3});
            holidays.Add(5, new List<int>(){1,6,24});
            holidays.Add(9,new List<int>(){6,22});
            holidays.Add(11,new List<int>(){1});
            holidays.Add(12, new List<int>(){24,25,26});
            int workdaysCount = 0;
            for (DateTime i = startDate; i <= endDate; i = i.AddDays(1))
            {
                if (i.DayOfWeek == DayOfWeek.Saturday || i.DayOfWeek == DayOfWeek.Sunday)
                {
                    continue;
                }
                if (holidays.ContainsKey(i.Month) && holidays[i.Month].Contains(i.Day))
                {
                    continue;
                }
                    workdaysCount++;
            }
            Console.WriteLine(workdaysCount);
        }
    }

}
