namespace Ticketz.Application.Features.Airlines.Queries.GetById;

public class GetByIdAirlineResponse
{
    public string Name { get; set; }
    public string IATACode { get; set; }
    public string LogoURL { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime? UpdatedDate { get; set; }
    public DateTime? DeletedDate { get; set; }
}