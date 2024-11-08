using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ticketz.Domain.Enums;

namespace Ticketz.Application.Features.Orders.Queries.GetById;

public class GetByIdOrderResponse
{
    public string CustomerFirstName { get; set; }
    public string CustomerLastName { get; set; }
    public string AgencyName { get; set; }
    public string AirlineName { get; set; }
    public string DepartureAirportName { get; set; }
    public string ArrivalAirportName { get; set; }
    public decimal Price { get; set; }
    public OrderState OrderState { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime? DeletedDate { get; set; }
    public DateTime? UpdatedDate { get; set; }
}
