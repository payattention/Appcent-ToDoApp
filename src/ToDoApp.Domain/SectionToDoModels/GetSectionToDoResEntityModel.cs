using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoApp.ApiContract.Contracts;

namespace ToDoApp.Domain.SectionToDoModels
{
    public class GetSectionToDoResEntityModel : ResponseBase
    {
        public IEnumerable<SectionEntityModel> SectionList { get; set; }
    }
}
