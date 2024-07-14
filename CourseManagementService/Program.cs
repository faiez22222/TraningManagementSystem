using Microsoft.EntityFrameworkCore;
using CourseManagementService;
using CourseManagementService.Repositories.CourseRepository;
using CourseManagementService.Repositories.CourseCalendarRepository;
using CourseManagementService.Repositories.DailyTaskRepository;
using CourseManagementService.Services.CourseService;
using CourseManagementService.Services.CourseCalendarService;
using CourseManagementService.Services.DailyTaskService;

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



var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseAuthorization();

app.MapControllers();

app.Run();
