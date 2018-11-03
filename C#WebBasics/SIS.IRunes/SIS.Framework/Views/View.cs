using System.Collections.Generic;
using System.IO;
using System.Linq;
using SIS.Framework.ActionResults.Contracts;
using SIS.HTTP.Common;
using SIS.HTTP.Enums;
using SIS.WebServer.Results;

namespace SIS.Framework.Views
{
    public class View : IRenderable
    {
        private const string RenderBodyConstant = "@RenderBody()";

        private readonly string fullyQualifiedTemplateName;

        private readonly IDictionary<string, object> viewData;

        public View(string fullyQualifiedTemplateName, IDictionary<string, object> viewData)
        {
            this.fullyQualifiedTemplateName = fullyQualifiedTemplateName;
            this.viewData = viewData;
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
            var renderedHtml = this.RenderHtml(fullHtml);
            var layoutWithView = this.AddVeiwToLayout(renderedHtml);

            return layoutWithView;
        }

        private string AddVeiwToLayout(string renderedHtml)
        {
            var layoutViewPath = MvcContext.Get.RootDirectoryRelativePath +
                             GlobalConstants.DirectorySeparator +
                             MvcContext.Get.ViewsFolderName +
                             GlobalConstants.DirectorySeparator +
                             MvcContext.Get.LayoutViewName +
                             GlobalConstants.HtmlFileExtension;

            if (!File.Exists(layoutViewPath))
            {
                throw new FileNotFoundException($"File does not exist at {layoutViewPath}");
            }

            var layoutViewContent = File.ReadAllText(layoutViewPath);
            var layoutWithView = layoutViewContent.Replace(RenderBodyConstant, renderedHtml);

            return layoutWithView;
        }

        private string RenderHtml(string fullHtml)
        {
            var renderedHtml = fullHtml;

            if (this.viewData.Any())
            {
                foreach (var parameter in this.viewData)
                {
                    renderedHtml = renderedHtml
                        .Replace($"{{{{{{{parameter.Key}}}}}}}", parameter.Value.ToString());
                }
            }

            return renderedHtml;
        }
    }
}
