using SocialFilm.Application;
using SocialFilm.Infrastructure;
using SocialFilm.Persistance;
using SocialFilm.Presentation;
using Core.CrossCuttingConcerns.Exceptions;
using Core.Security;
using SocialFilm.Persistance.Context;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddControllers(options => options.SuppressImplicitRequiredAttributeForNonNullableReferenceTypes = true)
    .AddApplicationPart(SocialFilm.Presentation.AssemblyReference.Assembly);


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services
    .AddPersistance(builder.Configuration)
    .AddInfrastructure(builder.Configuration)
    .AddApplication()
    .AddPresentation();

builder.Services.AddSecurityServices<AppDbContext>(builder.Configuration);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(opt => { opt.DisplayRequestDuration(); opt.SwaggerEndpoint("/swagger/v1/swagger.json", "SocialFilm"); });
}

if (app.Environment.IsProduction())
    app.ConfigureCustomExceptionMiddleware();

app.MapControllers();

app.UseAuthentication();
app.UseAuthorization();

app.Run();
