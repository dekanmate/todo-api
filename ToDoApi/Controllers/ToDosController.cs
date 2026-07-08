using Microsoft.AspNetCore.Mvc;

using ToDoApi.DTOs;
using ToDoApi.Services;

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

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetById(int id)
    {
        var responseTodo = await _todoService.GetById(id);

        return responseTodo != null ? Ok(responseTodo) : NotFound();
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var responseTodos = await _todoService.GetAll();

        return Ok(responseTodos);
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateTodoDto todoDto)
    {
        var responseTodo = await _todoService.Create(todoDto);

        return CreatedAtAction(
            nameof(GetById),
            new { id = responseTodo.Id },
            responseTodo
        );
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, UpdateTodoDto updatedTodoDto)
    {
        var responseTodo = await _todoService.Update(id, updatedTodoDto);

        return responseTodo != null ? Ok(responseTodo) : NotFound();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        bool deleted = await _todoService.Delete(id);

        return deleted ? NoContent() : NotFound();
    }
}