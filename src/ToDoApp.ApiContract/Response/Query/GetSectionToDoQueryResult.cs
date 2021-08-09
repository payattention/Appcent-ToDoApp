using System.Collections.Generic;
using ToDoApp.ApiContract.Contracts;

namespace ToDoApp.ApiContract.Response.Query
{
    public class GetSectionToDoQueryResult : ResponseBase
    {
        public IEnumerable<SectionModel> SectionList { get; set; }
    }
}
