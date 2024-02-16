using System.ComponentModel.DataAnnotations;

namespace TaskMan.Models
{
    public class Task
    {
        [Key]
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public DateTime Created { get; set; }
        public bool Completed { get; set; }
        
    }
}
