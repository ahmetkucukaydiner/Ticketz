using Core.Persistance.Repositories;
using Ticketz.Domain.Enums;

namespace Ticketz.Domain.Entities;

public class Order : Entity<int>
{
    public int CustomerId { get; set; }
    public int AirlineId { get; set; }
    public int? UserId { get; set; }
    public int FlightId { get; set; }
    public int PaymentId { get; set; }
    public decimal Price { get; set; }
    public OrderState OrderState { get; set; }

    public virtual Flight Flight { get; set; }
    public virtual Airline? Airline { get; set; }
    public virtual Customer? Customer { get; set; }
    public virtual User? User { get; set; }
    public virtual Payment? Payment { get; set; }

    public Order()
    {        
    }

    public Order(int id, int paymentId, int customerId, int airlineId, int userId, int flightId, decimal price, OrderState orderState) : this()
    {
        Id = id;
        PaymentId = paymentId;
        CustomerId = customerId;
        AirlineId = airlineId;
        UserId = userId;
        FlightId = flightId;
        Price = price;
        OrderState = orderState;
    }
}