using System.Security.Claims;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using PolicyCors1011.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlite("Data Source=data.db");
});

builder.Services.AddIdentity<IdentityUser, IdentityRole>(options =>
{
    options.Password.RequireDigit = false;
    options.Password.RequireLowercase = false;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequireUppercase = false;
}).AddEntityFrameworkStores<AppDbContext>();

builder.Services.AddAuthorization(option =>
{
    option.AddPolicy("GetDataByPolicy", policyoption =>
    {
        policyoption
            .RequireClaim("UserAge", "18")
            .RequireClaim(ClaimTypes.Role, "User");
    });
});

builder.Services.AddCors(option =>
{
    option.AddPolicy("FrontEnd", cor =>
    {
        cor.WithHeaders()
            .WithOrigins("https://localhost:7029")
            .WithMethods("GET", "POST");
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors("FrontEnd");

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
