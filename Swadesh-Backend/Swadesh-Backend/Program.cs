using Application.Helpers;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Shared.Data;
using System.Text;
using Application.Services;
using Application.Services.EMailService;
using Interface.EmailService;
using Application.Interface;
using ComplianceCalendar.Services.EmailService;
using Models;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.Text.Json.Serialization;
using DotNetEnv;
using Microsoft.AspNetCore.Identity;
using Swadesh_Backend;
using System.Text.Json.Serialization;

// Load environment variables
Env.Load();

var builder = WebApplication.CreateBuilder(args);




builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.IgnoreCycles;
});
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();
builder.Services.AddAutoMapper(typeof(MappingConfig));

builder.Services.AddScoped<IRegisterService, RegisterService>();
builder.Services.AddScoped<IEmailSender, EmailSender>();
builder.Services.AddScoped<IEmailService, EmailService>();
builder.Services.AddScoped<ILoginService, LoginService>();
builder.Services.AddScoped<IRestaurantService, RestaurantService>();
builder.Services.AddScoped<IMenuItemService, MenuItemService>();
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<IMenuItemService, MenuItemService>();
builder.Services.AddScoped<IMenuFilterService, MenuFilterService>();
builder.Services.AddScoped<IIngredientsService, IngredientsService>();
builder.Services.AddScoped<IRestrictionService, RestrictionService>();


// Environment variables for email configuration
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

// Configure PostgreSQL connection
var connectionString = Environment.GetEnvironmentVariable("POSTGRESQL_CONNECTION_STRING");
builder.Services.AddDbContext<ApplicationDBContext>(options =>
{
    options.UseNpgsql(connectionString);
});

// Configure Identity services
builder.Services.AddIdentity<User, IdentityRole<int>>()
        .AddEntityFrameworkStores<ApplicationDBContext>()
        .AddDefaultTokenProviders();

// CORS Policy
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowLocalhost",
        builder => builder
            .AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader());
});

var jwtKey = builder.Configuration["Jwt:Key"];
var jwtIssuer = builder.Configuration["Jwt:Issuer"];
var jwtAudience = builder.Configuration["Jwt:Audience"];
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = jwtIssuer,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtKey))
    };
});

// Add authorization
builder.Services.AddAuthorization();

var app = builder.Build();

// Configure the HTTP request pipeline
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Enable CORS policy
app.UseCors("AllowLocalhost");

// Enable authentication and authorization middleware
app.UseHttpsRedirection();
app.UseAuthentication(); // Enable authentication
app.UseAuthorization();  // Enable authorization

app.MapControllers();

app.Run();
