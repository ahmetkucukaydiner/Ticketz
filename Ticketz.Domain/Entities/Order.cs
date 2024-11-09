using Core.Persistance.Repositories;
using Ticketz.Domain.Enums;

namespace Ticketz.Domain.Entities;

public class Order : Entity<int>
{
    public int CustomerId { get; set; }
    public int AirlineId { get; set; }
    public int UserId { get; set; }
    public int FlightId { get; set; }
    public DateTime DepartureDate { get; set; }
    public DateTime ArrivalDate { get; set; }
    public decimal Price { get; set; }
    public OrderState OrderState { get; set; }

    public virtual Flight Flight { get; set; }
    public virtual Airline? Airline { get; set; }
    public virtual Customer? Customer { get; set; }
    public virtual User? User { get; set; }

    public Order()
    {

    }

    public Order(int id, int customerId, int airlineId, DateTime departureDate, DateTime arrivalDate, int userId, int flightId, decimal price, OrderState orderState) : this()
    {
        Id = id;
        AirlineId = airlineId;
        DepartureDate = departureDate;
        ArrivalDate = arrivalDate;
        UserId = userId;
        CustomerId = customerId;
        Price = price;
        OrderState = orderState;
    }
}