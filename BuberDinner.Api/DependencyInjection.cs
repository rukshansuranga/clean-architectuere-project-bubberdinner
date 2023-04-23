using BuberDinner.Api.Common.Mapping;
using BuberDinner.Api.Services.Breakfasts;
using BuberDinner.Api.Validations;
using BuberDinner.Contracts.Breakfast;
using FluentValidation;
using FluentValidation.AspNetCore;

namespace BuberDinner.Api;

public static class DependencyInjection
{
    public static IServiceCollection AddPresentation(this IServiceCollection services)
    {
        services.AddScoped<IBreakfastService, BreakfastService>();
        //services.AddScoped<IValidator<CreateBreakfastRequest>, CreateBreakfastRequestValidator>();
        services.AddFluentValidation();
        services.AddValidatorsFromAssemblyContaining<IAssemblyMarker>();
        services.AddControllers();
        services.AddMapping();
        return services;
    }
}