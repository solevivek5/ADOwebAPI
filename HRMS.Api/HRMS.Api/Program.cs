using AutoMapper;
using HRMS.Api;
using HRMS.Api.Auth;
using HRMS.Api.Employees;
using HRMS.Core.Mappings;
using HRMS.Entities.DbContexts;
using HRMS.Interfaces.Auth;
using HRMS.Interfaces.Employees;
using HRMS.Repositories.Auth;
using HRMS.Repositories.EmployeeRepo;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Swashbuckle.AspNetCore.Filters;
using HRMS.Api.Organization;
using HRMS.Interfaces.Organization;
using HRMS.Repositories.Organization;

using HRMS.Api.Area.Master;
using HRMS.Interfaces.Masters;
using HRMS.Repositories.Masters;

var allowableOrigins = "_myAllowSpecificOrigins";
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddDbContext<HRMSContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DbConnection"));
});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

//Swagger Implementation
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Vivek Singh Kushwaha", Version = "v1" });
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Description = @"JWT Authorization header using the Bearer scheme. Enter 'Bearer' [space] and then your token in the text input below. Example: 'Bearer 12345abcdef'",
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer"
    });
    c.AddSecurityRequirement(new OpenApiSecurityRequirement() {
        {
           new OpenApiSecurityScheme
              {
                 Reference = new OpenApiReference
                 {
                   Type = ReferenceType.SecurityScheme,
                   Id = "Bearer"
                 },
                 Scheme = "oauth2",
                 Name = "Bearer",
                 In = ParameterLocation.Header,
              },
            new List<string>()
        } 
    });
});

// Adding Authentication
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
})

// Adding Jwt Bearer
.AddJwtBearer(options =>
{
    options.SaveToken = false;
    options.RequireHttpsMetadata = false;
    options.TokenValidationParameters = new TokenValidationParameters()
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidAudience = builder.Configuration.GetSection("AppSettings:ValidAudience").Value,
        ValidIssuer = builder.Configuration.GetSection("AppSettings:ValidIssuer").Value,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration.GetSection("AppSettings:Token").Value))
    };
});

//Enable CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: allowableOrigins,
        builder =>
        {
            builder.WithOrigins("http://localhost:4200")
            .AllowAnyMethod()
            .AllowAnyHeader()
            .AllowCredentials();
        });
});

//Controller Auto Mapper
builder.Services.AddAutoMapper(typeof(EmployeeController).Assembly);
builder.Services.AddTransient<IEmployee, EmployeeRepo>();

builder.Services.AddAutoMapper(typeof(AuthController).Assembly);
builder.Services.AddTransient<IAuth, AuthRepo>();

builder.Services.AddAutoMapper(typeof(DepartmentController).Assembly);
builder.Services.AddTransient<IDepartment, DepartmentRepo>();

builder.Services.AddAutoMapper(typeof(TermController).Assembly);
builder.Services.AddTransient<ITerm, TermRepo>();

//Automapper
builder.Services.AddAutoMapper(typeof(Program).Assembly);
builder.Services.AddControllersWithViews();

//Auto Mapper Profile Configuration
var mappingConfig = new MapperConfiguration(mc =>
{
    mc.AddProfile(new AutoMapperProfiles());
});
IMapper mapper = mappingConfig.CreateMapper();
builder.Services.AddSingleton(mapper);


builder.Services.AddEndpointsApiExplorer();

builder.Services.AddMemoryCache();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors(allowableOrigins);
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.Run();