
using System;

namespace ToDoApp.ApiContract.Contracts
{
    public class ToDoModel
    {
        public string ToDo { get; set; }
        public string SectionName { get; set; }
        public string Id { get; set; }
        public ToDoState ToDoState { get; set; }
        public ToDoPrimacy ToDoPrimacy { get; set; }
        public DateTime CreateDate { get; set; }
    }
}
