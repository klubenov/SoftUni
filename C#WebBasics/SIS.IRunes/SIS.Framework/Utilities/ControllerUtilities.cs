﻿namespace SIS.Framework.Utilities
{
    public static class ControllerUtilities
    {
        public static string GetControllerName(object controller)
            => controller.GetType()
                .Name
                .Replace(MvcContext.Get.ControllersSuffix, string.Empty);

        public static string GetViewFullyQualifiedName(string controller, string action)
            => string.Format("{0}\\{1}\\{2}", MvcContext.Get.ViewsFolder, controller, action);
    }
}