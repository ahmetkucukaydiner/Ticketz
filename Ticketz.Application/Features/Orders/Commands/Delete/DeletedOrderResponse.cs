using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ticketz.Domain.Enums;

namespace Ticketz.Application.Features.Orders.Commands.Delete;

public class DeletedOrderResponse
{
    public int CustomerId { get; set; }
    public int AgencyId { get; set; }
    public int AirlineId { get; set; }
    public int ArrivalAirportId { get; set; }
    public int DepartureAirportId { get; set; }
    public decimal Price { get; set; }
    public OrderState OrderState { get; set; }
}
