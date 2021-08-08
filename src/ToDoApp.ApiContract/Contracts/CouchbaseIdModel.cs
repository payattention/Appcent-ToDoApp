namespace ToDoApp.ApiContract.Contracts
{
    public class CouchbaseIdModel
    {
        public int cas { get; set; }

        public int expiration { get; set; }

        public int flags { get; set; }

        public string id { get; set; }

        public string type { get; set; }
    }
}
