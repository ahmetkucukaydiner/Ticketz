﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ticketz.Infrastructure.Models.BookingFlightApiModels;

public class BookingFlightApiResponseModel
{
    public bool status { get; set; }

    [JsonProperty("message")]
    public string message { get; set; }
    public long timestamp { get; set; }
    public Data data { get; set; }  
    

    public class Data
    {
        public Aggregation aggregation { get; set; }
        public Flightoffer[] flightOffers { get; set; }
        public Flightdeal[] flightDeals { get; set; }
        public string atolProtectedStatus { get; set; }
        public string searchId { get; set; }
        public object[] banners { get; set; }
        public Displayoptions displayOptions { get; set; }
        public bool isOffersCabinClassExtended { get; set; }
        public Cabinclassextension cabinClassExtension { get; set; }
        public Searchcriteria searchCriteria { get; set; }
        public Baggagepolicy[] baggagePolicies { get; set; }
        public Pricealertstatus priceAlertStatus { get; set; }
    }

    public class Aggregation
    {
        public int totalCount { get; set; }
        public int filteredTotalCount { get; set; }
        public Stop[] stops { get; set; }
        public Airline[] airlines { get; set; }
        public Departureinterval[] departureIntervals { get; set; }
        public Flighttime[] flightTimes { get; set; }
        public Shortlayoverconnection shortLayoverConnection { get; set; }
        public int durationMin { get; set; }
        public int durationMax { get; set; }
        public Minprice minPrice { get; set; }
        public Minroundprice minRoundPrice { get; set; }
        public Minpricefiltered minPriceFiltered { get; set; }
        public Baggage[] baggage { get; set; }
        public Budget budget { get; set; }
        public Budgetperadult budgetPerAdult { get; set; }
        public Duration[] duration { get; set; }
        public string[] filtersOrder { get; set; }
    }

    public class Shortlayoverconnection
    {
        public int count { get; set; }
    }

    public class Minprice
    {
        public string currencyCode { get; set; }
        public int units { get; set; }
        public int nanos { get; set; }
    }

    public class Minroundprice
    {
        public string currencyCode { get; set; }
        public int units { get; set; }
        public int nanos { get; set; }
    }

    public class Minpricefiltered
    {
        public string currencyCode { get; set; }
        public int units { get; set; }
        public int nanos { get; set; }
    }

    public class Budget
    {
        public string paramName { get; set; }
        public Min min { get; set; }
        public Max max { get; set; }
    }

    public class Min
    {
        public string currencyCode { get; set; }
        public int units { get; set; }
        public int nanos { get; set; }
    }

    public class Max
    {
        public string currencyCode { get; set; }
        public int units { get; set; }
        public int nanos { get; set; }
    }

    public class Budgetperadult
    {
        public string paramName { get; set; }
        public Min1 min { get; set; }
        public Max1 max { get; set; }
    }

    public class Min1
    {
        public string currencyCode { get; set; }
        public int units { get; set; }
        public int nanos { get; set; }
    }

    public class Max1
    {
        public string currencyCode { get; set; }
        public int units { get; set; }
        public int nanos { get; set; }
    }

    public class Stop
    {
        public int numberOfStops { get; set; }
        public int count { get; set; }
        public Minprice1 minPrice { get; set; }
        public Minpriceround minPriceRound { get; set; }
    }

    public class Minprice1
    {
        public string currencyCode { get; set; }
        public int units { get; set; }
        public int nanos { get; set; }
    }

    public class Minpriceround
    {
        public string currencyCode { get; set; }
        public int units { get; set; }
        public int nanos { get; set; }
    }

    public class Airline
    {
        public string name { get; set; }
        public string logoUrl { get; set; }
        public string iataCode { get; set; }
        public int count { get; set; }
        public Minprice2 minPrice { get; set; }
    }

    public class Minprice2
    {
        public string currencyCode { get; set; }
        public int units { get; set; }
        public int nanos { get; set; }
    }

    public class Departureinterval
    {
        public string start { get; set; }
        public string end { get; set; }
    }

    public class Flighttime
    {
        public Arrival[] arrival { get; set; }
        public Departure[] departure { get; set; }
    }

    public class Arrival
    {
        public string start { get; set; }
        public string end { get; set; }
        public int count { get; set; }
    }

    public class Departure
    {
        public string start { get; set; }
        public string end { get; set; }
        public int count { get; set; }
    }

    public class Baggage
    {
        public string paramName { get; set; }
        public int count { get; set; }
        public bool enabled { get; set; }
        public string baggageType { get; set; }
    }

    public class Duration
    {
        public int min { get; set; }
        public int max { get; set; }
        public string durationType { get; set; }
        public bool enabled { get; set; }
        public string paramName { get; set; }
    }

    public class Displayoptions
    {
        public bool brandedFaresShownByDefault { get; set; }
        public bool directFlightsOnlyFilterIgnored { get; set; }
        public bool hideFlexiblePricesBanner { get; set; }
    }

    public class Cabinclassextension
    {
        public string text { get; set; }
    }

    public class Searchcriteria
    {
        public string cabinClass { get; set; }
    }

    public class Pricealertstatus
    {
        public bool isEligible { get; set; }
        public bool isSearchEligible { get; set; }
    }

    public class Flightoffer
    {
        public string token { get; set; }
        public Segment1[] segments { get; set; }
        public Pricebreakdown priceBreakdown { get; set; }
        public Travellerprice[] travellerPrices { get; set; }
        public string[] priceDisplayRequirements { get; set; }
        public string pointOfSale { get; set; }
        public string tripType { get; set; }
        public Posmismatch posMismatch { get; set; }
        public Includedproductsbysegment[][] includedProductsBySegment { get; set; }
        public Includedproducts includedProducts { get; set; }
        public Ancillaries ancillaries { get; set; }
        public Brandedfareinfo brandedFareInfo { get; set; }
        public object[] appliedDiscounts { get; set; }
        public string offerKeyToHighlight { get; set; }
        public bool requestableBrandedFares { get; set; }
        public Extraproductdisplayrequirements extraProductDisplayRequirements { get; set; }
        public Seatavailability seatAvailability { get; set; }
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
        public int piecePerPax { get; set; }
        public float maxWeightPerPiece { get; set; }
        public string massUnit { get; set; }
        public Sizerestrictions sizeRestrictions { get; set; }
        public string ruleType { get; set; }
        public float maxTotalWeight { get; set; }
    }

    public class Sizerestrictions
    {
        public float maxLength { get; set; }
        public float maxWidth { get; set; }
        public float maxHeight { get; set; }
        public string sizeUnit { get; set; }
    }

    public class Ancillaries
    {
    }

    public class Brandedfareinfo
    {
        public string fareName { get; set; }
        public string cabinClass { get; set; }
        public Feature[] features { get; set; }
        public object[] fareAttributes { get; set; }
        public bool nonIncludedFeaturesRequired { get; set; }
        public object[] nonIncludedFeatures { get; set; }
    }

    public class Feature
    {
        public string featureName { get; set; }
        public string category { get; set; }
        public string code { get; set; }
        public string label { get; set; }
        public string availability { get; set; }
    }

    public class Extraproductdisplayrequirements
    {
    }

    public class Seatavailability
    {
        public int numberOfSeatsAvailable { get; set; }
    }

    public class Segment1
    {
        public Departureairport departureAirport { get; set; }
        public Arrivalairport arrivalAirport { get; set; }
        public DateTime departureTime { get; set; }
        public DateTime arrivalTime { get; set; }
        public Leg[] legs { get; set; }
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
        public string name { get; set; }
        public string city { get; set; }
        public string cityName { get; set; }
        public string country { get; set; }
        public string countryName { get; set; }
    }

    public class Arrivalairport
    {
        public string type { get; set; }
        public string code { get; set; }
        public string name { get; set; }
        public string city { get; set; }
        public string cityName { get; set; }
        public string country { get; set; }
        public string countryName { get; set; }
    }

    public class Leg
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
        public Amenity[] amenities { get; set; }
        public string arrivalTerminal { get; set; }
        public string departureTerminal { get; set; }
    }

    public class Departureairport1
    {
        public string type { get; set; }
        public string code { get; set; }
        public string name { get; set; }
        public string city { get; set; }
        public string cityName { get; set; }
        public string country { get; set; }
        public string countryName { get; set; }
    }

    public class Arrivalairport1
    {
        public string type { get; set; }
        public string code { get; set; }
        public string name { get; set; }
        public string city { get; set; }
        public string cityName { get; set; }
        public string country { get; set; }
        public string countryName { get; set; }
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

    public class Amenity
    {
        public string category { get; set; }
        public string model { get; set; }
        public string cost { get; set; }
        public object type { get; set; }
        public string legroom { get; set; }
        public int pitch { get; set; }
        public string pitchUnit { get; set; }
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
        public float maxTotalWeight { get; set; }
        public string massUnit { get; set; }
        public int maxPiece { get; set; }
    }

    public class Travellercabinluggage
    {
        public string travellerReference { get; set; }
        public Luggageallowance1 luggageAllowance { get; set; }
        public bool personalItem { get; set; }
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
        public Total1 total { get; set; }
        public Basefare1 baseFare { get; set; }
        public Fee1 fee { get; set; }
        public Tax1 tax { get; set; }
        public Totalrounded1 totalRounded { get; set; }
        public Moretaxesandfees1 moreTaxesAndFees { get; set; }
        public Discount1 discount { get; set; }
        public Totalwithoutdiscount1 totalWithoutDiscount { get; set; }
        public Totalwithoutdiscountrounded1 totalWithoutDiscountRounded { get; set; }
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

    public class Totalrounded1
    {
        public string currencyCode { get; set; }
        public int nanos { get; set; }
        public int units { get; set; }
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

    public class Totalwithoutdiscountrounded1
    {
        public string currencyCode { get; set; }
        public int nanos { get; set; }
        public int units { get; set; }
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
        public float maxTotalWeight { get; set; }
        public string massUnit { get; set; }
        public int maxPiece { get; set; }
        public float maxWeightPerPiece { get; set; }
        public Sizerestrictions2 sizeRestrictions { get; set; }
    }

    public class Sizerestrictions2
    {
        public float maxLength { get; set; }
        public float maxWidth { get; set; }
        public float maxHeight { get; set; }
        public string sizeUnit { get; set; }
    }

    public class Flightdeal
    {
        public string key { get; set; }
        public string offerToken { get; set; }
        public Price price { get; set; }
        public Travellerprice1[] travellerPrices { get; set; }
    }

    public class Price
    {
        public string currencyCode { get; set; }
        public int units { get; set; }
        public int nanos { get; set; }
    }

    public class Travellerprice1
    {
        public Travellerpricebreakdown1 travellerPriceBreakdown { get; set; }
        public string travellerReference { get; set; }
        public string travellerType { get; set; }
    }

    public class Travellerpricebreakdown1
    {
        public Total2 total { get; set; }
        public Basefare2 baseFare { get; set; }
        public Fee2 fee { get; set; }
        public Tax2 tax { get; set; }
        public Totalrounded2 totalRounded { get; set; }
        public Moretaxesandfees2 moreTaxesAndFees { get; set; }
        public Discount2 discount { get; set; }
        public Totalwithoutdiscount2 totalWithoutDiscount { get; set; }
        public Totalwithoutdiscountrounded2 totalWithoutDiscountRounded { get; set; }
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

    public class Totalrounded2
    {
        public string currencyCode { get; set; }
        public int nanos { get; set; }
        public int units { get; set; }
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

    public class Totalwithoutdiscountrounded2
    {
        public string currencyCode { get; set; }
        public int nanos { get; set; }
        public int units { get; set; }
    }

    public class Baggagepolicy
    {
        public string code { get; set; }
        public string name { get; set; }
        public string url { get; set; }
    }
}