using MediatR;
using System.ComponentModel.DataAnnotations;
using ToDoApp.ApiContract.Contracts;
using ToDoApp.ApiContract.Response.Command.UserCommandsResult;

namespace ToDoApp.ApiContract.Request.Command.UserCommands
{
    public class RegisterCommand : IRequest<ResponseBase<RegisterCommandResult>>
    {
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }

    }
}

