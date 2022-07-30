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
    public class TaskListQueryHandler: IRequestHandler<TaskListQuery, ListDto<TaskDto>>
    {
        private readonly IStorage _storage;

        public TaskListQueryHandler(IStorage storage)
        {
            _storage = storage;
        }

        public Task<ListDto<TaskDto>> Handle(TaskListQuery request, CancellationToken cancellationToken)
        {
            var tasks = _storage.Task.ToList();
            DateTime dateReceiving = DateTime.Now;

            var result = tasks.Select(task => new TaskDto()
            {
                Id = task.Id,
                Name = task.Name,
                Description = task.Description,
                Status = task.Status,                   
                TaskTime = dateReceiving - task.DateCreated
            }).ToArray();

            var list = new ListDto<TaskDto>
            {
                Count = result.Length,
                Items = result
            };

            return list;
        }
    }
}
