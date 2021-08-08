using System.Collections.Generic;
using ToDoApp.ApiContract.Contracts;

namespace ToDoApp.ApiContract.Response.Query
{
    public class GetAllSectionWithDetailQueryResult
    {
        public IEnumerable<SectionDetailModel> SectionDetail { get; set; }
    }
}
