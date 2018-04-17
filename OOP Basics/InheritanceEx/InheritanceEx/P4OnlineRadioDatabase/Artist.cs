using System;
using System.Collections.Generic;
using System.Text;


class Artist
{
    private string name;

    public string Name
    {
        get { return this.name; }
        private set
        {
            if (value.Length < 3 || value.Length > 20)
            {
                throw new ArgumentException("Artist name should be between 3 and 20 symbols.");
            }

            this.name = value;
        }
    }

    public Artist(string name)
    {
        Name = name;
    }
}

