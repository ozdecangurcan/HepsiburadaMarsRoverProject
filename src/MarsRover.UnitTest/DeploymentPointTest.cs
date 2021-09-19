using MarsRover.Application.Dtos;
using MarsRover.Application.Dtos.Request;
using MarsRover.Domain.Entities;
using MarsRover.Infrastructure.Services;
using MarsRover.UnitTest.MockData;
using System.Collections.Generic;
using Xunit;

namespace MarsRover.UnitTest
{
    public class DeploymentPointTest
    {
        private readonly DeploymentPointService _deploymentPointService;

        public DeploymentPointTest()
        {
            _deploymentPointService = new DeploymentPointService();
        }

        [Fact]
        public void PrepareDeploymentPoint_WhenValidParameters_ReturnSuccess()
        {
            var coordinates = new List<string> { "1", "2", "N" };

            var plateau = new PlateauResponseDto
            {
                Plateau = new PlateauModel(5, 5)
            };

            var request = new DeploymentPointRequestDto(coordinates, plateau);

            var response = _deploymentPointService.PrepareDeploymentPoint(request);

            Assert.True(response.IsSuccess);
            Assert.Null(response.Message);
            Assert.Equal(response.DeploymentPoint.X, int.Parse(request.DeploymentCoordinates[0]));
            Assert.Equal(response.DeploymentPoint.Y, int.Parse(request.DeploymentCoordinates[1]));
        }

        [Fact]
        public void PrepareDeploymentPoint_WhenInvalidCoordinateParameters_ReturnError()
        {
            var mockData = new PlateauMockData();
            mockData.Coordinates.Add(new Coordinate() { CoordinateParameters = new List<string> { "1", "2" } });
            mockData.Coordinates.Add(new Coordinate() { CoordinateParameters = new List<string> { "A", "2", "N" } });
            mockData.Coordinates.Add(new Coordinate() { CoordinateParameters = new List<string> { "2", "A", "N" } });
            mockData.Coordinates.Add(new Coordinate() { CoordinateParameters = new List<string> { "2", "3", "F" } });
            mockData.Coordinates.Add(new Coordinate() { CoordinateParameters = new List<string> { "2", "3", "" } });
            mockData.Coordinates.Add(new Coordinate() { CoordinateParameters = new List<string> { "-2", "3", "N" } });
            mockData.Coordinates.Add(new Coordinate() { CoordinateParameters = new List<string> { "2", "-3", "N" } });
            mockData.Coordinates.Add(new Coordinate() { CoordinateParameters = new List<string> { "2", "3", "0" } });

            var plateau = new PlateauResponseDto
            {
                Plateau = new PlateauModel(5, 5)
            };

            foreach (var coordinate in mockData.Coordinates)
            {
                var request = new DeploymentPointRequestDto(coordinate.CoordinateParameters, plateau);
                var response = _deploymentPointService.PrepareDeploymentPoint(request);

                Assert.False(response.IsSuccess);
                Assert.NotNull(response.Message);
                Assert.Null(response.DeploymentPoint);
            }
        }

        [Fact]
        public void PrepareDeploymentPoint_WhenDeploymentPointOutOfRange_ReturnError()
        {
            var mockData = new PlateauMockData();

            mockData.Coordinates.Add(new Coordinate() { CoordinateParameters = new List<string> { "1", "6", "N" } });
            mockData.Coordinates.Add(new Coordinate() { CoordinateParameters = new List<string> { "6", "1", "N" } });

            var plateau = new PlateauResponseDto
            {
                Plateau = new PlateauModel(5, 5)
            };

            foreach (var coordinate in mockData.Coordinates)
            {
                var request = new DeploymentPointRequestDto(coordinate.CoordinateParameters, plateau);
                var response = _deploymentPointService.PrepareDeploymentPoint(request);

                Assert.False(response.IsSuccess);
                Assert.NotNull(response.Message);
                Assert.Null(response.DeploymentPoint);
            }
        }
    }
}
