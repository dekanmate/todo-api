using Microsoft.EntityFrameworkCore;
using ToDoApi.Data;
using ToDoApi.Services;

var builder = WebApplication.CreateBuilder(args);

// Services to the container.
builder.Services.AddControllers();
builder.Services.AddScoped<ITodoService, TodoService>();

// Configure SQLite database
builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlite("Data Source=todo.db"));

// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

// Swagger configuration
builder.Services.AddSwaggerGen();
builder.Services.AddEndpointsApiExplorer();

// Build the app.
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    // Configure the HTTP request pipeline.
    app.MapOpenApi();

    // Configure Swagger UI in development environment
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
