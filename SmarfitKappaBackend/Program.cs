using SmurfitKappaBackend.Data;
using SmurfitKappaBackend.Repositories;
using SmurfitKappaBackend.Services;
using Microsoft.EntityFrameworkCore;
using SmarfitKappaBackend.Models;
using SmarfitKappaBackend.Interfaces;
using SmarfitKappaBackend.Interfaces.SmurfitKappaBackend.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddSwaggerGen();
builder.Services.AddCors(option =>
{
    option.AddPolicy("AllowAnyOrigin", builder =>
    {
        builder.WithOrigins("http://localhost:4200", "http://192.168.31.1:4200")
               .AllowAnyHeader()
               .AllowCredentials()
               .AllowAnyMethod();
    });
});

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(connectionString));



builder.Services.AddTransient<IUserService, UserService>();
builder.Services.AddTransient<IUser, User>();
builder.Services.AddTransient<IUserRepository, UserRepository>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseHsts();
    app.UseSwaggerUI();
    app.UseCors("AllowAnyOrigin");

    using (var scope = app.Services.CreateScope())
    {
        var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();
        dbContext.Database.EnsureCreated();
    }
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();