using TestAPI.Entities;

namespace TestAPI.Repositories
{
    public interface IBookingRepository
    {
        Task<IEnumerable<Booking>> GetBookingsByHotelAsync(int hotelId);
        Task<bool> UpdateBookingAsync(Booking booking);
    }
}
