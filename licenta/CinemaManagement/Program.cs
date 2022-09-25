using CinemaManagement.Domain.Models;
using CinemaManagement.Infrastructure;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//DbContext
builder.Services.AddDbContext<CinemaManagementContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("CinemaManagementContext") ?? throw new InvalidOperationException("Connection string 'CinemaManagementContext' not found.")));

builder.Services
    .AddIdentity<User, UserRole>()
    .AddEntityFrameworkStores<CinemaManagementContext>()
    .AddDefaultTokenProviders()
    .AddUserStore<UserStore<User, UserRole, CinemaManagementContext, Guid>>()
    .AddRoleStore<RoleStore<UserRole, CinemaManagementContext, Guid>>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseRouting();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
