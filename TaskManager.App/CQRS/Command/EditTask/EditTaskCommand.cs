using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using TaskManager.App.Dtos;

namespace TaskManager.App.CQRS.Command.EditTask
{
    public class EditTaskCommand : IRequest<Result>
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string Status { get; set; }
        public string Description { get; set; }
    }
}
