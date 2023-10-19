using TestAPI.Entities;

namespace TestAPI.Repositories
{
    public interface IHotelRepository
    {
        Task<IEnumerable<Hotel>> GetHotelsByNameAsync(string name);
        Task<Hotel> CreateHotelAsync(Hotel hotel);
    }
}
