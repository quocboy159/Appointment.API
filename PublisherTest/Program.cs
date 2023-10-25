using MassTransit;
using Microsoft.Extensions.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var uri = builder.Configuration.GetSection("RabbitMqSettings")["Uri"];
var userName = builder.Configuration.GetSection("RabbitMqSettings")["UserName"];
var password = builder.Configuration.GetSection("RabbitMqSettings")["Password"];
builder.Services.AddMassTransit(x =>
{
    x.SetKebabCaseEndpointNameFormatter();

    x.UsingRabbitMq((context, config) =>
    {
        config.Host(uri, "/", c =>
        {
            c.Username(userName);
            c.Password(password);
        });

        config.ConfigureEndpoints(context);
    });

});

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
