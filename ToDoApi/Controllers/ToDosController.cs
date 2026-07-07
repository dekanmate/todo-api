using Microsoft.AspNetCore.Mvc;

using ToDoApi.Models;
using ToDoApi.DTOs;
using ToDoApi.Services;
using ToDoApi.Mappers;

namespace ToDoApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TodosController : ControllerBase
{
    private readonly ITodoService _todoService;

    public TodosController(ITodoService todoService)
    {
        _todoService = todoService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var todos = await _todoService.GetAll();

        return Ok(todos);
    }

    [HttpPost]
    public async Task<IActionResult> Create(TodoDto todoDto)
    {
        var todo = await _todoService.Create(todoDto);

        return Ok(todo.ToDto());
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, TodoDto updatedTodoDto)
    {
        var todo = await _todoService.Update(id, updatedTodoDto);

        return todo != null ? Ok(todo.ToDto()) : NotFound();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        bool deleted = await _todoService.Delete(id);

        return deleted ? NoContent() : NotFound();
    }
}