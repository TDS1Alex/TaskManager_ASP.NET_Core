using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using TaskManager.App.Dtos;
using TaskManager.Storage;

namespace TaskManager.App.CQRS.Query
{
    public class TaskListQueryHandler: IRequestHandler<TaskListQuery, TaskDto>
    {
        private readonly IStorage _storage;

        public TaskListQueryHandler(IStorage storage)
        {
            _storage = storage;
        }

        public Task<TaskDto> Handle(TaskListQuery request, CancellationToken cancellationToken)
        {
            var users = _storage.Task.ToList();
            DateTime dateReceiving = DateTime.Now;

            var result = users.Select(task => new TaskDto()
            {
                Id = task.Id,
                Name = task.Name,
                Description = task.Description,
                Status = task.Status,                   
                TaskTime = dateReceiving - task.DateCreated
            });

            return (Task<TaskDto>)result;
        }
    }
}
