using BuberDinner.Domain.Bill.ValueObjects;
using BuberDinner.Domain.Common.Models;
using BuberDinner.Domain.Dinner.ValueObjects;
using BuberDinner.Domain.Guest.ValueObjects;

namespace BuberDinner.Domain.Dinner.Entities;

public class Reservation : Entity<ReservationId>
{
    public int GuestCount { get; }
    public string ReservationStatus { get; }
    public GuestId GuestId { get; }
    public BillId BillId { get; }
    public DateTime ArrivalDateTime { get; }
    public DateTime CreatedDateTime { get; }
    public DateTime UpdatedDateTime { get; }

    public Reservation(ReservationId id, int guestCount, string reservationStatus, GuestId guestId, BillId billId
    , DateTime arrivalDateTime, DateTime createdDateTime, DateTime updateDateTime) : base(id)
    {
        GuestCount = guestCount;
        ReservationStatus = reservationStatus;
        GuestId = guestId;
        BillId = billId;
        ArrivalDateTime = arrivalDateTime;
        CreatedDateTime = createdDateTime;
        UpdatedDateTime = updateDateTime;
    }

    public Reservation Create(int guestCount, string reservationStatus, GuestId guestId, BillId billId
    , DateTime arrivalDateTime)
    {
        return new(ReservationId.CreateUnique(), guestCount, reservationStatus, guestId, billId, arrivalDateTime, DateTime.UtcNow, DateTime.UtcNow);
    }
}