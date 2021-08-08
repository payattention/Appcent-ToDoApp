using Couchbase;


namespace ToDoApp.Domain.SectionToDoModels
{
    public class InsertSectionToDoReqEntityModel
    {
        public string UserName { get; set; }

        public string SectionName { get; set; }
    }
}
