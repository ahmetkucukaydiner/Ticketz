namespace Ticketz.Presentation.Models
{
    public class GetFlightDetailsModel
    {
        public string token { get; set; }
        public string? currency_code { get; set; } = "TRY";
    }
}
