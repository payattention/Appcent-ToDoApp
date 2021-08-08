using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoApp.ApiContract.Contracts
{
    public class SectionDetailModel
    {
            public string SectionName { get; set; }
            public IEnumerable<ToDoModel> TodoList { get; set; }
        
    }
}
