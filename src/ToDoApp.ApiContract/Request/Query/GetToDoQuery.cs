using System.ComponentModel.DataAnnotations;

namespace ToDoApp.ApiContract.Request.Query
{
    public class GetToDoQuery
    {
        [Required]
        public string UserName { get; set; }
        [Required]
        public int TaskId { get; set; }
    }
}
