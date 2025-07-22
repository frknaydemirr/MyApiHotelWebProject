using System.Collections.Generic;

namespace RapiApiConsume.Models
{
   
    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
    public class AllInclusiveAmount
    {
        public string currency { get; set; }
        public string amount_unrounded { get; set; }
        public string amount_rounded { get; set; }
        public double value { get; set; }
    }

    public class AllInclusiveAmountHotelCurrency
    {
        public string amount_rounded { get; set; }
        public string amount_unrounded { get; set; }
        public string currency { get; set; }
        public double value { get; set; }
    }

    public class Amount
    {
        public int value { get; set; }
        public string currency { get; set; }
    }

    public class Badge
    {
        public string id { get; set; }
        public string text { get; set; }
        public string badge_variant { get; set; }
    }

    public class Base
    {
        public string kind { get; set; }
        public double base_amount { get; set; }
        public double? percentage { get; set; }
    }

    public class Benefit
    {
        public string kind { get; set; }
        public string badge_variant { get; set; }
        public string identifier { get; set; }
        public object icon { get; set; }
        public string details { get; set; }
        public string name { get; set; }
    }

    public class BookingHome
    {
        public int is_booking_home { get; set; }
        public string is_single_unit_property { get; set; }
        public string group { get; set; }
        public int segment { get; set; }
        public double quality_class { get; set; }
    }

    public class Bwallet
    {
        public int hotel_eligibility { get; set; }
    }

    public class ChargesDetails
    {
        public string translated_copy { get; set; }
        public string mode { get; set; }
        public Amount amount { get; set; }
    }

    public class Checkin
    {
        public string until { get; set; }
        public string from { get; set; }
    }

    public class Checkout
    {
        public string until { get; set; }
        public string from { get; set; }
    }

    public class CompositePriceBreakdown
    {
        public IncludedTaxesAndChargesAmount included_taxes_and_charges_amount { get; set; }
        public DiscountedAmount discounted_amount { get; set; }
        public GrossAmountHotelCurrency gross_amount_hotel_currency { get; set; }
        public GrossAmount gross_amount { get; set; }
        public NetAmount net_amount { get; set; }
        public AllInclusiveAmountHotelCurrency all_inclusive_amount_hotel_currency { get; set; }
        public ExcludedAmount excluded_amount { get; set; }
        public List<PriceDisplayConfig> price_display_config { get; set; }
        public StrikethroughAmount strikethrough_amount { get; set; }
        public StrikethroughAmountPerNight strikethrough_amount_per_night { get; set; }
        public GrossAmountPerNight gross_amount_per_night { get; set; }
        public List<Benefit> benefits { get; set; }
        public List<ProductPriceBreakdown> product_price_breakdowns { get; set; }
        public ChargesDetails charges_details { get; set; }
        public AllInclusiveAmount all_inclusive_amount { get; set; }
        public List<Item> items { get; set; }
    }

    public class DiscountedAmount
    {
        public double value { get; set; }
        public string currency { get; set; }
        public string amount_unrounded { get; set; }
        public string amount_rounded { get; set; }
    }

    public class Distance
    {
        public string icon_name { get; set; }
        public object icon_set { get; set; }
        public string text { get; set; }
    }

    public class ExcludedAmount
    {
        public int value { get; set; }
        public string currency { get; set; }
        public string amount_rounded { get; set; }
        public string amount_unrounded { get; set; }
    }

    public class ExternalReviews
    {
        public int num_reviews { get; set; }
        public double score { get; set; }
        public string score_word { get; set; }
        public string should_display { get; set; }
    }

    public class GrossAmount
    {
        public string amount_unrounded { get; set; }
        public string amount_rounded { get; set; }
        public string currency { get; set; }
        public double value { get; set; }
    }

    public class GrossAmountHotelCurrency
    {
        public double value { get; set; }
        public string currency { get; set; }
        public string amount_unrounded { get; set; }
        public string amount_rounded { get; set; }
    }

    public class GrossAmountPerNight
    {
        public string amount_rounded { get; set; }
        public string amount_unrounded { get; set; }
        public string currency { get; set; }
        public double value { get; set; }
    }

    public class IncludedTaxesAndChargesAmount
    {
        public double value { get; set; }
        public string amount_rounded { get; set; }
        public string amount_unrounded { get; set; }
        public string currency { get; set; }
    }

    public class Item
    {
        public Base @base { get; set; }
        public string details { get; set; }
        public string name { get; set; }
        public string inclusion_type { get; set; }
        public string kind { get; set; }
        public ItemAmount item_amount { get; set; }
        public string identifier { get; set; }
    }

    public class ItemAmount
    {
        public string amount_unrounded { get; set; }
        public string amount_rounded { get; set; }
        public string currency { get; set; }
        public double value { get; set; }
    }

    public class MapBoundingBox
    {
        public double ne_lat { get; set; }
        public double ne_long { get; set; }
        public double sw_lat { get; set; }
        public double sw_long { get; set; }
    }

    public class MatchingUnitsCommonConfig
    {
        public string localized_area { get; set; }
        public int unit_type_id { get; set; }
    }

    public class MatchingUnitsConfiguration
    {
        public MatchingUnitsCommonConfig matching_units_common_config { get; set; }
    }

    public class NetAmount
    {
        public string currency { get; set; }
        public string amount_rounded { get; set; }
        public string amount_unrounded { get; set; }
        public double value { get; set; }
    }

    public class PriceBreakdown
    {
        public object gross_price { get; set; }
        public int has_tax_exceptions { get; set; }
        public int has_incalculable_charges { get; set; }
        public string currency { get; set; }
        public int has_fine_print_charges { get; set; }
        public string sum_excluded_raw { get; set; }
        public double all_inclusive_price { get; set; }
    }

    public class PriceDisplayConfig
    {
        public string key { get; set; }
        public int value { get; set; }
    }

    public class ProductPriceBreakdown
    {
        public ExcludedAmount excluded_amount { get; set; }
        public AllInclusiveAmountHotelCurrency all_inclusive_amount_hotel_currency { get; set; }
        public NetAmount net_amount { get; set; }
        public GrossAmount gross_amount { get; set; }
        public GrossAmountHotelCurrency gross_amount_hotel_currency { get; set; }
        public DiscountedAmount discounted_amount { get; set; }
        public IncludedTaxesAndChargesAmount included_taxes_and_charges_amount { get; set; }
        public List<Item> items { get; set; }
        public ChargesDetails charges_details { get; set; }
        public AllInclusiveAmount all_inclusive_amount { get; set; }
        public List<Benefit> benefits { get; set; }
        public GrossAmountPerNight gross_amount_per_night { get; set; }
        public StrikethroughAmountPerNight strikethrough_amount_per_night { get; set; }
        public List<PriceDisplayConfig> price_display_config { get; set; }
        public StrikethroughAmount strikethrough_amount { get; set; }
    }

    public class Result
    {
        public PriceBreakdown price_breakdown { get; set; }
        public string main_photo_url { get; set; }
        public string crib_guaranteed { get; set; }
        public string zip { get; set; }
        public string hotel_name { get; set; }
        public int is_smart_deal { get; set; }
        public int is_genius_deal { get; set; }
        public string distance_to_cc_formatted { get; set; }
        public string city_in_trans { get; set; }
        public string native_ad_id { get; set; }
        public double min_total_price { get; set; }
        public int is_city_center { get; set; }
        public double mobile_discount_percentage { get; set; }
        public int hotel_id { get; set; }
        public string address { get; set; }
        public int wishlist_count { get; set; }
        public int is_tpi_exclusive_property { get; set; }
        public string accommodation_type_name { get; set; }
        public object updated_checkout { get; set; }
        public int preferred_plus { get; set; }
        public int price_is_final { get; set; }
        public int cant_book { get; set; }
        public string districts { get; set; }
        public string district { get; set; }
        public string cc1 { get; set; }
        public double longitude { get; set; }
        public int genius_discount_percentage { get; set; }
        public CompositePriceBreakdown composite_price_breakdown { get; set; }
        public int main_photo_id { get; set; }
        public BookingHome booking_home { get; set; }
        public string default_wishlist_name { get; set; }
        public int preferred { get; set; }
        public List<Badge> badges { get; set; }
        public Checkout checkout { get; set; }
        public List<string> block_ids { get; set; }
        public string distance_to_cc { get; set; }
        public MatchingUnitsConfiguration matching_units_configuration { get; set; }
        public int review_nr { get; set; }
        public string countrycode { get; set; }
        public int class_is_estimated { get; set; }
        public int soldout { get; set; }
        public string is_geo_rate { get; set; }
        public int extended { get; set; }
        public string city { get; set; }
        public int is_no_prepayment_block { get; set; }
        public string review_recommendation { get; set; }
        public int cc_required { get; set; }
        public string city_trans { get; set; }
        public string currencycode { get; set; }
        public string default_language { get; set; }
        public string type { get; set; }
        public string native_ads_tracking { get; set; }
        public double latitude { get; set; }
        public string id { get; set; }
        public Checkin checkin { get; set; }
        public string unit_configuration_label { get; set; }
        public int district_id { get; set; }
        public string review_score_word { get; set; }
        public int is_beach_front { get; set; }
        public string city_name_en { get; set; }
        public string currency_code { get; set; }
        public object selected_review_topic { get; set; }
        public Bwallet bwallet { get; set; }
        public int hotel_include_breakfast { get; set; }
        public double review_score { get; set; }
        public string hotel_name_trans { get; set; }
        public int in_best_district { get; set; }
        public int hotel_has_vb_boost { get; set; }
        public string country_trans { get; set; }
        public object updated_checkin { get; set; }
        public int children_not_allowed { get; set; }
        public List<Distance> distances { get; set; }
        public string distance { get; set; }
        public string url { get; set; }
        public int is_free_cancellable { get; set; }
        public double native_ads_cpc { get; set; }
        public string timezone { get; set; }
        public string address_trans { get; set; }
        public int is_mobile_deal { get; set; }
        public int ufi { get; set; }
        public string hotel_facilities { get; set; }
        public int property_cribs_availability { get; set; }
        public int accommodation_type { get; set; }
        public double @class { get; set; }
        public string max_photo_url { get; set; }
        public string max_1440_photo_url { get; set; }
        public ExternalReviews external_reviews { get; set; }
        public int? has_swimming_pool { get; set; }
        public string ribbon_text { get; set; }
        public int? has_free_parking { get; set; }
    }

    public class RoomDistribution
    {
        public List<int> children { get; set; }
        public string adults { get; set; }
    }

    public class Root
    {
        public int primary_count { get; set; }
        public int count { get; set; }
        public List<RoomDistribution> room_distribution { get; set; }
        public MapBoundingBox map_bounding_box { get; set; }
        public int total_count_with_filters { get; set; }
        public int unfiltered_count { get; set; }
        public int extended_count { get; set; }
        public int unfiltered_primary_count { get; set; }
        public double search_radius { get; set; }
        public List<Sort> sort { get; set; }
        public List<Result> result { get; set; }
    }

    public class Sort
    {
        public string name { get; set; }
        public string id { get; set; }
    }

    public class StrikethroughAmount
    {
        public double value { get; set; }
        public string currency { get; set; }
        public string amount_rounded { get; set; }
        public string amount_unrounded { get; set; }
    }

    public class StrikethroughAmountPerNight
    {
        public double value { get; set; }
        public string amount_unrounded { get; set; }
        public string amount_rounded { get; set; }
        public string currency { get; set; }
    }


}
