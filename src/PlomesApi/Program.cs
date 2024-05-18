using Microsoft.EntityFrameworkCore;
using PlomesApi.Data;
using PlomesApi.Repositories.Interfaces;
using PlomesApi.Repositories;
using PlomesApi.Services.Interfaces;
using PlomesApi.Services;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<AppDbContext>(options =>
        options.UseNpgsql(builder.Configuration.GetConnectionString("DataBase")));
//TODO MUDA PARA SQLSERVER
//options.UseSqlServer(builder.Configuration.GetConnectionString("DataBase")));


builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserService, UserService>();

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
