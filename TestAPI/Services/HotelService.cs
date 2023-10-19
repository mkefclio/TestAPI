using TestAPI.Entities;
using TestAPI.Repositories;

namespace TestAPI.Services
{
    public class HotelService : IHotelService
    {
        private readonly IHotelRepository _repository;

        public HotelService(IHotelRepository repository)
        {
            _repository = repository;
        }

        public async Task<Hotel> CreateHotelAsync(Hotel hotel)
        {
            return await _repository.CreateHotelAsync(hotel);
        }

        public async Task<IEnumerable<Hotel>> GetHotelsByNameAsync(string name)
        {
            return await _repository.GetHotelsByNameAsync(name);
        }
    }
}
