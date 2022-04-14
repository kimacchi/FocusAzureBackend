using Microsoft.EntityFrameworkCore;
using FocusApi.Models;
// using Microsoft.AspNetCore.Mvc;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// builder.Services.AddControllers().AddNewtonsoftJson();
builder.Services.AddDbContext<ActivityContext>(opt =>
    opt.UseInMemoryDatabase("ActivityList"));
builder.Services.AddDbContext<UserContext>(opt =>
    opt.UseInMemoryDatabase("UserList"));
builder.Services.AddDbContext<ProjectContext>(opt =>
    opt.UseInMemoryDatabase("ProjectList"));
//builder.Services.AddSwaggerGen(c =>
//{
//    c.SwaggerDoc("v1", new() { Title = "TodoApi", Version = "v1" });
//});


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
// builder.Services.AddEndpointsApiExplorer();
// builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    // app.UseSwagger();
    // app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
