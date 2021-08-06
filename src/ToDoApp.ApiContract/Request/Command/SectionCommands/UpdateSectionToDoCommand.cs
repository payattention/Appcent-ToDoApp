using System.ComponentModel.DataAnnotations;

namespace ToDoApp.ApiContract.Request.Command.SectionCommands
{
    public class UpdateSectionToDoCommand
    {
        [Required]
        public int SectionId { get; set; }
        [Required]
        public string SectionName { get; set; }
    }
}
