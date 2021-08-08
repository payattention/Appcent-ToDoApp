using System.Collections.Generic;
using ToDoApp.ApiContract.Contracts;

namespace ToDoApp.ApiContract.Response.Query
{
    public class GetSectionToDoQueryResult : ResponseBase
    {
        //public SectionModel Section { get; set; }

        public IEnumerable<SectionModel> SectionList { get; set; }
        //public bool IsSectionList { get; set; } // For Frontend. With this flag, they will know how many section in response and they dont need to check SectionList is empty or not.
    }
}
