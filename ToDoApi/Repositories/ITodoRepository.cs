using ToDoApi.Models;

namespace ToDoApi.Repositories;

public interface ITodoRepository
{
    Task<TodoItem?> GetById(int id);
    Task<List<TodoItem>> GetAll();
    Task<TodoItem> Create(TodoItem todo);
    Task<TodoItem?> Update(TodoItem todo);
    Task<bool> Delete(TodoItem todo);
}