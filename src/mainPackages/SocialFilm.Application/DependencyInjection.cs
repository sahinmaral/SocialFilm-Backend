using Core.Application.Pipelines.Authorization;
using Core.Application.Pipelines.Validation;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using SocialFilm.Application.Features.Auths.Rules;
using SocialFilm.Application.Features.Films.Rules;
using SocialFilm.Application.Features.Genres.Rules;
using SocialFilm.Application.Features.Posts.Rules;
using SocialFilm.Application.Features.Roles.Rules;

namespace SocialFilm.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddMediatR(cfg =>
        {
            cfg.RegisterServicesFromAssembly(AssemblyReference.Assembly);
        });

        services.AddAutoMapper(AssemblyReference.Assembly);

        services.AddValidatorsFromAssembly(AssemblyReference.Assembly);
        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(RequestValidationBehavior<,>));
        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(AuthorizationBehavior<,>));

        services.AddScoped<GenreBusinessRules>();
        services.AddScoped<FilmBusinessRules>();
        services.AddScoped<AuthBusinessRules>();
        services.AddScoped<RoleBusinessRules>();
        services.AddScoped<PostBusinessRules>();

        return services;
    }
}