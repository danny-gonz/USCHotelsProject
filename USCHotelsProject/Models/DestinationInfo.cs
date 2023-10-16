using Newtonsoft.Json;

namespace USCHotelsProject.Models
{
    public class DestinationInfo
    {
        [JsonProperty("distanceFromMessaging")]
        public string DistanceInfo { get; set; }
    }
}