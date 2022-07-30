using Microsoft.EntityFrameworkCore;
using TaskManager.Domain;

namespace TaskManager.Storage
{
    public class DbStorage : DbContext, IStorage
    {
        public DbSet<Task> Task { get; set; } = null!;

        public DbStorage(DbContextOptions<DbStorage> options)
            : base(options) { Database.EnsureCreated(); }

        public void SaveChange() => SaveChanges();
    }
}
