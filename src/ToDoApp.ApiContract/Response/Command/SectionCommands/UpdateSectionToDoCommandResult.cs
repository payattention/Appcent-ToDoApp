using ToDoApp.ApiContract.Contracts;

namespace ToDoApp.ApiContract.Response.Command.SectionCommands
{
    public class UpdateSectionToDoCommandResult : ResponseBase
    {
        public SectionModel Section { get; set; }
    }
}
