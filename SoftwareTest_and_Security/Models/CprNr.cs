using System.ComponentModel.DataAnnotations;

namespace SoftwareTest_and_Security.Models
{
    public class CprNr
    {
        [Key]
        public int Id { get; set; }
        public string? UserName { get; set; }
        public string? Cprnr { get; set; }
        public List<ToDoList> toDoList { get; set; }
    }
}
