using System.Text.Json.Serialization;
using Database;
using Database.Repositories;
using Microsoft.EntityFrameworkCore;
using Models.Common;
using Models.Items;
using Models.LiveEntities;
using Services.Crud;
using Services.Crud.Impls;
using Services.Filtration;
using Services.Filtration.TextSearchPredicate;
using Services.Filtration.TextSearchPredicate.Impls;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
});
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<CommonDbContext>(ConfigureDefaultConnection);

builder.Services.AddScoped<IRepository<Creature>, CreaturesRepository>();
builder.Services.AddScoped<IRepository<Item>, ItemsRepository>();
builder.Services.AddScoped<IRepository<NonPlayerCharacter>, NPCsRepository>();
builder.Services.AddScoped<IRepository<Person>, PersonsRepository>();
builder.Services.AddScoped<IRepository<Spell>, SpellsRepository>();
builder.Services.AddScoped<IRepository<Weapon>, WeaponsRepository>();

builder.Services.AddScoped<ICrudService<Creature>, CreatureCrudService>();
builder.Services.AddScoped<ICrudService<Item>, ItemCrudService>();
builder.Services.AddScoped<ICrudService<NonPlayerCharacter>, NPCCrudService>();
builder.Services.AddScoped<ICrudService<Person>, PersonCrudService>();
builder.Services.AddScoped<ICrudService<Spell>, SpellCrudService>();
builder.Services.AddScoped<ICrudService<Weapon>, WeaponCrudService>();

builder.Services.AddScoped<ITextSearchPredicate>(ResolveTextSearchPredicate);
builder.Services.AddScoped<SearchByNameService>();

var app = builder.Build();

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

    if (connectionString.StartsWith("$"))
    {
        var envValue = Environment.GetEnvironmentVariable(connectionString.TrimStart('$'));
        connectionString = string.IsNullOrWhiteSpace(envValue) ? string.Empty : envValue;
    }
    
    if (string.IsNullOrWhiteSpace(connectionString))
    {
        Console.WriteLine("DnDDatabase connection string is not set");
        return;
    }
    
    options.UseNpgsql(connectionString);
}

ITextSearchPredicate ResolveTextSearchPredicate(IServiceProvider provider)
{
    var section = builder.Configuration.GetSection(nameof(ITextSearchPredicate));

    if (section == null) throw new Exception("Section for TextSearchPredicate not defined");

    var type = section.GetValue<string>("Type");
    if (type == nameof(TypedTextSearchPredicate))
    {
        var predicateType = section.GetValue<TypedTextSearchPredicate.Type>("PredicateType");
        var caseSensitive = section.GetValue<bool>("CaseSensitive");
        return new TypedTextSearchPredicate(predicateType, caseSensitive);
    }

    throw new Exception("Unknown type of TextSearchPredicate");
}