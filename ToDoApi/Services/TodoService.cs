using ToDoApi.DTOs;
using ToDoApi.Mappers;
using ToDoApi.Models;
using ToDoApi.Repositories;
using ToDoApi.Exceptions;

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
        TodoItem? todo = await _repository.GetById(id);

        if (todo == null)
            throw new NotFoundException($"Todo with id {id} not found.");

        return todo.ToDto();
    }

    public async Task<List<ResponseTodoDto>> GetAll()
    {
        List<TodoItem> todos = await _repository.GetAll();

        return todos.Select(t => t.ToDto()).ToList();
    }

    public async Task<ResponseTodoDto> Create(CreateTodoDto todoDto)
    {
        var todo = new TodoItem
        {
            Title = todoDto.Title,
            IsCompleted = false
        };

        TodoItem createdTodo = await _repository.Create(todo);

        return createdTodo.ToDto();
    }

    public async Task<ResponseTodoDto?> Update(int id, UpdateTodoDto updatedTodoDto)
    {
        var todo = await _repository.GetById(id);

        if (todo == null)
            throw new NotFoundException($"Todo with id {id} not found.");

        todo.Title = updatedTodoDto.Title;
        todo.IsCompleted = updatedTodoDto.IsCompleted;

        await _repository.Update(todo);

        return todo.ToDto();
    }

    public async Task<bool> Delete(int id)
    {
        TodoItem? todo = await _repository.GetById(id);

        if (todo == null)
            throw new NotFoundException($"Todo with id {id} not found.");

        return await _repository.Delete(todo);
    }
}