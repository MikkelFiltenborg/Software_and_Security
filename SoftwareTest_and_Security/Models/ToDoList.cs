using System.ComponentModel.DataAnnotations;

namespace SoftwareTest_and_Security.Models
{
    public class ToDoList
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        public string Desc { get; set; }
    }
}
