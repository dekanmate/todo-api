using Microsoft.AspNetCore.Mvc;
using ToDoApi.DTOs;
using ToDoApi.Models;

namespace ToDoApi.Services
{
    public interface ITodoService
    {
        public Task<ResponseTodoDto?> GetById(int id);
        public Task<List<ResponseTodoDto>> GetAll();
        public Task<ResponseTodoDto> Create(CreateTodoDto todoDto);
        public Task<ResponseTodoDto?> Update(int id, UpdateTodoDto updatedTodoDto);
        public Task<bool> Delete(int id);
    }
}
