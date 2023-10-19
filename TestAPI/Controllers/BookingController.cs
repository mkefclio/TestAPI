using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TestAPI.Entities;
using TestAPI.Services;

namespace TestAPI.Controllers
{
    [Route("api/booking")]
    [ApiController]
    public class BookingController : Controller
    {
        private readonly IBookingService _bookingService;
        public BookingController(IBookingService bookingService)
        {
            this._bookingService = bookingService;
        }
        
        
        [HttpGet()]
        [Route("GetBookingsByHotelId")]
        public async Task<ActionResult<IEnumerable<Booking>>> Get(int hotelId)
        {
            try
            {
                IEnumerable<Booking> bookings = await this._bookingService.GetBookingsByHotelAsync(hotelId);

                if (bookings != null)
                {
                    return Ok(bookings);
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
       
        [HttpPost()]
        [Route("UpdateBooking")]
        public async Task<ActionResult<bool>> Update(Booking booking)
        {
            try
            {
                return await this._bookingService.UpdateBookingAsync(booking);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal Server Error: {ex.Message}");
            }
        }
       
    }
}
