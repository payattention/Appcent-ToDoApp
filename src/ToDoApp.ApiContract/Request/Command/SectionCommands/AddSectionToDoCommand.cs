using System.ComponentModel.DataAnnotations;

namespace ToDoApp.ApiContract.Request.Command.SectionCommands
{
    public class AddSectionToDoCommand
    {
        [Required]
        public string SectionName { get; set; }
    }
}
