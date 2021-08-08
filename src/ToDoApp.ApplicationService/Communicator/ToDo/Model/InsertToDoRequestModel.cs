using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoApp.ApplicationService.Communicator.ToDo.Model
{
    public class InsertToDoRequestModel
    {
        public string ToDo { get; set; }
        public string UserName { get; set; }
        public string SectionName { get; set; }
        public ToDoState ToDoState { get; set; }
        public ToDoPrimacy ToDoPrimacy { get; set; }
    }
}
