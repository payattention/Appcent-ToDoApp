using System.Collections.Generic;
using ToDoApp.ApiContract.Contracts;

namespace ToDoApp.ApiContract.Response.Query
{
    public class GetToDoQueryResult : ResponseBase
    {
        public ToDoModel TodoObj { get; set; }
        public IEnumerable<ToDoModel> ToDoList { get; set; }

        public bool IsToDoList { get; set; } // For Frontend. With this flag, they will know how many to-do in response and they dont need to check TodoList is empty or not.
    }
}
