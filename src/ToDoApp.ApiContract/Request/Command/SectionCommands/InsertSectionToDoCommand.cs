using MediatR;
using System.ComponentModel.DataAnnotations;
using ToDoApp.ApiContract.Contracts;
using ToDoApp.ApiContract.Response.Command.SectionCommands;

namespace ToDoApp.ApiContract.Request.Command.SectionCommands
{
    public class InsertSectionToDoCommand : IRequest<ResponseBase<InsertSectionToDoCommandResult>>
    {
        [Required]
        public string SectionName { get; set; }
        [Required]
        public string UserName { get; set; }
    }
}
