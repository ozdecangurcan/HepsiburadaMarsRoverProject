using MarsRover.Domain.Entities;

namespace MarsRover.Application.Dtos
{
    public class DeploymentPointResponseDto : BaseDto
    {
        public DeploymentPointModel DeploymentPoint { get; set; }
    }
}
