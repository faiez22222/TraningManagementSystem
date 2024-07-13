using Microsoft.EntityFrameworkCore;
using LoginService.Model;
using LoginService;
using System.Text;
using Microsoft.Extensions.Options;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using LoginService.Repositories;
using LoginService.Services;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
var jwtSetting = builder.Configuration.GetSection("Jwt");
var key = Encoding.UTF8.GetBytes(jwtSetting["Key"]);
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}
).AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = jwtSetting["Issuer"],
        ValidAudience = jwtSetting["Issuer"],
        IssuerSigningKey = new SymmetricSecurityKey(key)
    };
}
);
builder.Services.AddScoped<ILogin , LoginRepository>();
builder.Services.AddScoped<IUserValidationClient, UserValidationClient>();
builder.Services.AddHttpClient<UserValidationClient>();

builder.Services.AddDbContext<LoginContext>(x =>
x.UseSqlServer("data source=DESKTOP-TIC5DM4\\SQLEXPRESS;Database=UserManagementDB;Integrated Security=SSPI ; TrustServerCertificate=True;"));
var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseAuthorization();
app.UseAuthentication();

app.MapControllers();

app.Run();
