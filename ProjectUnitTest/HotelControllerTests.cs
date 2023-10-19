using Autofac.Core;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using TestAPI.Controllers;
using TestAPI.Entities;
using TestAPI.Repositories;
using TestAPI.Services;
using Xunit;

namespace TestAPIUnitTests
{
    public class HotelControllerTests
    {
        private readonly Mock<IHotelService> service;
        public HotelControllerTests()
        {
            service = new Mock<IHotelService>();
        }

        [Fact]
        public async Task GetHotelsByNameAsync_WithValidName_ReturnsMatchingHotels()
        {
            // Arrange
            var controller = new HotelController(service.Object);
            var hotels = GetSampleHotel();
            var nameToSearch = "Hilton";

            // Configure the mock service to return hotels when called
            service
                .Setup(service => service.GetHotelsByNameAsync(It.IsAny<string>()))
                .ReturnsAsync((string query) => hotels.Where(h => h.Name.Contains(query)).ToList());

            // Act
            var result = await controller.Get(nameToSearch);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var model = Assert.IsAssignableFrom<IEnumerable<Hotel>>(okResult.Value);

            // Assert that the returned hotels match the expected ones
            Assert.Equal(2, model.Count()); // Assuming 2 hotels match the name
        }

        [Fact]
        public async Task CreateHotelAsync_ReturnsCreatedAtActionResult()
        {
            // Arrange
            var mockRepository = new Mock<IHotelRepository>();
            var hotelsController = new HotelController(service.Object);

            var newHotel = new Hotel
            {
                Id = 0,
                Address = "123 Test Street, Test City, Test Country",
                Name = "Test Hotel",
                StarRating = 3,
                Bookings = null
            };

            service.Setup(serv => serv.CreateHotelAsync(It.IsAny<Hotel>())).ReturnsAsync(newHotel);

            // Act
            var result = await hotelsController.Create(newHotel);

            // Assert
            Assert.Equal("123 Test Street, Test City, Test Country", result.Value.Address);
        }
   

        public List<Hotel> GetSampleHotel()
        {
        List<Hotel> _hotels = new List<Hotel>
            {
                new Hotel(){Id=1, Address = "46, Vas. Sophias Avenue, Athens, Greece", Name = "Hilton Athens", StarRating=5, Bookings=null},
                new Hotel(){Id=2, Address = "108 Rue Saint-Lazare, 75008 Paris, France", Name = "Hilton Paris Opera", StarRating=5, Bookings=null},
                new Hotel(){Id=3, Address = "1 Vasileos Georgiou A, Syntagma Square Str, Greece", Name = "Hotel Grande Bretagne", StarRating=5, Bookings=null},
                new Hotel(){Id=4, Address = "Ermou 24, Athens, Greece", Name = "Athens Art Hotel", StarRating=54, Bookings=null}
            };

            return _hotels;
        }
    }
}
