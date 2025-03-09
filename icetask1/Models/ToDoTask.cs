using System.ComponentModel.DataAnnotations;

namespace icetask1.Models
{
    public class ToDoTask
    {
        //task identifier
        public int Id { get; set; }

        //required field - title of task
        [Required]
        public string Title { get; set; }

        //task description to further explain task
        public string Description { get; set; }

        //task due date
        [DataType(DataType.Date)]
        public DateTime DueDate { get; set; }

        //boolean for whether task is completed or not
        public bool IsCompleted { get; set; }
    }
}
