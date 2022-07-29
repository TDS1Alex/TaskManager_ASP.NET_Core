using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MediatR;
using System.Threading.Tasks;
using TaskManager.App.Dtos;
using TaskManager.App.CQRS.Query;
using TaskManager.App.CQRS.Command;

namespace TaskManager_ASP.NET_Core.Controller
{
    [Route("task/")]
    [Produces("application/json")]
    [Consumes("application/json")]
    [Authorize]
    public class TaskController : ControllerBase
    {
        private readonly IMediator _mediator;
        public TaskController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [ProducesResponseType(typeof(TaskDto), 200)]
        [ProducesResponseType(typeof(string), 400)]
        [HttpPost("add")]
        public async Task<TaskDto> Add([FromBody] AddTaskCommand query)
        {
            return await _mediator.Send(query);
        }

        [ProducesResponseType(typeof(TaskDto), 200)]
        [ProducesResponseType(typeof(string), 400)]
        [HttpPost("list")]
        public async Task<TaskDto> List([FromBody] TaskListQuery query)
        {
            return await _mediator.Send(query);
        }
    }
}
