using Core.Persistance.Repositories;

namespace Ticketz.Domain.Entities;

public class Airport : Entity<int>
{
    public string Name { get; set; }
    public string Country { get; set; }
    public string AirportCode { get; set; }

    public virtual ICollection<Order> DepartureOrders { get; set; }
    public virtual ICollection<Order> ArrivalOrders { get; set; }

    public Airport()
    {
        DepartureOrders = new HashSet<Order>();
        ArrivalOrders = new HashSet<Order>();
    }

    public Airport(string name, string country, string airportCode) : this()
    {
        Name = name;
        Country = country;
        AirportCode = airportCode;
    }
}