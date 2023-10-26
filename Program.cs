using Microsoft.EntityFrameworkCore;
using WebApplication1.data;
using WebApplication1.models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var connectionString = builder.Configuration.GetConnectionString("PostgreSQLConnection");
builder.Services.AddDbContext<personasDb>(options =>
    options.UseNpgsql(connectionString));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapPost("/personass/", async (persona e, personasDb db) =>
{
    db.personas.Add(e);
    await db.SaveChangesAsync();

    return Results.Created($"/personass/ {e.Id}", e);
});


app.MapGet("/personass/{id:int}", async (int id, personasDb db) =>
{
    return await db.personas.FindAsync(id)
    is persona e
    ? Results.Ok(e)
    : Results.NotFound();

});

app.MapGet("/personass", async (personasDb db) => db.personas.ToListAsync());

app.MapPut("/personass/{id:int}", async (int id, persona e, personasDb db) =>
{
    if (e.Id != id)
        return Results.BadRequest();

    var persona = await db.personas.FindAsync(id);

    if (persona is null) return Results.NotFound();

    persona.Nomnbre = e.Nomnbre;
    persona.Apellido = e.Apellido;
    persona.Direccion = e.Direccion;
    persona.Email = e.Email;
    persona.Celular = e.Celular;
    persona.Edad = e.Edad;

    await db.SaveChangesAsync();

    return Results.Ok(persona);
});


app.MapDelete("/personass/{id:int}", async (int id, personasDb db) =>
{
    var persona = await db.personas.FindAsync(id);

    if (persona is null) return Results.NotFound();

    db.personas.Remove(persona);
    await db.SaveChangesAsync();

    return Results.NoContent();
});

app.Run();

internal record WeatherForecast(DateTime Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}