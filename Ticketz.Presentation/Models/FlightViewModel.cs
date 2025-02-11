namespace Ticketz.Presentation.Models
{
    public class FlightViewModel
    {
        public SearchFlightModel SearchFlightCriteria { get; set; }
        public AirportSearchResponseModel AirportSearchResponse { get; set; }
        public List<SearchFlightResponseModel> SearchFlightResponse { get; set; }
        public GetFlightDetailsResponseModel GetFlightDetailsResponse { get; set; }
    }
}
