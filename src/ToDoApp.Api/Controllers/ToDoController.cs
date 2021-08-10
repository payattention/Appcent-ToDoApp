using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using ToDoApp.ApiContract.Request.Command.SectionCommands;
using ToDoApp.ApiContract.Request.Command.ToDoCommands;
using ToDoApp.ApiContract.Request.Query;

namespace ToDoApp.Api.Controllers
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
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

        [HttpDelete("deleteSectionToDo")]
        public async Task<IActionResult> DeleteSectionToDo(DeleteSectionToDoCommand request)
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
