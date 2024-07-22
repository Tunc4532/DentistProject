using Dentist.Application.Interfaces;
using Dentist.Application.Services;
using Dentist.Persistance.Context;
using Dentist.Persistance.Repositories;
using Microsoft.AspNetCore.Hosting;
using System.Globalization;

var builder = WebApplication.CreateBuilder(args);
// Add services to the container.

builder.Services.AddScoped<AppDbContext>();
builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

builder.Services.AddApplicationService(builder.Configuration);
builder.Services.AddHttpContextAccessor();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
