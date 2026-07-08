using System.ComponentModel.DataAnnotations;

namespace ToDoApi.DTOs;

public class UpdateTodoDto
{
    [Required]
    [StringLength(100, MinimumLength = 3)]
    public required string Title { get; set; }
    public bool IsCompleted { get; set; }
}