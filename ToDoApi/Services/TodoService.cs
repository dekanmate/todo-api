using Microsoft.EntityFrameworkCore;
using ToDoApi.Data;
using ToDoApi.DTOs;
using ToDoApi.Mappers;
using ToDoApi.Models;

namespace ToDoApi.Services;

public class TodoService : ITodoService
{
    private readonly AppDbContext _context;

    public TodoService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<ResponseTodoDto?> GetById(int id)
    {
        return await _context.Todos
            .Where(t => t.Id == id)
            .Select(t => new ResponseTodoDto
            {
                Title = t.Title,
                IsCompleted = t.IsCompleted
            })
            .FirstOrDefaultAsync();
    }

    public async Task<List<ResponseTodoDto>> GetAll()
    {
        return await _context.Todos
            .Select(t => new ResponseTodoDto
            {
                Id = t.Id,
                Title = t.Title,
                IsCompleted = t.IsCompleted
            })
            .ToListAsync();
    }

    public async Task<ResponseTodoDto> Create(CreateTodoDto todoDto)
    {
        var todo = new TodoItem
        {
            Title = todoDto.Title,
            IsCompleted = false
        };

        _context.Todos.Add(todo);
        await _context.SaveChangesAsync();

        return todo.ToDto();
    }

    public async Task<ResponseTodoDto?> Update(int id, UpdateTodoDto updatedTodoDto) 
    {
        var todo = await _context.Todos.FirstOrDefaultAsync(t => t.Id == id);

        if (todo == null)
            return null;

        todo.Title = updatedTodoDto.Title;
        todo.IsCompleted = updatedTodoDto.IsCompleted;

        await _context.SaveChangesAsync();

        return todo.ToDto();
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