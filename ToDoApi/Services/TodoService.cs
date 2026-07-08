using ToDoApi.DTOs;
using ToDoApi.Mappers;
using ToDoApi.Models;
using ToDoApi.Repositories;

namespace ToDoApi.Services;

public class TodoService : ITodoService
{
    private readonly ITodoRepository _repository;

    public TodoService(ITodoRepository repository)
    {
        _repository = repository;
    }

    public async Task<ResponseTodoDto?> GetById(int id)
    {
        var todo = await _repository.GetById(id);

        return todo?.ToDto();
    }

    public async Task<List<ResponseTodoDto>> GetAll()
    {
        var todos = await _repository.GetAll();

        return todos.Select(t => t.ToDto()).ToList();
    }

    public async Task<ResponseTodoDto> Create(CreateTodoDto todoDto)
    {
        var todo = new TodoItem
        {
            Title = todoDto.Title,
            IsCompleted = false
        };

        var createdTodo = await _repository.Create(todo);

        return createdTodo.ToDto();
    }

    public async Task<ResponseTodoDto?> Update(int id, UpdateTodoDto updatedTodoDto)
    {
        var todo = await _repository.GetById(id);

        if (todo == null)
            return null;

        todo.Title = updatedTodoDto.Title;
        todo.IsCompleted = updatedTodoDto.IsCompleted;

        await _repository.Update(todo);

        return todo.ToDto();
    }

    public async Task<bool> Delete(int id)
    {
        var todo = await _repository.GetById(id);

        if (todo == null)
            return false;

        return await _repository.Delete(todo);
    }
}