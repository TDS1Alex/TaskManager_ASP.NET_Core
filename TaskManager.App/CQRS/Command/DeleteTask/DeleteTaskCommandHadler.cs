using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MediatR;

using TaskManager.App.Dtos;
using TaskManager.Storage;

namespace TaskManager.App.CQRS.Command.DeleteTask
{
    public class DeleteTaskCommandHadler : IRequestHandler<DeleteTaskCommand, Result>
    {
        private readonly IStorage _storage;

        public DeleteTaskCommandHadler(IStorage storage) => _storage = storage;

        public async Task<Result> Handle(DeleteTaskCommand request, CancellationToken cancellationToken)
        {
            try
            {
                _storage.Task.Remove(_storage.Task.Single(t => t.Id == request.TaskId));
                return new Result() {Status = HttpStatus.Ok};
            }
            catch (Exception e)
            {
                return new Result() {Status = HttpStatus.Error, Message = e.Message};
            }
        }
    }
}
