using MarsRover.Application.Dtos;
using MarsRover.Application.Dtos.Request;
using MarsRover.Application.Extensions;
using MarsRover.Application.Helpers;
using MarsRover.Application.Interfaces.Services;
using MarsRover.Domain.Entities;
using MarsRover.Domain.Enums;
using System;

namespace MarsRover.Infrastructure.Services
{
    public class DeploymentPointService : IDeploymentPointService
    {
        public DeploymentPointResponseDto PrepareDeploymentPoint(DeploymentPointRequestDto deploymentPointRequest)
        {
            if (!deploymentPointRequest.DeploymentCoordinates.CheckDeploymentPointParameters())
            {
                return new DeploymentPointResponseDto
                {
                    IsSuccess = false,
                    Message = "Invalid deployment point parameters"
                };
            }

            int x = int.Parse(deploymentPointRequest.DeploymentCoordinates[0]);

            int y = int.Parse(deploymentPointRequest.DeploymentCoordinates[1]);

            var direction = (Directions)Enum.Parse(typeof(Directions), deploymentPointRequest.DeploymentCoordinates[2]);

            int width = deploymentPointRequest.PlateauResponse.Plateau.Width;

            int height = deploymentPointRequest.PlateauResponse.Plateau.Height;

            var checkDeploymentPoint = DeploymentHelper.CheckDeploymentPoint(width, height, x, y);

            if (!checkDeploymentPoint)
            {
                return new DeploymentPointResponseDto
                {
                    IsSuccess = false,
                    Message = "Invalid deployment points"
                };
            }

            var deploymentPointModel = new DeploymentPointModel(x, y, direction);

            return new DeploymentPointResponseDto
            {
                DeploymentPoint = deploymentPointModel,
                IsSuccess = true
            };
        }
    }
}
