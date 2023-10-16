using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace USCHotelsProject.Models.Requests
{
    public class HotelRequest
    {


        [JsonProperty("currency")]
        public string Currency { get; set; }

        [JsonProperty("eapid")]
        public int Eapid { get; set; }

        [JsonProperty("locale")]
        public string Locale { get; set; }

        [JsonProperty("siteId")]
        public long SiteId { get; set; }

        [JsonProperty("destination")]
        public Destination? Destination { get; set; }

        [JsonProperty("checkInDate")]
        [Required]
        public CheckDate CheckInDate { get; set; }

        [JsonProperty("checkOutDate")]
        [Required]
        public CheckDate CheckOutDate { get; set; }

        [JsonProperty("rooms")]
        public Rooms[] Rooms { get; set; }

        [JsonProperty("resultsStartingIndex")]
        public long ResultsStartingIndex { get; set; }

        [JsonProperty("resultsSize")]
        public long ResultsSize { get; set; }

        [JsonProperty("sort")]
        public string Sort { get; set; }

        [JsonProperty("filters")]
        public Filters Filters { get; set; }
    }


}









