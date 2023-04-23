using BuberDinner.Domain.Common.Models;
using BuberDinner.Domain.Dinner.ValueObjects;

namespace BuberDinner.Domain.Dinner.Entities;

public class Location : Entity<LocationId>
{

    public string Name{ get; }
    public string Address{ get; }
    public decimal Latitude{ get; }
    public decimal Longitude{ get; }
    public Location(LocationId id, string name, string address, decimal latitude, decimal longitude) : base(id)
    {
        Name = name;
        Address = address;
        Latitude = latitude;
        Longitude = longitude;
    }

    public Location Create(string name, string address, decimal latitude, decimal longitude)
    {
        return new(LocationId.CreateUnique(), name, address, latitude, longitude);
    }
}