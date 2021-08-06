using System.ComponentModel.DataAnnotations;


namespace ToDoApp.ApiContract.Request.Command.SectionCommands
{
    public class DeleteSectionToDoCommand
    {
        [Required]
        public int SectionId { get; set; }
    }
}
