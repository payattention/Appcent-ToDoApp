using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoApp.ApiContract.Contracts
{
    public class InsertToDoDto
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public int SectionId { get; set; }
        public ToDoState TaskState { get; set; }
        public ToDoPrimacy TaskPrimacy { get; set; }
        public int MainTaskId { get; set; }
       
    }
}
