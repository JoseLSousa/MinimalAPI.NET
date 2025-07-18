using Microsoft.AspNetCore.Mvc;
using MinimalAPI;
using MinimalAPI.DTOs;
using MinimalAPI.Interfaces;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddServiceDescriptors(builder.Configuration);
// Add services to the container.

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.MapPost("/api/auth/register", async (UserRepository repository, [FromBody] RegisterUserDto newUser) =>
{
    await repository.RegisterAsync(newUser);
    return Results.Created();
});

app.MapPost("/api/auth/login", async (UserRepository repository, [FromBody] LoginUserDto user) =>
{
    var token = await repository.LoginAsync(user);
    return Results.Ok(new { Token = token });
});

app.Run();
