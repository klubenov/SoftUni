using SIS.Framework;

namespace Torshia.App
{
    public class Launcher
    {
        static void Main()
        {
            WebHost.Start(new StartUp());
        }
    }
}
