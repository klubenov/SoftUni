namespace SIS.Framework
{
    public class MvcContext
    {
        private static MvcContext Instance;

        private MvcContext() { }

        public static MvcContext Get => Instance ?? (Instance = new MvcContext());

        public string AssemblyName { get; set; }

        public string ControllersFolder { get; set; }

        public string ControllersSuffix { get; set; }

        public string ViewsFolderName { get; set; }

        public string ModelsFolder { get; set; }

        public string ResourcesFolderName { get; set; }

        public string LayoutViewName { get; set; }

        public string RootDirectoryRelativePath { get; set; }
    }
}
