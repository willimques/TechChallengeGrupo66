using Microsoft.Extensions.Configuration;
using Infra.Cross.Cutting;
using Microsoft.AspNetCore.Rewrite;
using Microsoft.OpenApi.Models;
using Microsoft.Extensions.Options;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

var configuration = builder.Configuration;

// Add services to the container.

var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.EnableAnnotations();
    c.SwaggerDoc("v1", new OpenApiInfo {
        Title = "TechChallenge Grupo 66",
        Description = "Projeto desenvolvido para entrega do TechChallange do grupo 66 - Fase 1",
        Version = "v1" 
    });
});




builder.Services.AddProjectDependencies(configuration);

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

app.Run();
