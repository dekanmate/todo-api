using Microsoft.AspNetCore.Mvc;
using ToDoApi.DTOs;
using ToDoApi.Models;

namespace ToDoApi.Services
{
    public interface ITodoService
    {
        public Task<List<TodoResponseDto>> GetAll();
        public Task<TodoItem> Create(TodoDto todoDto);
        public Task<TodoItem?> Update(int id, TodoDto updatedTodoDto);
        public Task<bool> Delete(int id);
    }
}
