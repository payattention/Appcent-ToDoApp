using ToDoApp.ApiContract.Contracts;

namespace ToDoApp.ApplicationService.Communicator.ToDo.Model
{
    public class UpdateToDoResponseModel : ResponseBase
    {
        public ToDoModel ToDo { get; set; }
    }
}
