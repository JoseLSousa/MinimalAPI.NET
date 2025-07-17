using MinimalAPI;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddServiceDescriptors(builder.Configuration);
// Add services to the container.

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.Run();

