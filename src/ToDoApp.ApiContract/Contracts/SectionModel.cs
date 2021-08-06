using System.Collections.Generic;

namespace ToDoApp.ApiContract.Contracts
{
    public class SectionModel
    {
        public string Name { get; set; }
        public int SectionId { get; set; }
        public IEnumerable<ToDoModel> TodoList { get; set; }
    }
}
