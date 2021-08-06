using ToDoApp.ApiContract.Contracts;

namespace ToDoApp.ApiContract.Response.Query
{
    public class LoginQueryResult : ResponseBase
    {
        public string SessionId { get; set; }
    }
}
