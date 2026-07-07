using ToDoApi.DTOs;
using ToDoApi.Models;

namespace ToDoApi.Mappers
{
    public static class TodoMapper
    {
        public static TodoResponseDto ToDto(this TodoItem todo)
        {
            return new TodoResponseDto
            {
                Id = todo.Id,
                Title = todo.Title,
                IsCompleted = todo.IsCompleted
            };
        }
    }
}
