using Newtonsoft.Json;

namespace USCHotelsProject.Models.Requests
{
    public  class Filters
    {
        [JsonProperty("price")]
        public Price Price { get; set; }
    }


}









