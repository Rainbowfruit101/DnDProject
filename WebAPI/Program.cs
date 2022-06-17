using Database;
using Microsoft.EntityFrameworkCore;
using Models.LiveEntities;
using Services.Crud;
using Services.Crud.Impls;
using Services.Filtration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<CommonDbContext>(ConfigureDefaultConnection);
builder.Services.AddSingleton<SearchByNameService>();

builder.Services.AddScoped<ICrudService<Creature>>(provider =>
{
    var type = builder.Configuration.GetValue<int>("CreatureService");
    var dbContext = provider.GetService<CommonDbContext>();
    if (dbContext == null)
        throw new Exception($"{typeof(CommonDbContext).FullName} not found");
    
    if (type == 1)
        return new CreatureCrudService(dbContext);
    if (type == 2)
        return new CreatureCustomCrudService(dbContext);

    throw new ArgumentOutOfRangeException($"wrong CreatureService type: {type}");
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