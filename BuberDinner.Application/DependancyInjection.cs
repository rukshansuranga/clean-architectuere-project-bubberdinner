using Microsoft.Extensions.DependencyInjection;
using MediatR;
using BuberDinner.Application.Authentication.Commands.Register;
using ErrorOr;
using BuberDinner.Application.Authentication.Common;
using BuberDinner.Application.Common.Behaviours;
using FluentValidation;
using System.Reflection;

namespace BuberDinner.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        //services.AddMediatR(typeof(DependencyInjection).Assembly);
        services.AddMediatR(cfg=>cfg.RegisterServicesFromAssemblies(typeof(DependencyInjection).Assembly));
        //services.AddScoped<IPipelineBehavior<RegisterCommand,ErrorOr<AuthenticationResult>>, ValidateRegisterCommandBehavior>();
        services.AddScoped(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
        //services.AddScoped<IValidator<RegisterCommand>, RegisterCommandValidator>();
        services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
        return services;
    }
}