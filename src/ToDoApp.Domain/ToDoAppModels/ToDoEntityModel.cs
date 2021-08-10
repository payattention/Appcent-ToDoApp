using System;
using ToDoApp.Domain.BaseModels;

namespace ToDoApp.Domain.ToDoAppModels
{
    public class ToDoEntityModel
    {
        public string ToDo { get; set; }
        public string SectionName { get; set; }
        public string Id { get; set; }
        public ToDoState ToDoState { get; set; }
        public ToDoPrimacy ToDoPrimacy { get; set; }
        public DateTime CreateDate { get; set; }
    }
}
