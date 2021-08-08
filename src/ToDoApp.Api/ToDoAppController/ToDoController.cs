using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToDoApp.ApiContract.Contracts;
using ToDoApp.ApiContract.Request.Command.SectionCommands;
using ToDoApp.ApiContract.Request.Command.ToDoCommands;
using ToDoApp.ApiContract.Response.Command;

namespace ToDoApp.Api.ToDoAppController
{
    [Route("toDo")]
    [ApiController]
    public class ToDoController : ControllerBase
    {
        private readonly IMediator _mediator;
        public ToDoController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("insertToDo")]
        public async Task<IActionResult> InsertToDo(InsertToDoCommand request)
        {
            var result = await _mediator.Send(request);
            return Ok(result);
        }

        [HttpPost("insertSectionToDo")]
        public async Task<IActionResult> InsertSectionToDo(InsertSectionToDoCommand request)
        {
            var result = await _mediator.Send(request);
            return Ok(result);
        }

    }
}
