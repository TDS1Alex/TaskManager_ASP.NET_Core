using System;

namespace TaskManager.Domain
{
    public class Task
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string Status { get; set; }
        public DateTime DateCreated { get; set; }
        public string Description { get; set; }
    }
}
