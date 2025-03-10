using ResumeCreatorAPI.Features.Resume;
using ResumeCreatorAPI.Features.Resume.CreateResume;
using ResumeCreatorAPI.Features.Resume.GetResume;
using ResumeCreatorAPI.Features.Resume.GetResumeById;
using ResumeCreatorAPI.Infrastructure.MongoDb;
using ResumeCreatorAPI.Infrastructure.Persistence;
using ResumeCreatorAPI.Infrastructure.Services;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOpenApi();
builder.Services.AddOpenApi();
builder.Services.Configure<MongoDbSettings>(builder.Configuration.GetSection("MongoDbSettings"));
builder.Services.AddSingleton<MongodbContext>();
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(Program).Assembly));
builder.Services.AddScoped<TemplateService>();
builder.Services.AddScoped<ITemplateService , TemplateService>();
builder.Services.AddScoped<IResumeRepository, ResumeRepository>();
builder.Services.AddScoped<IGetAllResumesRepository, GetAllResumeRepository>();
builder.Services.AddScoped<IGetResumeByIdRepository, GetResumeByIdRepository>();


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference();
}

app.UseHttpsRedirection();
CreateResumeEndpoint.MapCreateResumeEndpoint(app);
GetAllResumesEndpoint.MapGetAllResumeEndpoint(app);
GetResumeByIdEndpoint.MapGetResumeByIdEndpoint(app);

var summaries = new[]
{
    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
};

app.MapGet("/weatherforecast", () =>
{
    var forecast = Enumerable.Range(1, 5).Select(index =>
        new WeatherForecast
        (
            DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            Random.Shared.Next(-20, 55),
            summaries[Random.Shared.Next(summaries.Length)]
        ))
        .ToArray();
    return forecast;
})
.WithName("GetWeatherForecast");

app.Run();

internal record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}
