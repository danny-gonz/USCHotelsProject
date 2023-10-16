using Newtonsoft.Json;

namespace USCHotelsProject.Models.Requests
{
    public  class Price
    {
        [JsonProperty("max")]
        public long Max { get; set; }

        [JsonProperty("min")]
        public long Min { get; set; }
    }


}









