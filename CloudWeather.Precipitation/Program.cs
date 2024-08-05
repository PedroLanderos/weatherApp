using CloudWeather.Precipitation.DataAccess;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<PrecipitationDBContext>(
    opts =>
    {
        opts.EnableSensitiveDataLogging();
        opts.EnableDetailedErrors();
        opts.UseNpgsql(builder.Configuration.GetConnectionString("AppDb"));
    }, ServiceLifetime.Transient);

var app = builder.Build();

app.MapGet("/route/{zip}", async (string zip, [FromQuery] int? days, PrecipitationDBContext db) =>
{
    if (days == null)
        return Results.BadRequest("Provide a valid number of days");

    var startDate = DateTime.UtcNow - TimeSpan.FromDays(days.Value);
    var results = await db.Precipitation.Where(precip => precip.ZipCode == zip && precip.CreatedOn > startDate).ToListAsync();

    return Results.Ok(results);
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
