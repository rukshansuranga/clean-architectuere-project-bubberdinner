using BuberDinner.Domain.Common.Models;
using BuberDinner.Domain.Dinner.ValueObjects;
using BuberDinner.Domain.Host.ValueObjects;
using BuberDinner.Domain.Menu.Entities;
using BuberDinner.Domain.Menu.ValueObjects;
using BuberDinner.Domain.MenuReview.ValueObjects;
using BuberDinner.Domain.Common;
using BuberDinner.Domain.Common.ValueObjects;

namespace BuberDinner.Domain.Menu;


public sealed class Menu : AggregateRoot<MenuId>
{
    private readonly List<MenuSection> _sections = new List<MenuSection>();
    private readonly List<DinnerId> _dinnerIds = new List<DinnerId>();
    private readonly List<MenuReviewId> _menuReviewIds = new List<MenuReviewId>();

    public string Name { get; private set; }
    public string Description { get; private set; }
    public AverageRating AverageRating { get; private set; }
    public IReadOnlyList<MenuSection> Sections => _sections.AsReadOnly();
    public HostId HostId { get; private set; }
    public IReadOnlyList<DinnerId> DinnerIds => _dinnerIds.AsReadOnly();
    public IReadOnlyList<MenuReviewId> MenuReviewIds => _menuReviewIds.AsReadOnly();

    public DateTime CreatedDateTime { get; private set; }
    public DateTime UpdatedDateTime { get; private set; }

    private Menu(){}

    private Menu(MenuId menuId, string name, string description, HostId hostId, AverageRating avergeRating
        , DateTime createdDateTime, DateTime updatedDateTime ) : base(menuId)
    {
        Name = name;
        Description = description;
        HostId = hostId;
        AverageRating = avergeRating;
        CreatedDateTime = createdDateTime;
        UpdatedDateTime = updatedDateTime;
    }

    public static Menu Create(string name, string description, HostId hostId, List<MenuSection>? sections)
    {
        return new(MenuId.CreateUnique(), name, description, hostId, AverageRating.CreateUnique(), DateTime.UtcNow, DateTime.UtcNow);
    }
}