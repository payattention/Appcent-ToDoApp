using System.ComponentModel.DataAnnotations;


namespace ToDoApp.ApiContract.Request.Query
{
    public class LoginQuery
    {
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
