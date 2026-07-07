using System.ComponentModel.DataAnnotations;

namespace ToDoApi.DTOs;

public class TodoDto
{
    [Required]
    [MinLength(3)]
    [MaxLength(100)]
    public string Title { get; set; } = "";
    public bool IsCompleted { get; set; }
}