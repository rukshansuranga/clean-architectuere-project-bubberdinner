using BuberDinner.Domain.Common.Models;
using BuberDinner.Domain.Common.ValueObjects;
using BuberDinner.Domain.Dinner.ValueObjects;
using BuberDinner.Domain.Host.ValueObjects;

namespace BuberDinner.Domain.Common.Entities;

public class Rating : Entity<RatingId>
{
    public HostId HostId { get; }
    public DinnerId DinnerId { get; }
    public int RatingValue { get; }
    public DateTime CreatedDateTime { get; }
    public DateTime UpdatedDateTime { get; }
    public Rating(RatingId id, HostId hostId, DinnerId dinnerId, int ratingValue
        , DateTime createdDateTime, DateTime updatedDateTime) : base(id)
    {
        HostId = hostId;
        DinnerId = dinnerId;
        RatingValue = ratingValue;
        CreatedDateTime = createdDateTime;
        UpdatedDateTime = updatedDateTime;
    }
}