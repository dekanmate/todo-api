namespace ToDoApi.DTOs;

public class ResponseTodoDto
{
    public int Id { get; set; }
    public required string Title { get; set; }
    public bool IsCompleted { get; set; }
}