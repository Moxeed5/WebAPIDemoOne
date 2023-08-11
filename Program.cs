var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();


//Routing with minimal api's

// "/shirts" is the uri. 
app.MapGet("/shirts", () =>
{
    return "Reading all shirts";
});

app.MapGet("/shirts/{id}", (int id) =>
{
    return $"Reading shirt with ID: {id}";
});

app.MapPost("/shirts", () =>
{
    return "Creating a shirt";
});

app.MapPut("/shirts/{id}", (int id) =>
{
    return $"Updating shirt with ID: {id}";
});

app.MapDelete("/shirts/{id}", (int id) =>
{
    return $"Deleting shirt with ID: {id}";
});

app.Run();


