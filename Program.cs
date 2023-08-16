using Microsoft.EntityFrameworkCore;
using WebAPIDemoOne.Data;

var builder = WebApplication.CreateBuilder(args);

//provides connection string for options param in Db Context class constructor
builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("ShirtStoreManagement"));
});

// Add services to the container.

builder.Services.AddControllers();  


var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.MapControllers();







app.Run();


