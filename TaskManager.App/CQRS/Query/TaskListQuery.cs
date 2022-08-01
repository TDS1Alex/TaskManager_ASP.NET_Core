using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.App.Dtos;

namespace TaskManager.App.CQRS.Query
{
    public class TaskListQuery : IRequest<ListDto<TaskDto>>
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string Status { get; set; }
        public string Description { get; set; }
    }
}
