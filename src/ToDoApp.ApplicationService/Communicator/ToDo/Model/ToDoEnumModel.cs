using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoApp.ApplicationService.Communicator.ToDo.Model
{
    public enum ToDoState
    {
        Undefined,
        Todo,
        InProgress,
        Completed
    }

    public enum ToDoPrimacy
    {
        Undefined,
        P1,
        P2,
        P3
    }
}
