using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SocialFilm.Infrastructure.ApiClients;
using SocialFilm.Application.Services.ApiClients;

namespace SocialFilm.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services,IConfiguration configuration)
    {
        string bearerToken = configuration["TMDBApi:APIKey"];
        services.AddSingleton<ITMDBApiClient>(provider => new TMDBApiClient(bearerToken));
        //services.AddSingleton<ICloudinaryService, CloudinaryService>();

        //services.ConfigureOptions<CloudinaryOptionsSetup>();

        return services;
    }
}