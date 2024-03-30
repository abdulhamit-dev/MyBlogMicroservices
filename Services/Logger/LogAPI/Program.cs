
using ContentAPI.Services;
using Microsoft.Extensions.Logging;
using RabbitMQ.Client;
using Serilog;
using Serilog.Events;

var builder = WebApplication.CreateBuilder(args);

Log.Logger = new LoggerConfiguration()
    .WriteTo.Console()
    .WriteTo.Seq(builder.Configuration["LogDb"])
    .CreateLogger();

builder.Services.AddLogging(loggingBuilder =>
   {
       loggingBuilder.AddSeq();
   });


builder.Services.AddSingleton(sp => new ConnectionFactory()
{
    HostName = builder.Configuration["RabbitMQ"],
    UserName = "guest",
    Password = "guest"
});

builder.Services.AddHostedService<LogBackgroundService>();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
