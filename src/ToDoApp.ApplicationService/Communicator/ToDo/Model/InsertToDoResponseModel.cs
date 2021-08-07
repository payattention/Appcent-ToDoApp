using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoApp.ApiContract.Contracts;

namespace ToDoApp.ApplicationService.Communicator.ToDo.Model
{
    public class InsertToDoResponseModel : ResponseBase
    {
        public ToDoModel ToDo { get; set; }
    }
}
