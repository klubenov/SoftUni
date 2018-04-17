using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;


class TwoDateTuple
{
    public string FirstDate { get; set; }

    public string SecondDate { get; set; }

    public TwoDateTuple(string firstDate, string secondDate)
    {
        FirstDate = firstDate;
        SecondDate = secondDate;
    }

    public int CalculateDifferenceInDates()
    {
        var firstDateTime = DateTime.ParseExact(this.FirstDate, "yyyy MM dd", CultureInfo.InvariantCulture);
        var secondDateTime = DateTime.ParseExact(this.SecondDate, "yyyy MM dd", CultureInfo.InvariantCulture);
        return Math.Abs(firstDateTime.Subtract(secondDateTime).Days);
    }
}

