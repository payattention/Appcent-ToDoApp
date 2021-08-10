using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoApp.Domain.SectionToDoModels
{
    public class UpdateSectionToDoReqEntityModel
    {
        public string UserName { get; set; }
        public string SectionId { get; set; }
        public string NewName { get; set; }
    }
}
