using MarsRover.Domain.Entities;
using MarsRover.Domain.Enums;
using System;

namespace MarsRover.Application.Helpers
{
    public static class MovementHelper
    {
        /// <summary>
        /// Move rover straight direction
        /// </summary>
        /// <param name="rover"></param>
        /// <param name="IsOutOfBoundries">It tells rover cant move because of boundries</param>
        public static void MoveStraight(RoverModel rover, out bool IsOutOfBoundries)
        {
            switch (rover.DeploymentPoint.Direction)
            {
                case Directions.N:
                    if (rover.DeploymentPoint.Y + 1 <= rover.Plateau.Height && rover.DeploymentPoint.Y + 1 >= 0)
                    {
                        rover.DeploymentPoint.Y += 1;
                        IsOutOfBoundries = false;
                    }
                    else
                    {
                        IsOutOfBoundries = true;
                    }
                    break;

                case Directions.E:
                    if (rover.DeploymentPoint.X + 1 <= rover.Plateau.Width && rover.DeploymentPoint.X + 1 >= 0)
                    {
                        rover.DeploymentPoint.X += 1;
                        IsOutOfBoundries = false;
                    }
                    else
                    {
                        IsOutOfBoundries = true;
                    }
                    break;

                case Directions.S:
                    if (rover.DeploymentPoint.Y - 1 <= rover.Plateau.Height && rover.DeploymentPoint.Y - 1 >= 0)
                    {
                        rover.DeploymentPoint.Y -= 1;
                        IsOutOfBoundries = false;
                    }
                    else
                    {
                        IsOutOfBoundries = true;
                    }
                    break;

                case Directions.W:
                    if (rover.DeploymentPoint.X - 1 <= rover.Plateau.Width && rover.DeploymentPoint.X - 1 >= 0)
                    {
                        rover.DeploymentPoint.X -= 1;
                        IsOutOfBoundries = false;
                    }
                    else
                    {
                        IsOutOfBoundries = true;
                    }
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        /// <summary>
        /// Turn rover to the right depends on current direction of rover
        /// </summary>
        /// <param name="rover"></param>
        public static void MoveRight(RoverModel rover)
        {
            rover.DeploymentPoint.Direction = rover.DeploymentPoint.Direction switch
            {
                Directions.N => Directions.E,
                Directions.E => Directions.S,
                Directions.S => Directions.W,
                Directions.W => Directions.N,
                _ => throw new ArgumentOutOfRangeException(),
            };
        }

        /// <summary>
        /// Turn rover to the left depends on current direction of rover
        /// </summary>
        /// <param name="rover"></param>
        public static void MoveLeft(RoverModel rover)
        {
            rover.DeploymentPoint.Direction = rover.DeploymentPoint.Direction switch
            {
                Directions.N => Directions.W,
                Directions.W => Directions.S,
                Directions.S => Directions.E,
                Directions.E => Directions.N,
                _ => throw new ArgumentOutOfRangeException(),
            };
        }
    }
}
