using MarsRover.Domain.Entities;

namespace MarsRover.Application.Dtos
{
    public class RoverResponseDto : BaseDto
    {
        public RoverModel Rover { get; set; }
    }
}
