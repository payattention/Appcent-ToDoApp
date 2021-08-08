using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoApp.ApiContract.Contracts;

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
