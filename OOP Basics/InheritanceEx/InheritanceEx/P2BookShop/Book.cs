using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


class Book
{
    private string author;

    protected string Author
    {
        get
        {
            return this.author;
        }
        set
        {
            bool containsDigit = false;

            foreach (var character in value)
            {
                if (char.IsDigit(character))
                {
                    containsDigit = true;
                    break;
                }
            }

            if (containsDigit)
            {
                throw new ArgumentException("Author not valid!");
            }
            this.author = value;
        }
    }

    private string title;

    protected string Title
    {
        get
        {
            return this.title;
        }
        set
        {
            if (value.Length < 3)
            {
                throw new ArgumentException("Title not valid!");
            }
            this.title = value;
        }
    }

    private decimal price;

    protected virtual decimal Price
    {
        get
        {
            return this.price;
        }
        set
        {
            if (value <= 0)
            {
                throw new ArgumentException("Price not valid!");
            }
            this.price = value;
        }
    }

    public Book(string author, string title, decimal price)
    {
        this.Author = author;
        this.Title = title;
        this.Price = price;
    }


    public override string ToString()
    {
        var resultBuilder = new StringBuilder();
        resultBuilder.AppendLine($"Type: {this.GetType().Name}")
            .AppendLine($"Title: {this.Title}")
            .AppendLine($"Author: {this.Author}")
            .AppendLine($"Price: {this.Price:f2}");

        string result = resultBuilder.ToString().TrimEnd();
        return result;
    }

}

