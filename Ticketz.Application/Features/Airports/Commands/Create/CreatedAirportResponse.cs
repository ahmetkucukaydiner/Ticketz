namespace Ticketz.Application.Features.Airports.Commands.Create
{
    public class CreatedAirportResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string AirportCode { get; set; }
        public string Country { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}