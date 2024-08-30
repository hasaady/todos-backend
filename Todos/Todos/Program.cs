using Todos.Application.Interfaces.Repositories;
using Todos.Infrastrucutre.Respositories;
using Utility.Providers;
using Todos.Infrastrucutre.Migrations;
using Todos.Infrastrucutre.Database;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen();

builder.Services
    .AddSingleton<ITodosDbContext, TodosDbContext>()
    .AddTransient<ITodosRepository, TodosRepository>()
    .AddSingleton<ISQLQueryProvider, SQLQueryProvider>();

builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(Program).Assembly));

builder.Services.AddMemoryCache();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

DbMigrator.Migrate(builder.Configuration);

app.Run();
