using MarsRover.Application.Dtos;
using MarsRover.Application.Dtos.Request;
using MarsRover.Application.Helpers;
using MarsRover.Application.Interfaces.Services;
using MarsRover.Domain.Entities;
using MarsRover.Domain.Enums;
using System;

namespace MarsRover.Infrastructure.Services
{
    public class RoverService : IRoverService
    {
        public RoverResponseDto CalculateMovement(RoverRequestDto roverRequest)
        {
            var roverModel = new RoverModel
            {
                DeploymentPoint = roverRequest.DeploymentPointResponse.DeploymentPoint,
                Movements = roverRequest.Movements,
                Plateau = roverRequest.PlateauResponse.Plateau
            };

            return MoveRover(roverModel);
        }

        private static RoverResponseDto MoveRover(RoverModel rover)
        {
            foreach (var movingDirection in rover.Movements)
            {
                string lastPosition;

                bool IsOutOfBoundries = false;

                switch (movingDirection)
                {
                    case Moves.L:
                        GetLastPosition(rover, out lastPosition);
                        MovementHelper.MoveLeft(rover);
                        break;
                    case Moves.R:
                        GetLastPosition(rover, out lastPosition);
                        MovementHelper.MoveRight(rover);
                        break;
                    case Moves.M:
                        GetLastPosition(rover, out lastPosition);
                        MovementHelper.MoveStraight(rover, out IsOutOfBoundries);
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }

                if (IsOutOfBoundries)
                {
                    return new RoverResponseDto { Rover = rover, IsSuccess = false, Message = "Rover Can't Move! Last Position : " + lastPosition };
                }
            }

            return new RoverResponseDto { Rover = rover, IsSuccess = true };
        }

        private static void GetLastPosition(RoverModel rover, out string lastPosition)
        {
            lastPosition = $"{rover.DeploymentPoint.X} {rover.DeploymentPoint.Y} {rover.DeploymentPoint.Direction}";
        }
    }
}
