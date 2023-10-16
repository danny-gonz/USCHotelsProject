using Newtonsoft.Json;
using static System.Net.Mime.MediaTypeNames;

namespace USCHotelsProject.Models
{
    public class PropertyImage
    {
        [JsonProperty("image")]
        public Image Image { get; set; }
    }
}