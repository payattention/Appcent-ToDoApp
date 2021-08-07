using ToDoApp.Domain.BaseModels;

namespace ToDoApp.Domain.ToDoAppModels
{
    public class InsertToDoReqEntityModel
    {
        public string Name { get; set; }
        public string UserName { get; set; }
        public int SectionId { get; set; }
        public int MainTaskId { get; set; }
        public ToDoState ToDoState { get; set; }
        public ToDoPrimacy ToDoPrimacy { get; set; }
    }
}
