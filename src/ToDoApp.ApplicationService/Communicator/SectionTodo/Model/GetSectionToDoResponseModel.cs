using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoApp.ApiContract.Contracts;

namespace ToDoApp.ApplicationService.Communicator.SectionTodo.Model
{
    public class GetSectionToDoResponseModel : ResponseBase
    {
        public IEnumerable<SectionModel> SectionNames { get; set; }
    }
}
