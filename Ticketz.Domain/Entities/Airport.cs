using Core.Persistance.Repositories;

namespace Ticketz.Domain.Entities;

public class Airport : Entity<int>
{
    public string Name { get; set; }
    public string City { get; set; }
    public string Country { get; set; }
    public string AirportCode { get; set; }

    public virtual ICollection<Flight> DepartingFlights { get; set; }
    public virtual ICollection<Flight> ArrivingFlights { get; set; }


    public Airport()
    {
        DepartingFlights = new HashSet<Flight>();
        ArrivingFlights = new HashSet<Flight>();
    }

    public Airport(string name, string country, string city, string airportCode) : this()
    {
        Name = name;
        Country = country;
        AirportCode = airportCode;
        City = city;
    }
}