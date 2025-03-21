using AspNetCore.Identity.MongoDbCore.Models;
using Microsoft.AspNetCore.Identity;

namespace ResumeCreatorAPI.Infrastructure.MongoDb;

public static class IdentityConfiguration
{
    public static void AddMongoIdentity(this IServiceCollection services, IConfiguration configuration)
    {
        var mongoSettings = configuration.GetSection("MongoDbSettings").Get<MongoDbSettings>() ?? throw new ApplicationException("MongoDbSettings are missing in the configuration.");
        services.Configure<MongoDbSettings>(configuration.GetSection("MongoDbSettings"));
        services.AddSingleton<MongodbContext>();
    }
}