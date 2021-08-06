using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoApp.ApiContract.Contracts
{
    public class UpdateToDoDto
    {
        [Required]
        public int TaskId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public int SectionId { get; set; }
        [Required]
        public ToDoState TaskState { get; set; }
        [Required]
        public ToDoPrimacy TaskPriority { get; set; }
        public int MainTaskId { get; set; }
        
    }
}
