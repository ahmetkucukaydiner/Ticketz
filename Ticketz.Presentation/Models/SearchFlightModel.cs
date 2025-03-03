namespace Ticketz.Presentation.Models
{
	public class SearchFlightModel
	{
		public string fromId { get; set; }
		public string? departureAirportCode { get; set; }
		public string? arrivalAirportCode { get; set; }
		public string? fromCode { get; set; }
        public string toId { get; set; }
        public string? toCode { get; set; }
        public DateTime departDate { get; set; }
		public int adults { get; set; } = 1;
		public string Sort => "BEST";
		public string cabinClass => "ECONOMY";
		public string currency_code  => "TRY";
	}
}
