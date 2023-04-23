using BuberDinner.Domain.Bill.ValueObjects;
using BuberDinner.Domain.Common.Models;
using BuberDinner.Domain.Dinner.Entities;
using BuberDinner.Domain.Dinner.ValueObjects;
using BuberDinner.Domain.Host.ValueObjects;
using BuberDinner.Domain.Menu.ValueObjects;

namespace BuberDinner.Domain.Dinner;

public sealed class Dinner : AggregateRoot<DinnerId>
{
    private readonly List<Reservation> _reservations = new List<Reservation>();

    public string Name { get; }
    public string Description { get; }
    public DateTime StartDateTime { get; }
    public DateTime EndDateTime { get; }
    public DateTime StartedDateTime { get; }
    public DateTime EndedDateTime { get; }
    public string Status { get; }
    public bool IsPublic { get; }
    public int MaxGuest{ get; }
    public Price Price{ get; }
    public HostId HostId{ get; }
    public MenuId MenuId{ get; }
    public string ImageUrl{ get; }
    public Location Location{ get; }
    public IReadOnlyList<Reservation> Reservations => _reservations.AsReadOnly();
    public DateTime CreatedDateTime { get; }
    public DateTime UpdatedDateTime { get; }
    public Dinner(DinnerId id) : base(id)
    {
    }

    private Dinner(){}
}