using AutoMapper;
using Moq;
using System;
using System.Threading.Tasks;
using Trip_Management_Api.Controllers;
using Trip_Management_Contracts;
using Trip_Management_Entities.DataTransferObjects;
using Trip_Management_Entities.Models;
using Xunit;

namespace TripApi_Tests
{
    public class TripApiTests
    {
        public Mock<IRepositoryManager> mockRepo = new Mock<IRepositoryManager>();
        public Mock<IMapper> mockAutoMapper = new Mock<IMapper>();

        [Fact]
        public async void ComparingInvalidTripEntity()
        {
            var tripDto = new Trip()
            {
                 TripId = 1,
                 IsCancelled = "N",
                 Trip_Start_Date = new DateTimeOffset(),
                 Trip_End_Date = new DateTimeOffset(),
                 TripName = "Tripabc",
                 Trip_Start_Location = "Doha"
            };

            mockRepo.Setup(r => r.Trip.GetTripAsync(1, false)).Returns(Task.FromResult(tripDto));

            TripController tripController = new TripController(mockRepo.Object, mockAutoMapper.Object);
            var result = await tripController.GetTrip(1);
            Assert.False(tripDto.Equals(result));
        }


        [Fact]
        public async void ComparingInvalidTripId()
        {
            var tripDto = new Trip()
            {
                TripId = 1,
                IsCancelled = "N",
                Trip_Start_Date = new DateTimeOffset(),
                Trip_End_Date = new DateTimeOffset(),
                TripName = "Tripabc",
                Trip_Start_Location = "Doha"
            };

            mockRepo.Setup(r => r.Trip.GetTripAsync(-1, false)).Returns(Task.FromResult(tripDto));

            TripController tripController = new TripController(mockRepo.Object, mockAutoMapper.Object);
            var result = await tripController.GetTrip(-1);
            Assert.False(tripDto.Equals(result));
        }
    }
}
