using Infractructure.Data;
using Domain.Interface;
using Infractructure.Services;
using Microsoft.EntityFrameworkCore;
using AerolineaW.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.GetDependencyInjections();

builder.Services.AddControllers().AddNewtonsoftJson(options =>
    {
        options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
    });
    // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();

    //Esto es para la inyeccion de los datos  
    builder.Services.AddDbContext<DataBase>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("AirplaneApiConnectionString")));


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
