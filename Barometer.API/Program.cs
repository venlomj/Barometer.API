using Barometer.BLL.MapperProfile;
using Barometer.BLL.Services.Implementation;
using Barometer.BLL.Services.Interface;
using Barometer.BLL.Validation;
using Barometer.DAL;
using Barometer.DAL.Repositories.Implementation;
using Barometer.DAL.Repositories.Interface;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Microsoft.Win32;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// Register FluentValidation
builder.Services.AddValidatorsFromAssemblyContaining<BarometerRequestValidator>();

var connectionString = builder.Configuration.GetConnectionString("BarometerDbConnection");
builder.Services.AddDbContext<BarometerContext>(options => options.UseSqlServer(connectionString));

builder.Services.AddAutoMapper(typeof(Program), typeof(BarometerMapperProfile));

builder.Services.AddScoped<IBarometerRepository, BarometerRepository>();

builder.Services.AddScoped<IBarometerService, BarometerService>();

builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(Program).Assembly));

builder.Services.AddControllers();
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
