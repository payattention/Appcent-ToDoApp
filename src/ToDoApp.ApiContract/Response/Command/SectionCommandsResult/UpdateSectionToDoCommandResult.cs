using ToDoApp.ApiContract.Contracts;

namespace ToDoApp.ApiContract.Response.Command.SectionCommandsResult
{
    public class UpdateSectionToDoCommandResult : ResponseBase
    {
        public SectionModel Section { get; set; }
    }
}
