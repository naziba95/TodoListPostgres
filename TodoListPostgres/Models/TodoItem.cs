using System.ComponentModel.DataAnnotations;

namespace TodoListPostgres.Models
{
    public class TodoItem
    {
        [Key]
        public int Id { get; set; }
        public string? Title { get; set; }
        public bool? IsComplete { get; set; }
    }
}
