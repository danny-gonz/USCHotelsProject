using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Text;
using USCHotelsProject.AppSettings;
using USCHotelsProject.Models;
using USCHotelsProject.Models.Requests;
using USCHotelsProject.Services.Interfaces;

namespace USCHotelsProject.Services
{
    public class HotelService : IHotelService
        
    {
        private readonly HotelConfigKeys _config;
        private readonly IHttpClientFactory _httpClientFactory;
        public HotelService(IHttpClientFactory httpClientFactory, IOptions<HotelConfigKeys>config)
        {
            _config = config.Value;
            _httpClientFactory = httpClientFactory;

        }


        public async Task<string> GetCityAsync(string city)
        {

            var httpClient = _httpClientFactory.CreateClient("hotelRapidApi");

            string cityId = null;

            var response = await httpClient.GetAsync($"locations/v3/search?q={city}&locale={_config.Locale}&langid={_config.LangId}&siteid={_config.SiteId}");

            if (response.IsSuccessStatusCode)
            {
                var jsonResponse = await response.Content.ReadAsStringAsync();

                JObject jsonDataObj = JObject.Parse(jsonResponse);

                JArray arrayOfApiData = (JArray)jsonDataObj["sr"];

                if (arrayOfApiData != null && arrayOfApiData.Count > 0)
                {
                    cityId = (string)arrayOfApiData[0]["gaiaId"];

                }

            }

            return cityId;
        }

        public async Task<List<Hotel>> GetHotelsAsync(HotelRequest hotelRequestModel)
        {

            var httpClient = _httpClientFactory.CreateClient("hotelRapidApi");
            string json = JsonConvert.SerializeObject(hotelRequestModel);
            StringContent stringContent = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await httpClient.PostAsync("properties/v2/list", stringContent);


            response.EnsureSuccessStatusCode();
            var body = await response.Content.ReadAsStringAsync();



            JObject jsonObject = JsonConvert.DeserializeObject<JObject>(body);

            JToken properties = jsonObject["data"]["propertySearch"]["properties"];


            List<Hotel> propertyList = properties.ToObject<List<Hotel>>();



            return propertyList;


        }
    }
}
