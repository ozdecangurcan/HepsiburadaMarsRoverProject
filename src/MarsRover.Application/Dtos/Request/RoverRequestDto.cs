using MarsRover.Domain.Enums;
using System.Collections.Generic;

namespace MarsRover.Application.Dtos.Request
{
    public class RoverRequestDto
    {
        public PlateauResponseDto PlateauResponse { get; set; }
        public DeploymentPointResponseDto DeploymentPointResponse { get; set; }
        public List<Moves> Movements { get; set; }
    }
}
