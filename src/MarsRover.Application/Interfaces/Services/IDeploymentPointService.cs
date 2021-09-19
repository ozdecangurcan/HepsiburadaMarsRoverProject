using MarsRover.Application.Dtos;
using MarsRover.Application.Dtos.Request;

namespace MarsRover.Application.Interfaces.Services
{
    public interface IDeploymentPointService
    {
        /// <summary>
        /// Prepare deploy coordinates for deploying rover
        /// </summary>
        /// <param name="deploymentPointRequest"></param>
        /// <returns></returns>
        DeploymentPointResponseDto PrepareDeploymentPoint(DeploymentPointRequestDto deploymentPointRequest);
    }
}
