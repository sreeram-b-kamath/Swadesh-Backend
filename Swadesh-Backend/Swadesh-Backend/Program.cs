using Application.Helpers;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using Shared.Data;
using Application.Services;
using System;
/*using Application.Services.EMailService;*/
using Interface.EmailService;
using Application.Interface;
using ComplianceCalendar.Services.EmailService;
using Swadesh_Backend;
using Microsoft.AspNetCore.Identity;
using Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAutoMapper(typeof(MappingConfig));
/*builder.Services.AddScoped<IRegisterService, RegisterService>();*/
builder.Services.AddScoped<IEmailSender, EmailSender>();
/*builder.Services.AddScoped<IEmailService, EmailService>();*/

DotNetEnv.Env.Load();

var emailUsername = Environment.GetEnvironmentVariable("EMAIL_USERNAME");
var emailPassword = Environment.GetEnvironmentVariable("EMAIL_PASSWORD");
var emailHost = Environment.GetEnvironmentVariable("EMAIL_HOST");
var emailPort = int.Parse(Environment.GetEnvironmentVariable("EMAIL_PORT"));

// Configure email settings using Options pattern
builder.Services.Configure<EmailSettings>(options =>
{
    options.SenderEmail = emailUsername;
    options.SenderPassword = emailPassword;
    options.SmtpServer = emailHost;
    options.SmtpPort = emailPort;
});

var connectionString = Environment.GetEnvironmentVariable("POSTGRESQL_CONNECTION_STRING");

builder.Services.AddDbContext<ApplicationDBContext>(options =>
{
    options.UseNpgsql(connectionString);
});

builder.Services.AddIdentity<User, IdentityRole<int>>()
        .AddEntityFrameworkStores<ApplicationDBContext>()
        .AddDefaultTokenProviders();

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
