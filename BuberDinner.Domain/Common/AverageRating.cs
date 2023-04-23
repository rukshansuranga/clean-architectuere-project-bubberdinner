using BuberDinner.Domain.Common.Models;

namespace BuberDinner.Domain.Common;

public class AverageRating : ValueObject
{
    public float Value { get; }
    public int NumRating { get; }

    private AverageRating(float value, int numRating)
    {
        Value = value;
        NumRating = numRating;

    }

    private AverageRating()
    {

    }

    public static AverageRating CreateUnique()
    {
        return new AverageRating(1,1);
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
        yield return NumRating;
    }
}