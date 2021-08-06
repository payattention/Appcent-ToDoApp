using System.ComponentModel.DataAnnotations;
using ToDoApp.ApiContract.Contracts;

namespace ToDoApp.ApiContract.Request.Command.ToDoCommands
{
    public class UpdateToDoCommand
    {
        [Required]
        public int TaskId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public int SectionId { get; set; }
        public int MainTaskId { get; set; }
        [Required]
        public ToDoState ToDoState { get; set; }
        [Required]
        public ToDoPrimacy ToDoPriority { get; set; }
        
    }
}
