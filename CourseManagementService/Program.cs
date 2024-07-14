using Microsoft.EntityFrameworkCore;
using CourseManagementService;
using CourseManagementService.Repositories.CourseRepository;
using CourseManagementService.Repositories.CourseCalendarRepository;
using CourseManagementService.Repositories.DailyTaskRepository;
using CourseManagementService.Services.CourseService;
using CourseManagementService.Services.CourseCalendarService;
using CourseManagementService.Services.DailyTaskService;
using Microsoft.OpenApi.Models;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<CourseManagementContext>(x =>
x.UseSqlServer("data source=DESKTOP-TIC5DM4\\SQLEXPRESS;Database=CourseManagementDB;Integrated Security=SSPI ; TrustServerCertificate=True;"));
builder.Services.AddScoped<ICourseRepository, CourseRepository>();
builder.Services.AddScoped<ICourseCalendarRepository , CourseCalendarRepository>();
builder.Services.AddScoped<IDailyTaskRepository, DailyTaskRepository>();
builder.Services.AddScoped<ICourseService, CourseService>();
builder.Services.AddScoped<ICourseCalendarService , CourseCalendarService>();
builder.Services.AddScoped<IDailyTaskService, DailyTaskService>();
builder.Services.AddSwaggerGen(
    c =>
    {
        c.SwaggerDoc("v1", new OpenApiInfo { Title = "Your api name", Version = "v1" });
        var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";

        var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    }
    );



var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Your Api Name V1"));
}

// Configure the HTTP request pipeline.

app.UseAuthorization();

app.MapControllers();

app.Run();
