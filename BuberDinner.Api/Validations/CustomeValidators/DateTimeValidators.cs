using BuberDinner.Application.Common.Interfaces.Services;
using FluentValidation;

namespace BuberDinner.Api.Validations.CustomeValidators;

public static class DateTimeValidators
{
    public static IRuleBuilderOptions<T, DateTime> AfterSunrise<T>(
        this IRuleBuilder<T, DateTime> ruleBuilder
        ,IDateTimeProvider dateTimeProvider)
    {
        var sunrise = dateTimeProvider.Midnight.AddHours(6);

        return ruleBuilder.Must((objectRoot, datetime, context) => 
        {
            TimeOnly providedTime = TimeOnly.FromDateTime(datetime);
            context.MessageFormatter.AppendArgument("Sunrise", sunrise);
            context.MessageFormatter.AppendArgument("ProvidedTime", providedTime);

            return providedTime > sunrise;

        })
        .WithMessage("{PropertyName} Time must be after {Sunrise}. You Provided {ProvidedTime}");
    }
}