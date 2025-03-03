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
    public int AgencyId { get; set; }
    public int AirlineId { get; set; }
    public int ArrivalAirportId { get; set; }
    public int DepartureAirportId { get; set; }
    public int FlightId { get; set; }
    public decimal Price { get; set; }
    public OrderState OrderState { get; set; }
    public DateTime CreatedDate { get; set; }
    
    // Müşteri bilgileri
    public string? CustomerFullName { get; set; }
    public string? CustomerEmail { get; set; }
    public string? CustomerPhoneNumber { get; set; }
    public string? CustomerPassportNumber { get; set; }
    
    // Uçuş bilgileri
    public int? FlightNumber { get; set; }
    public DateTime? DepartureTime { get; set; }
    public DateTime? ArrivalTime { get; set; }
    public string? CabinClass { get; set; }
    public string? Luggage { get; set; }
    
    // Havayolu ve havalimanı bilgileri
    public string? AirlineName { get; set; }
    public string? DepartureAirportName { get; set; }
    public string? DepartureAirportCode { get; set; }
    public string? ArrivalAirportName { get; set; }
    public string? ArrivalAirportCode { get; set; }
    public string? FlightDetails { get; set; }
    
    // Ödeme bilgileri
    public string? PaymentId { get; set; }
    public DateTime? PaymentDate { get; set; }
    public bool IsPaymentSuccessful { get; set; }
    
    // Bilet bilgileri
    public string? TicketNumber { get; set; }
    public string? PNR { get; set; }
}
