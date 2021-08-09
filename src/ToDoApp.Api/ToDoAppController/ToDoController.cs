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
using ToDoApp.ApiContract.Request.Query;
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

        [HttpDelete("deleteToDo")]
        public async Task<IActionResult> DeleteToDo(DeleteToDoCommand request)
        {
            var result = await _mediator.Send(request);
            return Ok(result);
        }

        [HttpPost("updateToDo")]
        public async Task<IActionResult> UpdateToDo(UpdateToDoCommand request)
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

        [HttpPost("updateSectionToDo")]
        public async Task<IActionResult> updateSectionToDo(UpdateSectionToDoCommand request)
        {
            var result = await _mediator.Send(request);
            return Ok(result);
        }

        [HttpGet("getSections")]
        public async Task<IActionResult> GetSections(GetSectionToDoQuery request)
        {
            var result = await _mediator.Send(request);
            return Ok(result);
        }

        [HttpGet("getAllSectionsWithDetails")]
        public async Task<IActionResult> GetAllSectionsWithDetails(GetAllSectionWithDetailsQuery request)
        {
            var result = await _mediator.Send(request);
            return Ok(result);
        }
    }
}
