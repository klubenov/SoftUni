using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


public class Smartphone : IBrowsable, ICallable
{
    public string[] PhoneNumbersArray { get; private set; }

    public string[] SitesArray { get; private set; }

    public string CallNumber(string number)
    {

        if (number.Any(c => !char.IsDigit(c)))
        {
            return "Invalid number!";
        }

        return $"Calling... {number}";
    }

    public string BrowseSite(string site)
    {
        if (site.Any(c => char.IsDigit(c)))
        {
            return "Invalid URL!";
        }

        return $"Browsing: {site}!";
    }

    public Smartphone(string[] phoneNumbersArray, string[] sitesArray)
    {
        PhoneNumbersArray = phoneNumbersArray;
        SitesArray = sitesArray;
    }
}

