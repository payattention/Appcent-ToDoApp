using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToDoApp.ApiContract.Contracts;
using ToDoApp.ApiContract.Request.Command.ToDoCommands;
using ToDoApp.ApiContract.Response.Command;

namespace ToDoApp.Api.ToDoAppController
{
    [Route("api/[controller]")]
    [ApiController]
    public class ToDoController : ControllerBase
    {
        private readonly IMediator _mediator;
        public ToDoController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("InsertToDo")]
        [ProducesResponseType(200, Type = typeof(ResponseBase<InsertToDoCommandResult>))]
        public async Task<IActionResult> InsertToDo(InsertToDoCommand request)
        {
            var result = await _mediator.Send(new InsertToDoCommand
            {
               
            });
            return Ok(result);

        }

    }
}
