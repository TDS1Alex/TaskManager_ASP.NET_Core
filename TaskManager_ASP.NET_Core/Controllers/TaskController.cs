using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MediatR;
using System.Threading.Tasks;

using TaskManager.App.Dtos;
using TaskManager.App.CQRS.Query;
using TaskManager.App.CQRS.Command.AddTask;
using TaskManager.App.CQRS.Command.EditTask;
using TaskManager.App.CQRS.Command.DeleteTask;

namespace TaskManager_ASP.NET_Core.Controller
{
    [Route("task/")]
    [Produces("application/json")]
    [Consumes("application/json")]
    //[Authorize]
    public class TaskController : ControllerBase
    {
        private readonly IMediator _mediator;
        public TaskController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [ProducesResponseType(typeof(Result), 200)]
        [ProducesResponseType(typeof(string), 400)]
        [HttpPost("add")]
        public async Task<Result> Add([FromBody] AddTaskCommand query)
        {
            return await _mediator.Send(query);
        }

        [ProducesResponseType(typeof(ListDto<TaskDto>), 200)]
        [ProducesResponseType(typeof(string), 400)]
        [HttpPost("list")]
        public async Task<ListDto<TaskDto>> List([FromBody] TaskListQuery query)
        {
            return await _mediator.Send(query);
        }

        [ProducesResponseType(typeof(Result), 200)]
        [ProducesResponseType(typeof(string), 400)]
        [HttpPost("delete")]
        public async Task<Result> Delete([FromBody] DeleteTaskCommand query)
        {
            return await _mediator.Send(query);
        }

        [ProducesResponseType(typeof(Result), 200)]
        [ProducesResponseType(typeof(string), 400)]
        [HttpPost("edit")]
        public async Task<Result> Edit([FromBody] EditTaskCommand query)
        {
            return await _mediator.Send(query);
        }
    }
}
