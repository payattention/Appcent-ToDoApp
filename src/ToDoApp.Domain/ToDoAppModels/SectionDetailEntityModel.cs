using System.Collections.Generic;

namespace ToDoApp.Domain.ToDoAppModels
{
    public class SectionDetailEntityModel
    {
        public string SectionName { get; set; }
        public IEnumerable<ToDoEntityModel> TodoList { get; set; }
    }
}
