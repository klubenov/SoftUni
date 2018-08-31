namespace CNet.App
{
    using AutoMapper;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.DependencyInjection;

    using Core;
    using Core.Contracts;
    using Core.Controllers;
    using Data;
    using Services;
    using Services.Contracts;


    using System;

    public class Startup
    {
        public static void Main(string[] args)
        {
            var service = ConfigureService();
            IEngine engine = new Engine(service);
            engine.Run();
        }

        private static IServiceProvider ConfigureService()
        {
            var serviceCollection = new ServiceCollection();

            serviceCollection.AddDbContext<CNetContext>(opt => opt.UseSqlServer(Configuration.ConnectionString));

            serviceCollection.AddAutoMapper(cfg => cfg.AddProfile<CNetProfile>());

            //var config = new AutoMapper.MapperConfiguration(cfg =>
            //{
            //    cfg.AddProfile(new CNetProfile());
            //});

            //var mapper = config.CreateMapper();
            //serviceCollection.AddSingleton(mapper);

            serviceCollection.AddTransient<IDbInitializerService, DbInitializerService>();
            serviceCollection.AddTransient<ICommandInterpreter, CommandInterpreter>();
            serviceCollection.AddTransient<IEmployeeController, EmployeeController>();
            serviceCollection.AddTransient<IManagerController, ManagerController>();

            var serviceProvider = serviceCollection.BuildServiceProvider();

            return serviceProvider;
        }
    }
}
