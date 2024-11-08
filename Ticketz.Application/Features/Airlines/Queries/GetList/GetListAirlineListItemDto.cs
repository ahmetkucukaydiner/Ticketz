namespace Ticketz.Application.Features.Airlines.Queries.GetList;

public class GetListAirlineListItemDto
{
    public string Name { get; set; }
    public string IATACode { get; set; }
    public Uri LogoURL { get; set; }
}