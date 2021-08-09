using MediatR;
using System.ComponentModel.DataAnnotations;
using ToDoApp.ApiContract.Contracts;
using ToDoApp.ApiContract.Response.Command;

namespace ToDoApp.ApiContract.Request.Command.ToDoCommands
{
    public class DeleteToDoCommand : IRequest<ResponseBase<DeleteToDoCommandResult>>
    {
        [Required]
        public string TodoId { get; set; }

    }
}
