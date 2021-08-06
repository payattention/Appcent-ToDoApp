using System.ComponentModel.DataAnnotations;


namespace ToDoApp.ApiContract.Request.Command.ToDoCommands
{
    public class DeleteToDoCommand
    {
        [Required]
        public int TodoId { get; set; }
        [Required]
        public string UserName { get; set; }
    }
}
