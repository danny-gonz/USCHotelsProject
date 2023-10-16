using Newtonsoft.Json;

namespace USCHotelsProject.Models.Requests
{
    public  class CheckDate
    {
        [JsonProperty("day")]
        public long Day { get; set; }

        [JsonProperty("month")]
        public long Month { get; set; }

        [JsonProperty("year")]
        public long Year { get; set; }
    }


}









