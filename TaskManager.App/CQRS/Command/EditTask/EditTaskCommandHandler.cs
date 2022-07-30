using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MediatR;

using TaskManager.App.Dtos;
using TaskManager.Storage;

namespace TaskManager.App.CQRS.Command.EditTask
{
    class EditTaskCommandHandler : IRequestHandler<EditTaskCommand, Result>
    {
        private readonly IStorage _storage;

        public EditTaskCommandHandler(IStorage storage) => _storage = storage;

        public async Task<Result> Handle(EditTaskCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var task = _storage.Task.Single(t => t.Id == request.Id);

                task.Name = request.Name;
                task.Status = request.Status;
                task.Description = request.Description;

                _storage.SaveChange();

                return new Result() {Status = HttpStatus.Ok};
            }
            catch (Exception e)
            {
                return new Result() {Status = HttpStatus.Error, Message = e.Message};
            }
        }
    }
}
