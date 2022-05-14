using Database;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<DnDDatabaseContext>(options =>
{
    var cs = builder.Configuration.GetConnectionString("DnDDatabase");
    if (string.IsNullOrWhiteSpace(cs))
    {
        Console.WriteLine("идиот ты коннекшн стринг не задал!");
        return;
    }
    options.UseNpgsql(cs);
});

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