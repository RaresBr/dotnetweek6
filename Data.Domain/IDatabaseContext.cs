using Microsoft.EntityFrameworkCore;
using Data.Domain.Entities;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Data.Persistence
{
    public interface IDatabaseContext
    {
        DbSet<MenuCard> MenuCards { get; set; }
        int SaveChanges();
        EntityEntry Entry(object entity);
    }
}
