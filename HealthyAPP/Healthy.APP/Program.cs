using HealthyAPP.ApplicationLayer.Contract;
using HealthyAPP.ApplicationLayer.Services;
using HealthyAPP.InfrastructureLayer.Context;
using HealthyAPP.InfrastructureLayer.Interfaces;
using HealthyAPP.InfrastructureLayer.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<HealthyAPPContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("HealthyAPP"));
});


builder.Services.AddTransient<IUnitOfWork,UnitOfWork>();
builder.Services.AddTransient<IUserService, UserService>();
builder.Services.AddTransient<IRoutineService, RoutineService>();
builder.Services.AddTransient<IMealPlanService, MealPlanService>();
builder.Services.AddTransient<IHealthLogService, HealthLogService>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
