using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ticketz.Domain.Enums;

namespace Ticketz.Application.Features.Orders.Commands.Create;

public class CreatedOrderResponse
{
    public int Id { get; set; }
    public int CustomerId { get; set; }
    public int AirlineId { get; set; }
    public int FlightId { get; set; }
    public decimal Price { get; set; }
    public OrderState OrderState { get; set; }
    public DateTime CreatedDate { get; set; }
    public string? CustomerFullName { get; set; }
    public string? CustomerEmail { get; set; }
    public string? CustomerPhoneNumber { get; set; }
    public string? CustomerPassportNumber { get; set; }   
    public int? FlightNumber { get; set; }
    public DateTime? DepartureTime { get; set; }
    public DateTime? ArrivalTime { get; set; }
    public string? CabinClass { get; set; }
    public string? Luggage { get; set; }    
    public string? AirlineName { get; set; }
    public string? DepartureAirportName { get; set; }
    public string? DepartureAirportCode { get; set; }
    public string? ArrivalAirportName { get; set; }
    public string? ArrivalAirportCode { get; set; }
    public string? FlightDetails { get; set; }    
    public string? PaymentId { get; set; }
    public DateTime? PaymentDate { get; set; }
    public bool IsPaymentSuccessful { get; set; }    
    public string? TicketNumber { get; set; }
    public string? PNR { get; set; }
}
