using MarsRover.Application.Dtos;
using MarsRover.Application.Dtos.Request;

namespace MarsRover.Application.Interfaces.Services
{
    public interface IRoverService
    {
        /// <summary>
        /// Calculate directions and move rover
        /// </summary>
        /// <param name="roverRequest"></param>
        /// <returns></returns>
        RoverResponseDto CalculateMovement(RoverRequestDto roverRequest);
    }
}
