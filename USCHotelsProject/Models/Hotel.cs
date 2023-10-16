using Newtonsoft.Json;

namespace USCHotelsProject.Models
{
    public class Hotel
    {
        
            [JsonProperty("id")]
            public string Id { get; set; }

            [JsonProperty("name")]
            public string Name { get; set; }

            [JsonProperty("propertyImage")]
            public PropertyImage PropertyImage { get; set; }

            [JsonProperty("destinationInfo")]
            public DestinationInfo DestinationInfo { get; set; }




    }
}
