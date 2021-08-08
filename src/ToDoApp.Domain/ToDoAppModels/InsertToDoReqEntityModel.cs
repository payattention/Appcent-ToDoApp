using ToDoApp.Domain.BaseModels;

namespace ToDoApp.Domain.ToDoAppModels
{
    public class InsertToDoReqEntityModel
    {
        public string ToDo { get; set; }
        public string UserName { get; set; }
        public string SectionName { get; set; }
        public ToDoState ToDoState { get; set; }
        public ToDoPrimacy ToDoPrimacy { get; set; }
    }
}
