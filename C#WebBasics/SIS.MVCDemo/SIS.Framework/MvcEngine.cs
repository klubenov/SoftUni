﻿using System;
using System.Reflection;
using SIS.WebServer;

namespace SIS.Framework
{
    public class MvcEngine
    {
        public static void Run(Server server)
        {
            RegisterAssemblyName();
            RegisterControllersData();
            RegisterViewsData();
            RegisterModelsData();

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
            MvcContext.Get.ViewsFolder = "../../../Views";
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
