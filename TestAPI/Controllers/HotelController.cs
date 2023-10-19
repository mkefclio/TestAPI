using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TestAPI.Entities;
using TestAPI.Services;

namespace TestAPI.Controllers
{
    [Route("api/hotel")]
    [ApiController]
    public class HotelController : Controller
    {
        private IHotelService _hotelService;
        public HotelController(IHotelService hotelService)
        {
            this._hotelService = hotelService;
        }

        [HttpPost()]
        [Route("CreateHotel")]
        public async Task<ActionResult<Hotel>> Create(Hotel hotel)
        {
            try
            {
                return await this._hotelService.CreateHotelAsync(hotel);
            }
            catch (Exception ex)
            {
                // Handle exceptions as needed
                return StatusCode(500, $"Internal Server Error: {ex.Message}");
            }
        }

        [HttpGet()]
        [Route("GetHotelsByName")]
        public async Task<ActionResult<IEnumerable<Hotel>>> Get(string name)
        {
            try
            {
                IEnumerable<Hotel> hotels = await this._hotelService.GetHotelsByNameAsync(name);

                if (hotels != null)
                {
                    return Ok(hotels);
                }
                else
                {
                    return NotFound(); // Return a 404 status code if no hotels are found
                }
            }
            catch (Exception ex)
            {
               return StatusCode(500, $"Internal Server Error: {ex.Message}");
            }

        }
    }
}
