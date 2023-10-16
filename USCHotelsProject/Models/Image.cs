using Newtonsoft.Json;

namespace USCHotelsProject.Models
{
    public class Image
    {
        [JsonProperty("url")]
        public string Url { get; set; }
    }
}
