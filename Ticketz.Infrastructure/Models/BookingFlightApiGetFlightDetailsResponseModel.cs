using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ticketz.Infrastructure.Models;

public class BookingFlightApiGetFlightDetailsResponseModel
{
    public bool status { get; set; }
    public string message { get; set; }
    public long timestamp { get; set; }
    public Data data { get; set; }    

    public class Data
    {
        public string token { get; set; }
        public Segment1[] segments { get; set; }
        public Pricebreakdown priceBreakdown { get; set; }
        public Travellerprice[] travellerPrices { get; set; }
        public object[] priceDisplayRequirements { get; set; }
        public string pointOfSale { get; set; }
        public string tripType { get; set; }
        public string offerReference { get; set; }
        public string[] bookerDataRequirement { get; set; }
        public Traveller[] travellers { get; set; }
        public Posmismatch posMismatch { get; set; }
        public Includedproductsbysegment[][] includedProductsBySegment { get; set; }
        public Includedproducts includedProducts { get; set; }
        public Extraproduct[] extraProducts { get; set; }
        public Offerextras offerExtras { get; set; }
        public Brandedfareinfo brandedFareInfo { get; set; }
        public Farerulesstatus fareRulesStatus { get; set; }
        public Ancillaries ancillaries { get; set; }
        public object[] appliedDiscounts { get; set; }
        public Baggagepolicy[] baggagePolicies { get; set; }
        public Extraproductdisplayrequirements extraProductDisplayRequirements { get; set; }
        public Carbonemissions carbonEmissions { get; set; }
    }

    public class Pricebreakdown
    {
        public Total total { get; set; }
        public Basefare baseFare { get; set; }
        public Fee fee { get; set; }
        public Tax tax { get; set; }
        public Totalrounded totalRounded { get; set; }
        public Moretaxesandfees moreTaxesAndFees { get; set; }
        public Discount discount { get; set; }
        public Totalwithoutdiscount totalWithoutDiscount { get; set; }
        public Totalwithoutdiscountrounded totalWithoutDiscountRounded { get; set; }
        public Carriertaxbreakdown[] carrierTaxBreakdown { get; set; }
    }

    public class Total
    {
        public string currencyCode { get; set; }
        public int units { get; set; }
        public int nanos { get; set; }
    }

    public class Basefare
    {
        public string currencyCode { get; set; }
        public int units { get; set; }
        public int nanos { get; set; }
    }

    public class Fee
    {
        public string currencyCode { get; set; }
        public int units { get; set; }
        public int nanos { get; set; }
    }

    public class Tax
    {
        public string currencyCode { get; set; }
        public int units { get; set; }
        public int nanos { get; set; }
    }

    public class Totalrounded
    {
        public string currencyCode { get; set; }
        public int nanos { get; set; }
        public int units { get; set; }
    }

    public class Moretaxesandfees
    {
    }

    public class Discount
    {
        public string currencyCode { get; set; }
        public int units { get; set; }
        public int nanos { get; set; }
    }

    public class Totalwithoutdiscount
    {
        public string currencyCode { get; set; }
        public int units { get; set; }
        public int nanos { get; set; }
    }

    public class Totalwithoutdiscountrounded
    {
        public string currencyCode { get; set; }
        public int nanos { get; set; }
        public int units { get; set; }
    }

    public class Carriertaxbreakdown
    {
        public Carrier carrier { get; set; }
        public Avgperadult avgPerAdult { get; set; }
        public Avgperchild avgPerChild { get; set; }
    }

    public class Carrier
    {
        public string name { get; set; }
        public string code { get; set; }
        public string logo { get; set; }
    }

    public class Avgperadult
    {
        public string currencyCode { get; set; }
        public int units { get; set; }
        public int nanos { get; set; }
    }

    public class Avgperchild
    {
        public string currencyCode { get; set; }
        public int units { get; set; }
        public int nanos { get; set; }
    }

    public class Posmismatch
    {
        public string detectedPointOfSale { get; set; }
        public bool isPOSMismatch { get; set; }
        public string offerSalesCountry { get; set; }
    }

    public class Includedproducts
    {
        public bool areAllSegmentsIdentical { get; set; }
        public Segment[][] segments { get; set; }
    }

    public class Segment
    {
        public string luggageType { get; set; }
        public int maxPiece { get; set; }
        public float maxWeightPerPiece { get; set; }
        public string massUnit { get; set; }
        public Sizerestrictions sizeRestrictions { get; set; }
        public string ruleType { get; set; }
    }

    public class Sizerestrictions
    {
        public float maxLength { get; set; }
        public float maxWidth { get; set; }
        public float maxHeight { get; set; }
        public string sizeUnit { get; set; }
    }

    public class Offerextras
    {
        public Mobiletravelplan mobileTravelPlan { get; set; }
    }

    public class Mobiletravelplan
    {
        public Pricebreakdown1 priceBreakdown { get; set; }
    }

    public class Pricebreakdown1
    {
        public Total1 total { get; set; }
        public Basefare1 baseFare { get; set; }
        public Fee1 fee { get; set; }
        public Tax1 tax { get; set; }
        public Moretaxesandfees1 moreTaxesAndFees { get; set; }
        public Discount1 discount { get; set; }
        public Totalwithoutdiscount1 totalWithoutDiscount { get; set; }
    }

    public class Total1
    {
        public string currencyCode { get; set; }
        public int units { get; set; }
        public int nanos { get; set; }
    }

    public class Basefare1
    {
        public string currencyCode { get; set; }
        public int units { get; set; }
        public int nanos { get; set; }
    }

    public class Fee1
    {
        public string currencyCode { get; set; }
        public int units { get; set; }
        public int nanos { get; set; }
    }

    public class Tax1
    {
        public string currencyCode { get; set; }
        public int units { get; set; }
        public int nanos { get; set; }
    }

    public class Moretaxesandfees1
    {
    }

    public class Discount1
    {
        public string currencyCode { get; set; }
        public int units { get; set; }
        public int nanos { get; set; }
    }

    public class Totalwithoutdiscount1
    {
        public string currencyCode { get; set; }
        public int units { get; set; }
        public int nanos { get; set; }
    }

    public class Brandedfareinfo
    {
        public string fareName { get; set; }
        public string cabinClass { get; set; }
        public object[] features { get; set; }
        public object[] fareAttributes { get; set; }
        public object[] nonIncludedFeatures { get; set; }
    }

    public class Farerulesstatus
    {
        public Leg[] legs { get; set; }
        public bool areAllStatusesIdentical { get; set; }
        public bool areAllCarriersIdentical { get; set; }
        public object policy { get; set; }
    }

    public class Leg
    {
        public Legidentifier legIdentifier { get; set; }
        public string carrierName { get; set; }
        public string changeable { get; set; }
        public string refundable { get; set; }
    }

    public class Legidentifier
    {
        public int segmentIndex { get; set; }
        public int legIndex { get; set; }
    }

    public class Ancillaries
    {
        public Mobiletravelplan1 mobileTravelPlan { get; set; }
    }

    public class Mobiletravelplan1
    {
        public Pricebreakdown2 priceBreakdown { get; set; }
    }

    public class Pricebreakdown2
    {
        public Total2 total { get; set; }
        public Basefare2 baseFare { get; set; }
        public Fee2 fee { get; set; }
        public Tax2 tax { get; set; }
        public Moretaxesandfees2 moreTaxesAndFees { get; set; }
        public Discount2 discount { get; set; }
        public Totalwithoutdiscount2 totalWithoutDiscount { get; set; }
    }

    public class Total2
    {
        public string currencyCode { get; set; }
        public int units { get; set; }
        public int nanos { get; set; }
    }

    public class Basefare2
    {
        public string currencyCode { get; set; }
        public int units { get; set; }
        public int nanos { get; set; }
    }

    public class Fee2
    {
        public string currencyCode { get; set; }
        public int units { get; set; }
        public int nanos { get; set; }
    }

    public class Tax2
    {
        public string currencyCode { get; set; }
        public int units { get; set; }
        public int nanos { get; set; }
    }

    public class Moretaxesandfees2
    {
    }

    public class Discount2
    {
        public string currencyCode { get; set; }
        public int units { get; set; }
        public int nanos { get; set; }
    }

    public class Totalwithoutdiscount2
    {
        public string currencyCode { get; set; }
        public int units { get; set; }
        public int nanos { get; set; }
    }

    public class Extraproductdisplayrequirements
    {
    }

    public class Carbonemissions
    {
        public Footprintforoffer footprintForOffer { get; set; }
    }

    public class Footprintforoffer
    {
        public float quantity { get; set; }
        public string unit { get; set; }
        public string status { get; set; }
        public int average { get; set; }
        public int percentageDifference { get; set; }
    }

    public class Segment1
    {
        public Departureairport departureAirport { get; set; }
        public Arrivalairport arrivalAirport { get; set; }
        public DateTime departureTime { get; set; }
        public DateTime arrivalTime { get; set; }
        public Leg1[] legs { get; set; }
        public int totalTime { get; set; }
        public Travellercheckedluggage[] travellerCheckedLuggage { get; set; }
        public Travellercabinluggage[] travellerCabinLuggage { get; set; }
        public bool isAtolProtected { get; set; }
        public bool showWarningDestinationAirport { get; set; }
        public bool showWarningOriginAirport { get; set; }
    }

    public class Departureairport
    {
        public string type { get; set; }
        public string code { get; set; }
        public string city { get; set; }
        public string cityName { get; set; }
        public string country { get; set; }
        public string countryName { get; set; }
        public string name { get; set; }
    }

    public class Arrivalairport
    {
        public string type { get; set; }
        public string code { get; set; }
        public string city { get; set; }
        public string cityName { get; set; }
        public string country { get; set; }
        public string countryName { get; set; }
        public string name { get; set; }
    }

    public class Leg1
    {
        public DateTime departureTime { get; set; }
        public DateTime arrivalTime { get; set; }
        public Departureairport1 departureAirport { get; set; }
        public Arrivalairport1 arrivalAirport { get; set; }
        public string cabinClass { get; set; }
        public Flightinfo flightInfo { get; set; }
        public string[] carriers { get; set; }
        public Carriersdata[] carriersData { get; set; }
        public int totalTime { get; set; }
        public object[] flightStops { get; set; }
    }

    public class Departureairport1
    {
        public string type { get; set; }
        public string code { get; set; }
        public string city { get; set; }
        public string cityName { get; set; }
        public string country { get; set; }
        public string countryName { get; set; }
        public string name { get; set; }
    }

    public class Arrivalairport1
    {
        public string type { get; set; }
        public string code { get; set; }
        public string city { get; set; }
        public string cityName { get; set; }
        public string country { get; set; }
        public string countryName { get; set; }
        public string name { get; set; }
    }

    public class Flightinfo
    {
        public object[] facilities { get; set; }
        public int flightNumber { get; set; }
        public string planeType { get; set; }
        public Carrierinfo carrierInfo { get; set; }
    }

    public class Carrierinfo
    {
        public string operatingCarrier { get; set; }
        public string marketingCarrier { get; set; }
        public string operatingCarrierDisclosureText { get; set; }
    }

    public class Carriersdata
    {
        public string name { get; set; }
        public string code { get; set; }
        public string logo { get; set; }
    }

    public class Travellercheckedluggage
    {
        public string travellerReference { get; set; }
        public Luggageallowance luggageAllowance { get; set; }
    }

    public class Luggageallowance
    {
        public string luggageType { get; set; }
        public string ruleType { get; set; }
        public int maxPiece { get; set; }
        public float maxWeightPerPiece { get; set; }
        public string massUnit { get; set; }
    }

    public class Travellercabinluggage
    {
        public string travellerReference { get; set; }
        public Luggageallowance1 luggageAllowance { get; set; }
    }

    public class Luggageallowance1
    {
        public string luggageType { get; set; }
        public int maxPiece { get; set; }
        public float maxWeightPerPiece { get; set; }
        public string massUnit { get; set; }
        public Sizerestrictions1 sizeRestrictions { get; set; }
    }

    public class Sizerestrictions1
    {
        public float maxLength { get; set; }
        public float maxWidth { get; set; }
        public float maxHeight { get; set; }
        public string sizeUnit { get; set; }
    }

    public class Travellerprice
    {
        public Travellerpricebreakdown travellerPriceBreakdown { get; set; }
        public string travellerReference { get; set; }
        public string travellerType { get; set; }
    }

    public class Travellerpricebreakdown
    {
        public Total3 total { get; set; }
        public Basefare3 baseFare { get; set; }
        public Fee3 fee { get; set; }
        public Tax3 tax { get; set; }
        public Totalrounded1 totalRounded { get; set; }
        public Moretaxesandfees3 moreTaxesAndFees { get; set; }
        public Discount3 discount { get; set; }
        public Totalwithoutdiscount3 totalWithoutDiscount { get; set; }
        public Totalwithoutdiscountrounded1 totalWithoutDiscountRounded { get; set; }
    }

    public class Total3
    {
        public string currencyCode { get; set; }
        public int units { get; set; }
        public int nanos { get; set; }
    }

    public class Basefare3
    {
        public string currencyCode { get; set; }
        public int units { get; set; }
        public int nanos { get; set; }
    }

    public class Fee3
    {
        public string currencyCode { get; set; }
        public int units { get; set; }
        public int nanos { get; set; }
    }

    public class Tax3
    {
        public string currencyCode { get; set; }
        public int units { get; set; }
        public int nanos { get; set; }
    }

    public class Totalrounded1
    {
        public string currencyCode { get; set; }
        public int nanos { get; set; }
        public int units { get; set; }
    }

    public class Moretaxesandfees3
    {
    }

    public class Discount3
    {
        public string currencyCode { get; set; }
        public int units { get; set; }
        public int nanos { get; set; }
    }

    public class Totalwithoutdiscount3
    {
        public string currencyCode { get; set; }
        public int units { get; set; }
        public int nanos { get; set; }
    }

    public class Totalwithoutdiscountrounded1
    {
        public string currencyCode { get; set; }
        public int nanos { get; set; }
        public int units { get; set; }
    }

    public class Traveller
    {
        public string travellerReference { get; set; }
        public string type { get; set; }
        public int age { get; set; }
    }

    public class Includedproductsbysegment
    {
        public string travellerReference { get; set; }
        public Travellerproduct[] travellerProducts { get; set; }
    }

    public class Travellerproduct
    {
        public string type { get; set; }
        public Product product { get; set; }
    }

    public class Product
    {
        public string luggageType { get; set; }
        public string ruleType { get; set; }
        public int maxPiece { get; set; }
        public float maxWeightPerPiece { get; set; }
        public string massUnit { get; set; }
        public Sizerestrictions2 sizeRestrictions { get; set; }
    }

    public class Sizerestrictions2
    {
        public float maxLength { get; set; }
        public float maxWidth { get; set; }
        public float maxHeight { get; set; }
        public string sizeUnit { get; set; }
    }

    public class Extraproduct
    {
        public string type { get; set; }
        public Pricebreakdown3 priceBreakdown { get; set; }
    }

    public class Pricebreakdown3
    {
        public Total4 total { get; set; }
        public Basefare4 baseFare { get; set; }
        public Fee4 fee { get; set; }
        public Tax4 tax { get; set; }
        public Moretaxesandfees4 moreTaxesAndFees { get; set; }
        public Discount4 discount { get; set; }
        public Totalwithoutdiscount4 totalWithoutDiscount { get; set; }
    }

    public class Total4
    {
        public string currencyCode { get; set; }
        public int units { get; set; }
        public int nanos { get; set; }
    }

    public class Basefare4
    {
        public string currencyCode { get; set; }
        public int units { get; set; }
        public int nanos { get; set; }
    }

    public class Fee4
    {
        public string currencyCode { get; set; }
        public int units { get; set; }
        public int nanos { get; set; }
    }

    public class Tax4
    {
        public string currencyCode { get; set; }
        public int units { get; set; }
        public int nanos { get; set; }
    }

    public class Moretaxesandfees4
    {
    }

    public class Discount4
    {
        public string currencyCode { get; set; }
        public int units { get; set; }
        public int nanos { get; set; }
    }

    public class Totalwithoutdiscount4
    {
        public string currencyCode { get; set; }
        public int units { get; set; }
        public int nanos { get; set; }
    }

    public class Baggagepolicy
    {
        public string code { get; set; }
        public string name { get; set; }
        public string url { get; set; }
    }
}
