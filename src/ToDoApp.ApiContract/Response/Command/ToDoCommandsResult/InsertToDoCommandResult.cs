using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoApp.ApiContract.Contracts;

namespace ToDoApp.ApiContract.Response.Command.ToDoCommandsResult
{
    public class InsertToDoCommandResult : ResponseBase
    {
        public ToDoModel ToDo { get; set; }
    }
}
