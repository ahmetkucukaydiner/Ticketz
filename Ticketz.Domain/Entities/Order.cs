using Core.Persistance.Repositories;
using Ticketz.Domain.Enums;

namespace Ticketz.Domain.Entities;

public class Order : Entity<int>
{
    public int CustomerId { get; set; }
    public int AirlineId { get; set; }
    public int DepartureAirportId { get; set; }
    public int ArrivalAirportId { get; set; }
    public int UserId { get; set; }
    public DateTime DepartureDate { get; set; }
    public DateTime ArrivalDate { get; set; }
    public decimal Price { get; set; }
    public OrderState OrderState { get; set; }
    public virtual Airline? Airline { get; set; }
    public virtual Customer? Customer { get; set; }
    public virtual User? User { get; set; }
    public virtual Airport DepartureAirport { get; set; }
    public virtual Airport ArrivalAirport { get; set; }

    public Order()
    {

    }

    public Order(int id, int customerId, int airlineId, int departureAirportId, int arrivalAirportId, DateTime departureDate, DateTime arrivalDate, int userId, int flightId, decimal price, OrderState orderState) : this()
    {
        Id = id;
        AirlineId = airlineId;
        DepartureAirportId = departureAirportId;
        ArrivalAirportId = arrivalAirportId;
        DepartureDate = departureDate;
        ArrivalDate = arrivalDate;
        UserId = userId;
        CustomerId = customerId;
        Price = price;
        OrderState = orderState;
    }
}