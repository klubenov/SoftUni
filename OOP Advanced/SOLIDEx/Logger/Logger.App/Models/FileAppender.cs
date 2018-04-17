using Logger.App.Models;
using Logger.App.Models.Contracts;

namespace Logger.App.Models
{
    internal class FileAppender : IAppender
    {
        private ILogFile logFile;

        public FileAppender(ILayout layout, ErrorLevel errorLevel, ILogFile logFile)
        {
            this.Layout = layout;
            this.Level = errorLevel;
            this.logFile = logFile;
            this.MessagesAppended = 0;
        }

        public int MessagesAppended { get; private set; }

        public ErrorLevel Level { get; }

        public ILayout Layout { get; }

        public void Append(IError error)
        {
            string formatterError = this.Layout.FormatError(error);
            this.logFile.WriteToFile(formatterError);
            this.MessagesAppended++;
        }

        public override string ToString()
        {
            string result =
                $"Appender type: {this.GetType().Name}, Layout type: {this.Layout.GetType().Name}, Report level: {this.Level.ToString()}, Messages appended: {this.MessagesAppended}, File size: {this.logFile.Size}";
            return result;
        }
    }
}