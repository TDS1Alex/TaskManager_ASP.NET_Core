using MediatR;
using TaskManager.App.Dtos;
using TaskManager.Domain;

namespace TaskManager.App.CQRS.Command
{
    public class AddTaskCommand : IRequest<TaskDto>
    {      
        public int Id { get; set; }
        public string? Name { get; set; }
        public string Status { get; set; }
        public string Description { get; set; }
    }
}
