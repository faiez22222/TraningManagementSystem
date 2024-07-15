using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using System.Reflection;
using FeedbackAndAssessmentService;
using FeedbackAndAssessmentService.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<FeedbackContext>(x =>
x.UseSqlServer("data source=DESKTOP-TIC5DM4\\SQLEXPRESS;Database=FeedbackDB;Integrated Security=SSPI ; TrustServerCertificate=True;"));
builder.Services.AddScoped<IFeedbackRepository  , Feedbackrepository>();
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
