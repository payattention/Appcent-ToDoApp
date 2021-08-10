using MediatR;
using System.ComponentModel.DataAnnotations;
using ToDoApp.ApiContract.Contracts;
using ToDoApp.ApiContract.Response.Command.UserCommandsResult;

namespace ToDoApp.ApiContract.Request.Command.UserCommands
{
    public class LoginCommand : IRequest<ResponseBase<LoginCommandResult>>
    {
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }

    }
}
