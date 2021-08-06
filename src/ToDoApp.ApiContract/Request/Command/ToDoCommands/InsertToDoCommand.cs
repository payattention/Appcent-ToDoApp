using System.ComponentModel.DataAnnotations;
using ToDoApp.ApiContract.Contracts;

namespace ToDoApp.ApiContract.Request.Command.ToDoCommands
{
    public class InsertToDoCommand
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string UserName { get; set; }
        [Required]
        public int SectionId { get; set; }
        public int MainTaskId { get; set; }
        public ToDoState ToDoState { get; set; }
        public ToDoPrimacy ToDoPrimacy { get; set; }
        
    }
}
