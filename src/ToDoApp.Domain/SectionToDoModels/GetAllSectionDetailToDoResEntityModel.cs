using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoApp.Domain.ToDoAppModels;

namespace ToDoApp.Domain.SectionToDoModels
{
    public class GetAllSectionDetailToDoResEntityModel
    {
        public IEnumerable<SectionDetailEntityModel> SectionDetail { get; set; }
    }
}
