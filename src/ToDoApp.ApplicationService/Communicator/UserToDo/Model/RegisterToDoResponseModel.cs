using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoApp.ApplicationService.Communicator.UserToDo.Model
{
    public class RegisterToDoResponseModel
    {
        public bool isRegisterCompleted { get; set; }

        public string Token { get; set; }
    }
}
