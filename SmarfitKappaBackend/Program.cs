using SmurfitKappaBackend.Data;
using SmurfitKappaBackend.Repositories;
using SmurfitKappaBackend.Services;
using Microsoft.EntityFrameworkCore;
using SmarfitKappaBackend.Models;
using SmarfitKappaBackend.Interfaces;
using SmarfitKappaBackend.Interfaces.SmurfitKappaBackend.Repositories;

var builder = WebApplication.CreateBuilder(args);
string cors = "ConfigurateCors";

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddSwaggerGen();
builder.Services.AddCors(option =>
{
    option.AddPolicy(name: cors, builder =>
    {
        builder.WithMethods("*");
        builder.WithOrigins("*");
        builder.WithHeaders("*");
    });
});

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(connectionString));



builder.Services.AddTransient<IUserService, UserService>();
builder.Services.AddTransient<IUser, User>();
builder.Services.AddTransient<IUserRepository, UserRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseHsts();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();