using MediatR;
using TaskManager.App.Dtos;

namespace TaskManager.App.CQRS.Command.AddTask
{
    public class AddTaskCommand : IRequest<Result>
    {      
        public int Id { get; set; }
        public string? Name { get; set; }
        public string Status { get; set; }
        public string Description { get; set; }
    }
}
