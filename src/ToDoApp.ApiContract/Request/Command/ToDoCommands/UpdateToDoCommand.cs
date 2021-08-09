using MediatR;
using System.ComponentModel.DataAnnotations;
using ToDoApp.ApiContract.Contracts;
using ToDoApp.ApiContract.Response.Command;

namespace ToDoApp.ApiContract.Request.Command.ToDoCommands
{
    public class UpdateToDoCommand : IRequest<ResponseBase<UpdateToDoCommandResult>>
    {
        [Required]
        public string ToDoId { get; set; }
        [Required]
        public string UserName { get; set; }
        public string ToDo { get; set; }   
        public ToDoState ToDoState { get; set; }
        public ToDoPrimacy ToDoPrimacy { get; set; }

        //[Required]
        //public string SectionName { get; set; }

    }
}
