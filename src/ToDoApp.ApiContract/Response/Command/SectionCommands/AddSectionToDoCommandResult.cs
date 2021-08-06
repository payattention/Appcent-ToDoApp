using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoApp.ApiContract.Contracts;

namespace ToDoApp.ApiContract.Response.Command.SectionCommands
{
    public class AddSectionToDoCommandResult : ResponseBase
    {
        public SectionModel Section { get; set; }
    }
}
