using TestAPI.Entities;

namespace TestAPI.Services
{
    public interface IHotelService
    {
        Task<IEnumerable<Hotel>> GetHotelsByNameAsync(string name);
        Task<Hotel> CreateHotelAsync(Hotel hotel);
    }
}
