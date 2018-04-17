using System.Collections.Generic;
using Logger.App.Models.Contracts;

namespace Logger.App
{
    public class Logger : ILogger
    {
        private IEnumerable<IAppender> appenders;

        public Logger(IEnumerable<IAppender> appenders)
        {
            this.appenders = appenders;
        }

        public void Log(IError error)
        {
            foreach (IAppender appender in this.appenders)
            {
                if (appender.Level<= error.Level)
                {
                    appender.Append(error);
                }
            }
        }

        public IReadOnlyCollection<IAppender> Appenders => (IReadOnlyCollection<IAppender>) this.appenders;
    }
}
