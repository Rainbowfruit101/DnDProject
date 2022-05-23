using Database;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<CommonDbContext>(ConfigureDefaultConnection);

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

void ConfigureDefaultConnection(DbContextOptionsBuilder options)
{
    var connectionString = builder.Configuration.GetConnectionString("DnDDatabase");
    
    if (string.IsNullOrWhiteSpace(connectionString))
    {
        Console.WriteLine("DnDDatabase connection string is not set");
        return;
    }

    options.UseNpgsql(connectionString);
}