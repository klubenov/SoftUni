using System;
using System.Collections.Generic;
using System.Text;
using Logger.App.Models.Contracts;

namespace Logger.App.Models
{
    public class ConsoleAppender : IAppender
    {
        public ConsoleAppender(ILayout layouyt, ErrorLevel level)
        {
            this.Layout = layouyt;
            this.Level = level;
        }

        public ErrorLevel Level { get; }

        public ILayout Layout { get; }

        public int MessagesAppended { get; private set; }


        public void Append(IError error)
        {
            string formattedError = this.Layout.FormatError(error);
            this.MessagesAppended++;
            Console.WriteLine(formattedError);
        }

        public override string ToString()
        {
            string result =
                $"Appender type: {this.GetType().Name}, Layout type: {this.Layout.GetType().Name}, Report level: {this.Level}, Messages appended: {this.MessagesAppended}";
            return result;
        }
    }
}
