using System.Collections.Generic;

namespace Logger.App.Models.Contracts
{
    public interface ILogger
    {
        void Log(IError error);

        IReadOnlyCollection<IAppender> Appenders { get; }
    }
}
