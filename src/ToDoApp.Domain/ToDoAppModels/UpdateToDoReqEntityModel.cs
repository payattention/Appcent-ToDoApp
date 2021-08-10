using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoApp.Domain.BaseModels;

namespace ToDoApp.Domain.ToDoAppModels
{
    public class UpdateToDoReqEntityModel
    {
        public string ToDoId { get; set; }
        public string UserName { get; set; }
        public string ToDo { get; set; }
        public ToDoState ToDoState { get; set; }
        public ToDoPrimacy ToDoPrimacy { get; set; }
    }
}
