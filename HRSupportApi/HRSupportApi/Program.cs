var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

// Add configuration for Dapper context and repositories/services
builder.Services.AddScoped<HRSupportApi.Infrastructure.Context.DapperContext>();
builder.Services.AddScoped<HRSupportApi.Infrastructure.Repositories.IEmployeeRepository, HRSupportApi.Infrastructure.Repositories.EmployeeRepository>();
builder.Services.AddScoped<HRSupportApi.Application.Interfaces.IEmployeeService, HRSupportApi.Application.Services.EmployeeService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
