using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoApp.ApplicationService.Communicator.UserToDo.Model
{
    public class LoginToDoRequestModel
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
