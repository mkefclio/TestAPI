using TestAPI.Entities;

namespace TestAPI.Repositories
{
    public class BookingRepository : IBookingRepository
    {
        private List<Booking> _bookings;
        public BookingRepository()
        {
            _bookings = new List<Booking>
            {
                new Booking(){Id=1,CustomerName="Manos Kefalas",HotelId=1,NumberOfPax=2},
                new Booking(){Id=2,CustomerName="Nikos Gewrgiou",HotelId=1,NumberOfPax=1},
                new Booking(){Id=3,CustomerName="Maria Nikou",HotelId=2,NumberOfPax=3},
                new Booking(){Id=4,CustomerName="Eleni Kourpi",HotelId=3,NumberOfPax=2}
             };

        }

        public async Task<IEnumerable<Booking>> GetBookingsByHotelAsync(int hotelId)
        {
            return await Task.Run(() =>
            {
                return _bookings.Where(b => b.HotelId == hotelId);
            });
        }
       
        public async Task<bool> UpdateBookingAsync(Booking booking)
        {
            return await Task.Run(() =>
            {
                // Find the booking in the list by its ID
                var bookingToUpdate = _bookings.FirstOrDefault(b => b.Id == booking.Id);
                

                if (bookingToUpdate != null)
                {
                    // Update the booking's properties
                    bookingToUpdate.HotelId = booking.HotelId;
                    bookingToUpdate.CustomerName = booking.CustomerName;
                    bookingToUpdate.NumberOfPax = booking.NumberOfPax;
                    return true; // Return true for a successful update
                }

                return false; // Return false if the booking was not found
            });
        }
    }
}

