using Exam.Data;
using Microsoft.EntityFrameworkCore;
using SIS.Framework.Api;
using SIS.Framework.Services;

namespace Exam.App
{
    public class StartUp : MvcApplication
    {
        public override void ConfigureServices(IDependencyContainer dependencyContainer)
        {
            dependencyContainer.RegisterDependency<ExamDbContext, ExamDbContext>();
        }
    }
}
