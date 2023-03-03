using System.ComponentModel.DataAnnotations;

namespace ToDoList.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(20)]
        [Required]
        public string Name { get; set; }
        public ICollection<Todo> Tasks { get; set; }
    }
}
