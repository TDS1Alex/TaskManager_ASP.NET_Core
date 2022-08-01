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

namespace TaskManager.App.CQRS.Command.AddTask
{
    class AddTaskCommandHandler : IRequestHandler<AddTaskCommand, Result>
    {
        private readonly IStorage _storage;

        public AddTaskCommandHandler(IStorage storage)
        {
            _storage = storage;
        }

        public async Task<Result> Handle(AddTaskCommand request, CancellationToken cancellationToken)
        {
            var task = new Domain.Task()
            {
                Id = request.Id,
                Name = request.Name,
                Status = request.Status,
                DateCreated = DateTime.Now,
                Description = request.Description
            };
            _storage.Task.Add(task);

            Statuses statuses = new Statuses();
            if (task.Status == statuses.InPlans) statuses.InPlans = task.Status;
            else if (task.Status == statuses.InProcess) statuses.InProcess = task.Status;
            else if (task.Status == statuses.Stopped) statuses.Stopped = task.Status;
            else if (task.Status == statuses.Done) statuses.Done = task.Status;
            else statuses.StatusNoSet = task.Status;
            _storage.TaskStatus.Add(statuses);

            _storage.SaveChange();

            return new Result() {Status = HttpStatus.Ok};
        }
    }
}
