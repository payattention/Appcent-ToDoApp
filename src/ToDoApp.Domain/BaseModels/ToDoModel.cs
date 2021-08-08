using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoApp.Domain.BaseModels
{
    public class ToDoModel
    {
        public string Name { get; set; }
        public int TaskId { get; set; }
        public int MainTaskId { get; set; }
        public ToDoState ToDoState { get; set; }
        public ToDoPrimacy ToDoPrimacy { get; set; }
        public DateTime CreateDate { get; set; }
    }
}
