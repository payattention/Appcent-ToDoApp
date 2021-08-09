using System.ComponentModel.DataAnnotations;

namespace ToDoApp.ApplicationService.Communicator.ToDo.Model
{
    public class UpdateToDoRequestModel
    {
        [Required]
        public string ToDoId { get; set; }
        [Required]
        public string UserName { get; set; }
        public string ToDo { get; set; }
        public ToDoState ToDoState { get; set; }
        public ToDoPrimacy ToDoPrimacy { get; set; }
    }
}
