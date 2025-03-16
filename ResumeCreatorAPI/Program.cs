using ResumeCreatorAPI.Features.Resume;
using ResumeCreatorAPI.Features.Resume.CreateResume;
using ResumeCreatorAPI.Features.Resume.DeleteResume;
using ResumeCreatorAPI.Features.Resume.GetResume;
using ResumeCreatorAPI.Features.Resume.GetResumeById;
using ResumeCreatorAPI.Features.Resume.UpdateResume;
using ResumeCreatorAPI.Features.User.CreateUser;
using ResumeCreatorAPI.Features.User.GetUserByEmail;
using ResumeCreatorAPI.Features.User.GetUserByUsername;
using ResumeCreatorAPI.Features.User.UpdateUserTier;
using ResumeCreatorAPI.Infrastructure.MongoDb;
using ResumeCreatorAPI.Infrastructure.Persistence;
using ResumeCreatorAPI.Infrastructure.Persistence.User;
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
builder.Services.AddScoped<IUpdateResumeRepository, UpdateResumeRepository>();
builder.Services.AddScoped<IDeleteResumeRepository, DeleteResumeRepository>();
builder.Services.AddScoped<ICreateUserRepository, CreateUserRepository>();
builder.Services.AddScoped<IGetUserByEmailRepository, GetUserByEmailRepository>();
builder.Services.AddScoped<IGetUserByUsernameRepository, GetUserByUsernameRepository>();
builder.Services.AddScoped<IUpdateUserTierRepository, UpdateUserTierRepository>();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAllOrigins", builder =>
    {
        builder.AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader();
    });
});


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference();
}
app.UseCors("AllowAllOrigins");

app.UseHttpsRedirection();
CreateResumeEndpoint.MapCreateResumeEndpoint(app);
GetAllResumesEndpoint.MapGetAllResumeEndpoint(app);
GetResumeByIdEndpoint.MapGetResumeByIdEndpoint(app);
UpdateResumeEndpoint.MapUpdateResumeEndpoint(app);
DeleteResumeEndpoint.MapDeleteResumeEndpoint(app);
CreateUserEndpoint.MapCreateUserEndpoint(app);
GetUserByEmailEndpoint.MapGetUserByEmailEndpoint(app);
GetUserByUsernameEndpoint.MapGetUserByUsernameEndpoint(app);
UpdateUserTierEndpoint.MapUpdateUserTierEndpoint(app);

app.Run();

