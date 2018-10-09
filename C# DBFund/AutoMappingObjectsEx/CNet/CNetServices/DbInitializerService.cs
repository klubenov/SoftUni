namespace CNet.Services
{
    using System;

    using Microsoft.EntityFrameworkCore;

    using Contracts;
    using Data;

    public class DbInitializerService : IDbInitializerService
    {
        private readonly CNetContext context;

        public DbInitializerService(CNetContext context)
        {
            this.context = context;
        }

        public void InitializeDatabase()
        {
            this.context.Database.Migrate();
        }
    }
}
