using Microsoft.EntityFrameworkCore;
using SIS.Framework.Api;
using SIS.Framework.Services;
using Torshia.Data;

namespace Torshia.App
{
    public class StartUp : MvcApplication
    {
        public override void ConfigureServices(IDependencyContainer dependencyContainer)
        {
            dependencyContainer.RegisterDependency<DbContext, TorshiaDbContext>();
        }
    }
}
