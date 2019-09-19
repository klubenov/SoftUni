using System;
using SIS.Framework;

namespace Exam.App
{
    public class Launcher
    {
        static void Main(string[] args)
        {
            WebHost.Start(new StartUp());
        }
    }
}
