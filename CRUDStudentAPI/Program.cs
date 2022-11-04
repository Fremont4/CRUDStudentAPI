using CRUDStudentAPI.App_repositories.Implementations;
using CRUDStudentAPI.App_repositories.Implementations.Accounts;
using CRUDStudentAPI.App_repositories.Interfaces;
using CRUDStudentAPI.App_repositories.Interfaces.Accounts;
using CRUDStudentAPI.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
//registering database
builder.Services.AddDbContext<StudentDbContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("portalConnectionString")));
//register repo
builder.Services.AddTransient<IRegistrationRepo, RegistrationRepo>();
// profile
builder.Services.AddTransient<IProfileRepo, ProfileRepo>();

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
