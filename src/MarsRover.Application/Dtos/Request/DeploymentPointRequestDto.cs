using System.Collections.Generic;

namespace MarsRover.Application.Dtos.Request
{
    public class DeploymentPointRequestDto
    {
        public DeploymentPointRequestDto(List<string> deploymentCoordinates, PlateauResponseDto plateauResponse)
        {
            DeploymentCoordinates = deploymentCoordinates;
            PlateauResponse = plateauResponse;
        }

        public List<string> DeploymentCoordinates { get; set; }

        public PlateauResponseDto PlateauResponse { get; set; }
    }
}
