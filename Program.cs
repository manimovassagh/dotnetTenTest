using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOpenApi();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference(options =>
    {
        options.Title = "Weather Forecast API";

    });

}

app.UseHttpsRedirection();

app.MapGet("/", () => new { message = "Hello from .NET!" })
    .WithName("home");
app.MapGet("/about", () => new { message = "About page" })
    .WithName("about");




app.Run();

namespace dotnetTenTest
{
    record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
    {
        public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
    }
}
