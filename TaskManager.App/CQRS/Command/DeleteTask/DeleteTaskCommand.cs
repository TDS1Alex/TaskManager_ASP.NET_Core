using MediatR;
using TaskManager.App.Dtos;

namespace TaskManager.App.CQRS.Command.DeleteTask
{
    public class DeleteTaskCommand: IRequest<Result>
    {
        public int TaskId { get; set; }
    }
}
