using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/route/{zip}", (string zip, [FromQuery] int? days) =>
{
    return Results.Ok(zip);
});

app.Run();

//how to map an application instance

/*var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/route/{value}", (string value) =>
{
    return Results.Ok(value);
});

app.Run();*/
