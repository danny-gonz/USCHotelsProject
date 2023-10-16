using Newtonsoft.Json;

namespace USCHotelsProject.Models.Requests
{
    public  class Rooms
    {
        [JsonProperty("adults")]
        public long Adults { get; set; }

        [JsonProperty("children")]
        public Child[] Children { get; set; }
    }


}









