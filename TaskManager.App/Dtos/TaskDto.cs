using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManager.App.Dtos
{
    public class TaskDto
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string Status { get; set; }
        public string Description { get; set; }
        public TimeSpan TaskTime { get; set; }
        public DateTime DateTimeTask { get; set; }
    }
}
