using ToDoApp.ApiContract.Contracts;

namespace ToDoApp.ApplicationService.Communicator.SectionTodo.Model
{
    public class UpdateSectionToDoResponseModel : ResponseBase
    {
        public SectionCommunicatorModel Section { get; set; }
    }
}
