using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestAPI.Controllers;
using TestAPI.Entities;
using TestAPI.Repositories;
using TestAPI.Services;
using static System.Collections.Specialized.BitVector32;

namespace TestAPIUnitTests
{
    public class BookingControllerTests
    {
        private readonly Mock<IBookingService> service;
        public BookingControllerTests()
        {
            service = new Mock<IBookingService>();
        }

        [Fact]
        public async Task GetBookingsByHotelAsync_ReturnsListOfBookingsForHotel()
        {
            // Arrange
            var controller = new BookingController(service.Object);
            var hotels = this.GetSampleBookings();
            int hotelId = 1;

            // Configure the mock service to return hotels when called
            service
                .Setup(service => service.GetBookingsByHotelAsync(It.IsAny<int>()))
                .ReturnsAsync((int query) => hotels.Where(h => h.HotelId.Equals(query)).ToList());

            // Act
            var result = await controller.Get(hotelId);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var model = Assert.IsAssignableFrom<IEnumerable<Booking>>(okResult.Value);

            // Assert that the returned hotels match the expected ones
            Assert.Equal(2, model.Count()); // Assuming 2 hotels match the name
        }

        [Fact]
        public async Task UpdateBookingAsync_ValidBooking_ReturnsOk()
        {
            // Arrange
            var booking = new Booking
            {
                // Create a valid booking object
                Id = 1,
                CustomerName = "John Doe",
                HotelId = 1,
                NumberOfPax = 2
            };

            var mockService = new Mock<IBookingService>();
            mockService.Setup(repo => repo.UpdateBookingAsync(It.IsAny<Booking>())).ReturnsAsync(true);

            var controller = new BookingController(mockService.Object);

            // Act
            var result = await controller.Update(booking);

            // Assert
            Assert.True(result.Value);// Assuming the booking returns true
        }

        public List<Booking> GetSampleBookings()
        {
            List<Booking> _bookings = new List<Booking>
            {
                new Booking() { Id = 1,CustomerName = "Manos Kefalas",HotelId = 1,NumberOfPax = 2},
                new Booking() { Id = 2,CustomerName = "Nikos Gewrgiou",HotelId = 1,NumberOfPax = 1},
                new Booking() { Id = 3,CustomerName = "Maria Nikou",HotelId = 2,NumberOfPax = 3},
                new Booking() { Id = 4,CustomerName = "Eleni Kourpi",HotelId = 3,NumberOfPax = 2}
            };

            return _bookings;
        }
    }
}

