using System.Collections.Generic;
using System.IO;
using System.Linq;
using SIS.Framework.ActionResults.Contracts;

namespace SIS.Framework.Views
{
    public class View : IRenderable
    {
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

            return renderedHtml;
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
