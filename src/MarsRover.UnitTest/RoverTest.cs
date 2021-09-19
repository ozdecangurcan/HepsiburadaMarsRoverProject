using MarsRover.Application.Dtos;
using MarsRover.Application.Dtos.Request;
using MarsRover.Domain.Entities;
using MarsRover.Domain.Enums;
using MarsRover.Infrastructure.Services;
using System;
using System.Linq;
using Xunit;

namespace MarsRover.UnitTest
{
    public class RoverTest
    {
        private readonly RoverService _roverService;

        public RoverTest()
        {
            _roverService = new RoverService();
        }

        [Theory]
        [InlineData("LMLMLMLMM")]
        [InlineData("MMRMMRMRRM")]
        [InlineData("MM")]
        public void CalculateMovement_WhenValidParameters_ReturnSuccess(string movements)
        {
            var plateau = new PlateauResponseDto
            {
                Plateau = new PlateauModel(5, 5)
            };

            var deployment = new DeploymentPointResponseDto
            {
                DeploymentPoint = new DeploymentPointModel(1, 2, Directions.N)
            };

            var movementList = movements.ToCharArray().Select(x => Enum.Parse<Moves>(x.ToString())).ToList();

            var request = new RoverRequestDto
            {
                DeploymentPointResponse = deployment,
                PlateauResponse = plateau,
                Movements = movementList
            };

            var response = _roverService.CalculateMovement(request);

            Assert.True(response.IsSuccess);
            Assert.Null(response.Message);
            Assert.NotNull(response.Rover.DeploymentPoint);
        }

        [Theory]
        [InlineData("LMLMLMLMM")]
        public void CalculateMovement_WhenValidParameters_ExpectedOutputSuccess_1(string movements)
        {
            var plateau = new PlateauResponseDto
            {
                Plateau = new PlateauModel(5, 5)
            };

            var deployment = new DeploymentPointResponseDto
            {
                DeploymentPoint = new DeploymentPointModel(1, 2, Directions.N)
            };

            var movementList = movements.ToCharArray().Select(x => Enum.Parse<Moves>(x.ToString())).ToList();

            var request = new RoverRequestDto
            {
                DeploymentPointResponse = deployment,
                PlateauResponse = plateau,
                Movements = movementList
            };

            var response = _roverService.CalculateMovement(request);

            Assert.True(response.IsSuccess);
            Assert.Null(response.Message);
            Assert.Equal(1, response.Rover.DeploymentPoint.X);
            Assert.Equal(3, response.Rover.DeploymentPoint.Y);
            Assert.Equal(Directions.N, response.Rover.DeploymentPoint.Direction);
        }

        [Theory]
        [InlineData("MMRMMRMRRM")]
        public void CalculateMovement_WhenValidParameters_ExpectedOutputSuccess_2(string movements)
        {
            var plateau = new PlateauResponseDto
            {
                Plateau = new PlateauModel(5, 5)
            };

            var deployment = new DeploymentPointResponseDto
            {
                DeploymentPoint = new DeploymentPointModel(3, 3, Directions.E)
            };

            var movementList = movements.ToCharArray().Select(x => Enum.Parse<Moves>(x.ToString())).ToList();

            var request = new RoverRequestDto
            {
                DeploymentPointResponse = deployment,
                PlateauResponse = plateau,
                Movements = movementList
            };

            var response = _roverService.CalculateMovement(request);

            Assert.True(response.IsSuccess);
            Assert.Null(response.Message);
            Assert.Equal(5, response.Rover.DeploymentPoint.X);
            Assert.Equal(1, response.Rover.DeploymentPoint.Y);
            Assert.Equal(Directions.E, response.Rover.DeploymentPoint.Direction);
        }

        [Theory]
        [InlineData("LMLMLMLMMMMM")]
        [InlineData("MMMM")]
        [InlineData("LMM")]
        [InlineData("LMLMMM")]
        public void CalculateMovement_WhenOutOfBoundries_ReturnError(string movements)
        {
            var plateau = new PlateauResponseDto
            {
                Plateau = new PlateauModel(5, 5)
            };

            var deployment = new DeploymentPointResponseDto
            {
                DeploymentPoint = new DeploymentPointModel(1, 2, Directions.N)
            };

            var movementList = movements.ToCharArray().Select(x => Enum.Parse<Moves>(x.ToString())).ToList();

            var request = new RoverRequestDto
            {
                DeploymentPointResponse = deployment,
                PlateauResponse = plateau,
                Movements = movementList
            };

            var response = _roverService.CalculateMovement(request);

            Assert.False(response.IsSuccess);
            Assert.NotNull(response.Message);
            Assert.NotNull(response.Rover);
            Assert.Contains("Rover Can't Move! Last Position : ", response.Message);
        }

    }
}
