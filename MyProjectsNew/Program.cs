
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using MyProjectsNew.Data;
using System.Numerics;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
//builder.Services.AddOpenApi();

builder.Services.AddEndpointsApiExplorer();  // etelate endpoint ha ro exteract kone
//be swagger mige bia ui sho generate kon
builder.Services.AddSwaggerGen( options =>  //commentGozari 
{
    options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, "PersonAPI.xml"));
});  
builder.Services.AddDbContext<DataContext>(Option =>
{
    Option.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwagger();
    app.UseSwaggerUI();

}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
