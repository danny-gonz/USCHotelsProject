using USCHotelsProject.Models;
using USCHotelsProject.Models.Requests;

namespace USCHotelsProject.Services.Interfaces
{
    public interface IHotelService
    {
        Task<string> GetCityAsync(string city);
        Task<List<Hotel>> GetHotelsAsync(HotelRequest hotelRequestModel);
    }
}