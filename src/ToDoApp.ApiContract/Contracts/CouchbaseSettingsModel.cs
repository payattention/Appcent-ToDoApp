using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoApp.ApiContract.Contracts
{
    public class CouchbaseSettingsModel
    {
        public string Username{ get; set; }
        public string Password { get; set; }
        public List<string> Servers { get; set; }

    }
}
