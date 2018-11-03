using System;
using System.Reflection;
using SIS.WebServer;

namespace SIS.Framework
{
    public class MvcEngine
    {
        public void Run(Server server)
        {
            RegisterAssemblyName();
            RegisterControllersData();
            RegisterViewsData();
            RegisterModelsData();
            RegisterResourcesData();
            RegisterLayoutData();
            RegisterRootDirectoryData();

            try
            {
                server.Run();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        private static void RegisterModelsData()
        {
            MvcContext.Get.ModelsFolder = "../../../Models";
        }

        private static void RegisterViewsData()
        {
            MvcContext.Get.ViewsFolderName = "Views";
        }

        private static void RegisterResourcesData()
        {
            MvcContext.Get.ResourcesFolderName = "Resources";
        }

        private static void RegisterLayoutData()
        {
            MvcContext.Get.LayoutViewName = "_Layout";
        }

        private static void RegisterRootDirectoryData()
        {
            MvcContext.Get.RootDirectoryRelativePath = "../../..";
        }

        private static void RegisterControllersData()
        {
            MvcContext.Get.ControllersFolder = "Controllers";
            MvcContext.Get.ControllersSuffix = "Controller";
        }

        private static void RegisterAssemblyName()
        {
            MvcContext.Get.AssemblyName = Assembly.GetEntryAssembly().GetName().Name;
        }
    }
}
