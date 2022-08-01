using Microsoft.EntityFrameworkCore;
using TaskManager.Domain;

namespace TaskManager.Storage
{
    public interface IStorage
    {
        DbSet<Task> Task { get; set; }
        DbSet<Statuses> TaskStatus { get; set; }

        void SaveChange();
    }
}
