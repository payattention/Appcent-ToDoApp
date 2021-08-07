using MediatR;
using System.ComponentModel.DataAnnotations;

namespace ToDoApp.ApiContract.Request.Command.SectionCommands
{
    public class InsertSectionToDoCommand : IRequest
    {
        [Required]
        public string SectionName { get; set; }
    }
}
