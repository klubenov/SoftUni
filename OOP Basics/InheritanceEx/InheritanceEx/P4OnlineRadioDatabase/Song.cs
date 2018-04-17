using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;


class Song
{
    public Artist Artist { get; set; }

    private string name;

    public string Name
    {
        get { return this.name; }
        private set
        {
            if (value.Length < 3 || value.Length > 20)
            {
                throw new ArgumentException("Song name should be between 3 and 30 symbols.");
            }
            this.name = value;
        }
    }

    private string length;

    public string Length
    {
        get { return this.length; }
        private set
        {
            string pattern = @"^\d+:\d+";
            Regex rgx = new Regex(pattern);
            if (!rgx.IsMatch(value))
            {
                throw new ArgumentException("Invalid song length.");
            }

            var lenghtStringArr = value.Split(':');
            var minutes = int.Parse(lenghtStringArr[0]);
            var seconds = int.Parse(lenghtStringArr[1]);

            if (minutes<0 || minutes>14)
            {
                throw new ArgumentException("Song minutes should be between 0 and 14.");
            }
            if (seconds<0 || seconds>59)
            {
                throw new ArgumentException("Song seconds should be between 0 and 59.");
            }

            this.length = value;
        }
    }

    public Song(string name, Artist artist, string length)
    {
        Name = name;
        Artist = artist;
        Length = length;
    }

    public int GetMinutes()
    {
        return int.Parse(Length.Split(':')[0]);
    }

    public int GetSeconds()
    {
        return int.Parse(Length.Split(':')[1]);
    }
}

