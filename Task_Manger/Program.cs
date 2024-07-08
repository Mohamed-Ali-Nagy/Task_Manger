using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Task_Manger.Models;
using Task_Manger.Service;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<TaskMangerContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("cs"))
           );
builder.Services.AddScoped<ITaskService,TaskService>();
builder.Services.AddScoped<ITeamMemberService,TeamMemberService>();
//builder.Services.AddScoped<ITeamMemberService,TeamMemberService>();
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
