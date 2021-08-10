
using ToDoApp.ApiContract.Contracts;

namespace ToDoApp.ApiContract.Response.Command.UserCommandsResult
{
    public class RegisterCommandResult : ResponseBase
    {
        public bool isRegisterCompleted { get; set; }

        public string Token { get; set; }
    }
}
