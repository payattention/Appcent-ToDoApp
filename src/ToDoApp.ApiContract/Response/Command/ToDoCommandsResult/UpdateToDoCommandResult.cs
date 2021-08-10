using ToDoApp.ApiContract.Contracts;

namespace ToDoApp.ApiContract.Response.Command.ToDoCommandsResult
{
    public class UpdateToDoCommandResult : ResponseBase
    {
        public ToDoModel ToDo { get; set; }
    }
}
