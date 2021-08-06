using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoApp.ApiContract.Contracts
{
    public class ResponseBase<T> : ResponseBase
    {
        public T Data { get; set; }
    }
    public class ResponseBase
    {
        public bool Success { get; set; }
        public string MessageCode { get; set; }
        public string Message { get; set; }
        public string UserMessage { get; set; }
    }
}
