using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MediatR;

using TaskManager.App.Dtos;
using TaskManager.Storage;

namespace TaskManager.App.CQRS.Command.ChangeColumn
{
    public class ChangeColumnCommandHandler : IRequestHandler<ChangeColumnCommand, Result>
    {
        private readonly IStorage _storage;

        public ChangeColumnCommandHandler(IStorage storage)
        {
            _storage = storage;
        }

        public async Task<Result> Handle(ChangeColumnCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var task = _storage.Task.Single(t => t.Id == request.TaskId);
                var statuses = _storage.Statuses.Single(s =>s.Id == request.TaskId);

                task.Status = request.Status;
                if (task.Status == statuses.InPlans) statuses.InPlans = task.Status;
                else if (task.Status == statuses.InProcess) statuses.InProcess = task.Status;
                else if (task.Status == statuses.Stopped) statuses.Stopped = task.Status;
                else if (task.Status == statuses.Done) statuses.Done = task.Status;
                else statuses.StatusNoSet = task.Status;

                _storage.SaveChange();

                return new Result() { Status = HttpStatus.Ok };
            }
            catch (Exception e)
            {
                return new Result() { Status = HttpStatus.Error, Message = e.Message };
            }
        }
    }
}
