using Database;
using Microsoft.EntityFrameworkCore;
using Models.Common;
using Models.Items;
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

builder.Services.AddScoped<ICrudService<Creature>, CreatureCrudService>();
builder.Services.AddScoped<ICrudService<Person>, PersonCrudService>();
builder.Services.AddScoped<ICrudService<NonPlayerCharacter>, NPCCrudService>();
builder.Services.AddScoped<ICrudService<Item>, ItemCrudService>();
builder.Services.AddScoped<ICrudService<Weapon>, WeaponCrudService>();
builder.Services.AddScoped<ICrudService<Spell>, SpellCrudService>();

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