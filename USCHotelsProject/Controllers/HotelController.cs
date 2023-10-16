using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using USCHotelsProject.Models.Requests;
using USCHotelsProject.Services.Interfaces;

namespace USCHotelsProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HotelController : ControllerBase
    {

        private IHotelService _hotelService;

        public HotelController(IHotelService hotelService)
        {
            _hotelService = hotelService;
        }


        [HttpPost]
        public async Task<IActionResult> GetHotel(string city, HotelRequest hotelRequest)
        {


            try

            {

                string citLocId = await _hotelService.GetCityAsync(city);

                if (citLocId != null)
                {
                    hotelRequest.Destination = new Destination();
                    hotelRequest.Destination.RegionId = citLocId;


                    var hotelProp = await _hotelService.GetHotelsAsync(hotelRequest);

                    if (hotelProp != null)
                    {
                        return Ok(hotelProp);
                    }

                    else { return BadRequest("No Hotels Found"); }

                }
                else
                {

                    return BadRequest("No City Found");


                }


            }
            catch (Exception ex)
            {


                return StatusCode(500, ex.Message);




            }

        }
    }
}
