using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TaskManager.App.Dtos;
using TaskManager.Domain;
using TaskManager.Storage;

namespace TaskManager.App.CQRS.Command
{
    class AddTaskCommandHandler : IRequestHandler<AddTaskCommand, TaskDto>
    {
        private readonly IStorage _storage;

        public AddTaskCommandHandler(IStorage storage)
        {
            _storage = storage;
        }

        public async Task<TaskDto> Handle(AddTaskCommand request, CancellationToken cancellationToken)
        {
            var task = new Domain.Task()
            {
                Id = request.Id,
                Name = request.Name,
                Status = request.Status,
                DateCreated = DateTime.Now,
                Description = request.Description
            };

            _storage.Add_Save(task);

            return new TaskDto() 
            { 
                Id = task.Id, 
                Name = task.Name, 
                Status = task.Status, 
                DateTimeTask = task.DateCreated, 
                Description = task.Description
            };
        }
    }
}
