using Microsoft.EntityFrameworkCore;
using ToDoApi.Data;
using ToDoApi.DTOs;
using ToDoApi.Models;

namespace ToDoApi.Services;

public class TodoService : ITodoService
{
    private readonly AppDbContext _context;

    public TodoService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<TodoResponseDto>> GetAll()
    {
        return await _context.Todos
            .Select(t => new TodoResponseDto
            {
                Id = t.Id,
                Title = t.Title,
                IsCompleted = t.IsCompleted
            })
            .ToListAsync();
    }

    public async Task<TodoItem> Create(TodoDto todoDto)
    {
        var todo = new TodoItem
        {
            Title = todoDto.Title,
            IsCompleted = todoDto.IsCompleted
        };

        _context.Todos.Add(todo);
        await _context.SaveChangesAsync();

        return todo;
    }

    public async Task<TodoItem?> Update(int id, TodoDto updatedTodoDto) 
    {
        var todo = await _context.Todos.FirstOrDefaultAsync(t => t.Id == id);

        if (todo == null)
            return null;

        todo.Title = updatedTodoDto.Title;
        todo.IsCompleted = updatedTodoDto.IsCompleted;

        await _context.SaveChangesAsync();

        return todo;
    }
    public async Task<bool> Delete(int id) 
    {
        var todo = await _context.Todos.FirstOrDefaultAsync(t => t.Id == id);

        if (todo == null)
            return false;

        _context.Todos.Remove(todo);

        await _context.SaveChangesAsync();

        return true;
    }
}