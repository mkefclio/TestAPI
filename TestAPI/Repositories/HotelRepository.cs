using TestAPI.Entities;

namespace TestAPI.Repositories
{
    public class HotelRepository : IHotelRepository
    {
        private List<Hotel> _hotels;
        public HotelRepository()
        {
            _hotels = new List<Hotel>
            {
                new Hotel(){Id=1, Address = "46, Vas. Sophias Avenue, Athens, Greece", Name = "Hilton Athens", StarRating=5, Bookings=null},
                new Hotel(){Id=2, Address = "108 Rue Saint-Lazare, 75008 Paris, France", Name = "Hilton Paris Opera", StarRating=5, Bookings=null},
                new Hotel(){Id=3, Address = "1 Vasileos Georgiou A, Syntagma Square Str, Greece", Name = "Hotel Grande Bretagne", StarRating=5, Bookings=null},
                new Hotel(){Id=4, Address = "Ermou 24, Athens, Greece", Name = "Athens Art Hotel", StarRating=54, Bookings=null}

            };
        }

        public async Task<Hotel> CreateHotelAsync(Hotel newHotel)
        {
            return await Task.Run(() =>
            {
                // Generating a new Id for the hotel  finding the maximum current Id and incrementing it.
                int newHotelId = _hotels.Max(hotel => hotel.Id) + 1;

                // Assign the new Id to the new hotel
                newHotel.Id = newHotelId;

                // Add the new hotel to the list
                _hotels.Add(newHotel);

                // Return the newly created hotel
                return newHotel;
            });
        }

        

        public async Task<IEnumerable<Hotel>> GetHotelsByNameAsync(string name)
        {
            return await Task.Run(() =>
            {
                return _hotels.Where(hotel => hotel.Name.ToUpper().Contains(name.ToUpper()));
            });
        }
    }
}
