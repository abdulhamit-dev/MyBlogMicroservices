
using RabbitMQ.Client;
using TextSearchAPI.Extensions;
using TextSearchAPI.Models;
using TextSearchAPI.Repository;
using TextSearchAPI.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAutoMapper(typeof(Program));
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddElastic(builder.Configuration);
builder.Services.AddSingleton<IContentService,ContentService>();
builder.Services.AddSingleton<ContentRepository>();
builder.Services.AddHostedService<ContentBackgroundService>();

builder.Services.AddSingleton(sp => new ConnectionFactory()
{
    HostName = builder.Configuration["RabbitMQ"],
    UserName = "guest",
    Password = "guest"
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
