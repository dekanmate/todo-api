using ToDoApi.DTOs;
using ToDoApi.Models;

namespace ToDoApi.Mappers
{
    public static class TodoMapper
    {
        public static ResponseTodoDto ToDto(this TodoItem todo)
        {
            return new ResponseTodoDto
            {
                Id = todo.Id,
                Title = todo.Title,
                IsCompleted = todo.IsCompleted
            };
        }
    }
}
