using RoofBlockCalculator;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

// Serve index.html and other static files from wwwroot/
app.UseDefaultFiles();
app.UseStaticFiles();

// POST /api/calculate  ->  returns { v1, v2, total }
app.MapPost("/api/calculate", (Dimensions d) =>
{
    try
    {
        var result = VolumeCalculator.TotalVolume(
            d.L1, d.W1, d.H1,
            d.B2, d.H2, d.LL2);

        return Results.Ok(result);
    }
    catch (ArgumentException ex)
    {
        return Results.BadRequest(new { error = ex.Message });
    }
});

// Listen on the port the host provides (Render, Azure, etc.) or 8080 locally.
var port = Environment.GetEnvironmentVariable("PORT") ?? "8080";
app.Run($"http://0.0.0.0:{port}");

public record Dimensions(
    double L1, double W1, double H1,
    double B2, double H2, double LL2);
