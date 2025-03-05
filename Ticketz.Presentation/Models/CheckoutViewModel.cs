using Ticketz.Domain.Enums;

namespace Ticketz.Presentation.Models
{
    public class CheckoutViewModel
    {
        // Müşteri bilgileri
        public string? CustomerFirstName { get; set; }
        public string? CustomerLastName { get; set; }
        public string? CustomerEmail { get; set; }
        public string? CustomerPhoneNumber { get; set; }
        public string? CustomerPassportNumber { get; set; }

        // Uçuş bilgileri

        // Havayolu ve havalimanı bilgileri
        public string? DepartureAirportCode { get; set; }
        public string? ArrivalAirportCode { get; set; }

        // Ödeme bilgileri
        public string CardNumber { get; set; }
        public string CardHolderName { get; set; }
        public string ExpirationDate { get; set; }
        public string Cvv { get; set; }
        public GetFlightDetailsResponseModel? GetFlightDetailsResponse { get; set; }
    }
}
