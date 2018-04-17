﻿using System;
using System.Collections.Generic;
using System.Text;
using Logger.App.Models.Contracts;

namespace Logger.App.Models
{
    public class Error : IError
    {
        public Error(DateTime dateTime, ErrorLevel level, string message)
        {
            this.DateTime = dateTime;
            this.Level = level;
            this.Message = message;
        }

        public ErrorLevel Level { get; }

        public DateTime DateTime { get; }

        public string Message { get; }
    }
}
