using MediatR;
using System.ComponentModel.DataAnnotations;
using ToDoApp.ApiContract.Contracts;
using ToDoApp.ApiContract.Response.Command.ToDoCommandsResult;

namespace ToDoApp.ApiContract.Request.Command.ToDoCommands
{
    public class InsertToDoCommand : IRequest<ResponseBase<InsertToDoCommandResult>>
    {
        [Required]
        public string ToDo { get; set; }
        [Required]
        public string UserName { get; set; }
        [Required]
        public string SectionName { get; set; }
        public ToDoState ToDoState { get; set; }
        public ToDoPrimacy ToDoPrimacy { get; set; }
        
    }
}
