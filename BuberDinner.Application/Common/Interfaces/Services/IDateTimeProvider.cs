namespace BuberDinner.Application.Common.Interfaces.Services;

public interface IDateTimeProvider
{
    DateTime UtcNow { get; }

    TimeOnly Midnight => TimeOnly.MinValue;
}