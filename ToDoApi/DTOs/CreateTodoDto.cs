using System.ComponentModel.DataAnnotations;

namespace ToDoApi.DTOs;

public class CreateTodoDto
{
    [Required]
    [StringLength(100, MinimumLength = 3)]
    public required string Title { get; set; }
}