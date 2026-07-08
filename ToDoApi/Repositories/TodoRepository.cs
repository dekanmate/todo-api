using Microsoft.EntityFrameworkCore;
using ToDoApi.Data;
using ToDoApi.Models;

namespace ToDoApi.Repositories;

public class TodoRepository : ITodoRepository
{
    private readonly AppDbContext _context;

    public TodoRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<TodoItem?> GetById(int id)
    {
        return await _context.Todos.FirstOrDefaultAsync(t => t.Id == id);
    }

    public async Task<List<TodoItem>> GetAll()
    {
        return await _context.Todos.ToListAsync();
    }

    public async Task<TodoItem> Create(TodoItem todo)
    {
        _context.Todos.Add(todo);

        await _context.SaveChangesAsync();

        return todo;
    }

    public async Task<TodoItem?> Update(TodoItem todo)
    {
        _context.Todos.Update(todo);

        await _context.SaveChangesAsync();

        return todo;
    }

    public async Task<bool> Delete(TodoItem todo)
    {
        _context.Todos.Remove(todo);

        await _context.SaveChangesAsync();

        return true;
    }
}