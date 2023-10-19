using TestAPI.Entities;

namespace TestAPI.Services
{
    public interface IBookingService
    {
        Task<IEnumerable<Booking>> GetBookingsByHotelAsync(int hotelId);
        Task<bool> UpdateBookingAsync(Booking booking);
    }
}
