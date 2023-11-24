using API.data;
using Microsoft.EntityFrameworkCore;
using API.models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


var connectionString = builder.Configuration.GetConnectionString("PostgreSQLConnection");
builder.Services.AddDbContext<apiDb>(options =>
    options.UseNpgsql(connectionString));


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapPost("/personas/", async (Persona e, apiDb db) =>
{
    db.Persona.Add(e);
    await db.SaveChangesAsync();

    return Results.Created($"/personas/{e.Id}", e);
});

app.MapGet("/personas/{id:int}", async (int id, apiDb db) =>
{
    return await db.Persona.FindAsync(id)
    is Persona e
    ? Results.Ok(e)
    : Results.NotFound();
});

app.MapGet("/personas/", async (apiDb db) => await db.Persona.ToListAsync());


app.MapPut("/personas/{id:int}", async (int id, Persona e, apiDb db) =>
{
    if (e.Id != id)
        return Results.BadRequest();

    var persona = await db.Persona.FindAsync(id);
    if (persona is null) return Results.NotFound();

    persona.Nombre = e.Nombre;
    persona.Apellido = e.Apellido;
    persona.Telefono = e.Telefono;
    persona.TipoDocumento = e.TipoDocumento;
    persona.Direccion = e.Direccion;
    persona.Email = e.Email;
    persona.Estado = e.Estado;
    persona.NroDocumento = e.NroDocumento;

    await db.SaveChangesAsync();

    return Results.Ok(persona);

});

app.MapDelete("/personas/{id:int}", async (int id, apiDb db) =>
{
    var cliente = await db.Clientes.FindAsync(id);

    if (cliente is null) return Results.NotFound();

    db.Clientes.Remove(cliente);

    await db.SaveChangesAsync();

    return Results.NoContent();

});
app.Run();