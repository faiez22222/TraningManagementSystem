using Microsoft.EntityFrameworkCore;
using BatchManagementService;
using BatchManagementService.Rrepositories;
using BatchManagementService.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<BatchManagementContext>(x =>
x.UseSqlServer("data source=DESKTOP-TIC5DM4\\SQLEXPRESS;Database=BatchManagementDB;Integrated Security=SSPI ; TrustServerCertificate=True;"));
builder.Services.AddScoped<IBatchRepository, BatchRepository>();
builder.Services.AddScoped<IBatchEnrollmentRepository,BatchEnrollmentRepository >();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseAuthorization();

app.MapControllers();

app.Run();
