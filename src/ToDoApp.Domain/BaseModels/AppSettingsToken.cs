using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoApp.Domain.BaseModels
{
    public class AppSettingsToken
    {
        public string Secret { get; set; }

        public string EncryptionKey { get; set; }
    }
}
