namespace Ticketz.Application.Features.Airports.Queries.GetById
{
    public class GetByIdAirportResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string AirportCode { get; set; }
        public string Country { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public DateTime? DeletedDate { get; set; }
    }
}