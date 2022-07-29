using Microsoft.EntityFrameworkCore;
using TaskManager.Domain;

namespace TaskManager.Storage
{
    public class DbStorage : DbContext, IStorage
    {
        public DbSet<Task> Task { get; set; } = null!;

        private readonly DbStorage _storage;

        public DbStorage(DbStorage storage)
        {
            _storage = storage;
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=Task-Manager.db");
        }

        public void Add_Save(Task task)
        {
            _storage.Task.Add(task);
            _storage.SaveChanges();
        }
    }
}
