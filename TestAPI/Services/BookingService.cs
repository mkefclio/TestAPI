using TestAPI.Entities;
using TestAPI.Repositories;

namespace TestAPI.Services
{
    public class BookingService : IBookingService
    {
        private readonly IBookingRepository _repository;
        public BookingService(IBookingRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Booking>> GetBookingsByHotelAsync(int hotelId)
        {
            return await _repository.GetBookingsByHotelAsync(hotelId);
        }

        public async Task<bool> UpdateBookingAsync(Booking booking)
        {
            return await _repository.UpdateBookingAsync(booking);
        }
    }
}
