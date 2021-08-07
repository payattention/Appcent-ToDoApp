using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoApp.ApplicationService.Communicator.ToDo.Model
{
    public class InsertToDoRequestModel
    {
        public string Name { get; set; }
        public string UserName { get; set; }
        public int SectionId { get; set; }
        public int MainTaskId { get; set; }
        public ToDoState ToDoState { get; set; }
        public ToDoPrimacy ToDoPrimacy { get; set; }
    }
}
