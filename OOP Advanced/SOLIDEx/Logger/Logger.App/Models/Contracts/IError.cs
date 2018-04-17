using System;

namespace Logger.App.Models.Contracts
{
    public interface IError : ILevelable
    {
        DateTime DateTime { get; }

        string Message { get; }
    }
}