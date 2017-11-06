using Data.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Data.Persistence
{


    public sealed class DatabaseContext :DbContext, IDatabaseContext
    {
        public DbSet<MenuCard> MenuCards { get; set; }
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {
        }
    }
}
