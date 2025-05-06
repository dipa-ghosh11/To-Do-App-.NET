// using System.Text;
// using To_Do_App.Models;
// using To_Do_App.Services;
// using Microsoft.Extensions.Options;
// using Microsoft.AspNetCore.Builder;



// var builder = WebApplication.CreateBuilder(args);

// // Add services to the container.
// // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
// builder.Services.AddOpenApi();

// // Add Swagger
// builder.Services.AddEndpointsApiExplorer();
// builder.Services.AddSwaggerGen();

// // Add your custom services
// builder.Services.Configure<ToDoDatabaseSettings>(
//     builder.Configuration.GetSection("TodoDatabaseSettings"));
//     builder.Services.AddSingleton(sp =>
//     {
//         var settings= builder.Configuration.GetSection("TodoDatabaseSettings").Get<ToDoDatabaseSettings>();

//         return new TaskService(settings);
//     });
// builder.Services.AddSingleton<TaskService>();
// builder.Services.AddSingleton<UserService>();

// var app = builder.Build();

// builder.Services.AddControllers();

// // Configure the HTTP request pipeline.



// app.UseSwagger();
// app.UseSwaggerUI();

// app.UseHttpsRedirection();
// app.UseAuthorization();
// app.MapControllers();
// app.Run();



using To_Do_App.Models;
using To_Do_App.Services;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);

// Add ToDoDatabaseSettings
builder.Services.Configure<ToDoDatabaseSettings>(
    builder.Configuration.GetSection("ToDoDatabaseSettings"));

builder.Services.AddSingleton(sp =>
    sp.GetRequiredService<IOptions<ToDoDatabaseSettings>>().Value);

// Register Services
builder.Services.AddSingleton<UserService>();
builder.Services.AddSingleton<TaskService>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

// app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
