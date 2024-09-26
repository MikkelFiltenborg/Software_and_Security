using Microsoft.EntityFrameworkCore;

namespace SoftwareTest_and_Security.Models
{
    public class ToDoContext : DbContext
    {
        public ToDoContext(DbContextOptions<ToDoContext> options) : base(options) {}

        public DbSet<CprNr> CprNr { get; set; }
        public DbSet<ToDo> ToDoList { get; set; }
    }
}
