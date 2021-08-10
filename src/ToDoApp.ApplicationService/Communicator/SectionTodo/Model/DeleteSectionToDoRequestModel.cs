using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoApp.ApplicationService.Communicator.SectionTodo.Model
{
    public class DeleteSectionToDoRequestModel
    {
        public string SectionId{ get; set; }

        public string UserName { get; set; }

        public string SectionName { get; set; }
    }
}
