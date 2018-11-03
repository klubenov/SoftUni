using SIS.HTTP.Common;

namespace SIS.Framework.Utilities
{
    public static class ControllerUtilities
    {
        public static string GetControllerName(object controller)
            => controller.GetType()
                .Name
                .Replace(MvcContext.Get.ControllersSuffix, string.Empty);

        public static string GetViewFullyQualifiedName(string controller, string action)
        {
            //var viewFullyQualifiedName = string.Format("{0}/{1}/{2}.html", MvcContext.Get.ViewsFolderName, controller, action);
            var viewFullyQualifiedName = MvcContext.Get.RootDirectoryRelativePath +
                                         GlobalConstants.DirectorySeparator +
                                         MvcContext.Get.ViewsFolderName +
                                         GlobalConstants.DirectorySeparator +
                                         controller +
                                         GlobalConstants.DirectorySeparator +
                                         action +
                                         GlobalConstants.HtmlFileExtension;

            return viewFullyQualifiedName;
        }
    }
}