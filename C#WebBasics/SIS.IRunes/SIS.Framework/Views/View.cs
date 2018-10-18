using System.IO;
using SIS.Framework.ActionResults.Contracts;

namespace SIS.Framework.Views
{
    public class View : IRenderable
    {
        private readonly string fullyQualifiedTemplateName;

        public View(string fullyQualifiedTemplateName)
        {
            this.fullyQualifiedTemplateName = fullyQualifiedTemplateName;
        }

        private string ReadFile()
        {
            if (!File.Exists(fullyQualifiedTemplateName))
            {
                throw new FileNotFoundException("View not found");
            }

            var htmlFile = File.ReadAllText(fullyQualifiedTemplateName);

            return htmlFile;
        }

        public string Render()
        {
            var fullHtml = this.ReadFile();

            return fullHtml;
        }
    }
}
