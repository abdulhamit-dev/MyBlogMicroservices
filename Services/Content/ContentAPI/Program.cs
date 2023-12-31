﻿
using System.Text;
using AOPSample.Autofac;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using ContentAPI.DependencyResolvers;
using ContentAPI.Extensions;
using ContentAPI.IoC;
using ContentAPI.Models.Settings;
using ContentAPI.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using RabbitMQ.Client;

var builder = WebApplication.CreateBuilder(args);

//autofac conf
builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());
builder.Host.ConfigureContainer<ContainerBuilder>(builder => builder.RegisterModule(new AutofacBusinessModule()));
//

builder.Services.AddAutoMapper(typeof(Program));
builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(builder.Configuration["SigningKey"])),
            ValidateIssuer = false,
            ValidateAudience = false,
            ValidateLifetime = true
        };
    });
    
builder.Services.AddSingleton(sp => new ConnectionFactory()
{
    HostName = "localhost",
    UserName = "guest",
    Password = "guest"
});

builder.Services.AddAuthorization(options =>
{
    options.DefaultPolicy = new AuthorizationPolicyBuilder().RequireAuthenticatedUser().Build();
});
// builder.Services.AddHostedService<ContentBackgroundService>();
// builder.Services.AddHostedService<ReactionBackgroundService>();
// builder.Services.AddSingleton<IContentService,ContentService>();
// builder.Services.AddSingleton<ILogService,LogService>();

// builder.Services.Configure<DatabaseSettings>(builder.Configuration.GetSection("DatabaseSettings"));
// builder.Services.AddSingleton<IDatabaseSettings>(sp =>
// {
//     return sp.GetRequiredService<IOptions<DatabaseSettings>>().Value;
// });


builder.Services.AddDependencyResolvers(new ICoreModule[]
            {
                new CoreModule(),
            });

var app = builder.Build();

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

