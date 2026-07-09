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
    [ProducesResponseType(typeof(ResponseTodoDto), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ErrorResponseDto), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetById(int id)
    {
        var responseTodo = await _todoService.GetById(id);

        return Ok(responseTodo);
    }

    [HttpGet]
    [ProducesResponseType(typeof(List<ResponseTodoDto>), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetAll()
    {
        var responseTodos = await _todoService.GetAll();

        return Ok(responseTodos);
    }

    [HttpPost]
    [ProducesResponseType(typeof(ResponseTodoDto), StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
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
    [ProducesResponseType(typeof(ResponseTodoDto), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ErrorResponseDto), StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Update(int id, UpdateTodoDto updatedTodoDto)
    {
        var responseTodo = await _todoService.Update(id, updatedTodoDto);

        return Ok(responseTodo);
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(typeof(ErrorResponseDto), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(int id)
    {
        bool deleted = await _todoService.Delete(id);

        return NoContent();
    }
}