using System;
using Data.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace IntegrationTests
{
    public abstract class BaseIntegrationTest
    {
        public virtual bool UseSqlServer => false;

        [TestInitialize]
        private void TestInitialize()
        {
            DestroyDatabase();
            CreateDatabase();
        }

        [TestCleanup]
        private void TestCleanup()
        {
            DestroyDatabase();
        }

        protected void RunOnDatabase(Action<DatabaseContext> databaseAction)
        {
            if (UseSqlServer)
            {
                RunOnSqlServer(databaseAction);
            }
            else
            {
                RunOnMemory(databaseAction);
            }
        }

        private void RunOnMemory(Action<DatabaseContext> databaseAction)
        {
            var options = new DbContextOptionsBuilder<DatabaseContext>()
                .UseInMemoryDatabase("TodosList")
                .Options;

            using (var context = new DatabaseContext(options))
            {
                databaseAction(context);
            }
        }

        private void RunOnSqlServer(Action<DatabaseContext> databaseAction)
        {
            var connection = @"Server = .\SQLEXPRESS; Database = Todos.Development; Trusted_Connection = true;";

            var options = new DbContextOptionsBuilder<DatabaseContext>()
                .UseSqlServer(connection)
                .Options;

            using (var context = new DatabaseContext(options))
            {
                databaseAction(context);
            }
        }

        private void CreateDatabase()
        {
            RunOnDatabase(ctx => ctx.Database.EnsureCreated());
        }

        private void DestroyDatabase()
        {
            RunOnDatabase(ctx => ctx.Database.EnsureDeleted());
        }
    }
}
