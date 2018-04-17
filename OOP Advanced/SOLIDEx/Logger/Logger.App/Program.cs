using System;
using System.Collections.Generic;
using Logger.App.Factories;
using Logger.App.Models;
using Logger.App.Models.Contracts;
using Logger.App.Models.Factories;

namespace Logger.App
{
    class Program
    {
        static void Main()
        {
            ILogger logger = InitializeLogger();
            ErrorFactory errorFactory = new ErrorFactory();
            Engine engine = new Engine(logger, errorFactory);
            engine.Run();
        }

        static ILogger InitializeLogger()
        {
            ICollection<IAppender> appenders = new List<IAppender>();
            LayoutFactory layoutFactory = new LayoutFactory();
            AppenderFactory appenderFactory = new AppenderFactory(layoutFactory);

            int appenderCount = int.Parse(Console.ReadLine());
            for (int i = 0; i < appenderCount; i++)
            {
                var input = Console.ReadLine().Split(' ');
                string appenderType = input[0];
                string layoutType = input[1];
                string errorLevel = "INFO";
                if (input.Length==3)
                {
                    errorLevel = input[2];
                }

                IAppender appender = appenderFactory.CreateAppender(appenderType, errorLevel, layoutType);
                appenders.Add(appender);
            }

            ILogger logger = new Logger(appenders);

            return logger;
        }
    }
}
