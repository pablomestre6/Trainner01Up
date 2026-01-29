using Microsoft.EntityFrameworkCore;
using Project001.Infra.MySql.Contexts;
using Project001.Infra.MySql.Repositories;
using Project001.Domain.Interfaces;
using Project001.Domain.Services;

var builder = WebApplication.CreateBuilder(args);

// =======================
// Controllers & Swagger
// =======================
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// =======================
// Database - MySQL / MariaDB
// =======================
var connectionString = builder.Configuration.GetConnectionString("Default");

builder.Services.AddDbContext<MySqlContext>(options =>
{
    options.UseMySql(
        connectionString,
        // ⚠️ Ajuste a versão conforme seu MariaDB/MySQL
        new MariaDbServerVersion(new Version(10, 6, 16))
    );
});

// =======================
// Dependency Injection
// =======================
builder.Services.AddScoped<IContatoDomainService, ContatoDomainServices>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

// =======================
// Build App
// =======================
var app = builder.Build();

// =======================
// Pipeline
// =======================
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
